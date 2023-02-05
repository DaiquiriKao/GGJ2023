using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MouseDrag : MonoBehaviour
{
    public bool CanDrag = false;
    public Select select;
    private bool hasTaken = false;
    private Vector3 originPosition;
    public LayerMask EnvironmentMask = 1 << 9;

    public GameObject DroppedWord;
    public Transform Canvas;
    public Transform Inventory;
    private int index = -1;

    public Bag bag;
    private string PrefabLocation = "AvaliableObject/";
    // Update is called once per frame
    void Update()
    { 
        if (Input.GetMouseButton(0) && select.CurrentObject == this.gameObject)
            Drag();
        else if(hasTaken && Input.GetMouseButtonUp(0))
        {
            if (index != -1) // inside
            {
                int minCheck = Mathf.Clamp(index - 2, 0, bag.words.Count - 1);
                int maxCheck = Mathf.Clamp(index + 2, 0, bag.words.Count - 1);
                float f = Mathf.Infinity;
                int minIndex = minCheck;
                if (minCheck-1 <= index && index <= maxCheck+1)
                {
                    for (int i = minCheck; i <= maxCheck; i++)
                    {
                        if (i == int.Parse(gameObject.name))
                            continue;
                        Debug.Log(Mathf.Abs(Inventory.GetChild(i).transform.position.x - transform.position.x));
                        if (f > Mathf.Abs(Inventory.GetChild(i).transform.position.x - transform.position.x))
                        {
                            f = Mathf.Abs(Inventory.GetChild(i).transform.position.x - transform.position.x);
                            minIndex = i;
                        }
                    }
                    bag.MergeWord(minIndex, int.Parse(gameObject.name));
                }
            }
            else
            {
                Collider2D temp = Physics2D.OverlapBox(transform.position, new Vector2(1f, 1f), 0f, EnvironmentMask);
                if (temp == null) // outside and not collide with environment
                {
                    if (bag.IconList.isAvaliableWord(bag.words[int.Parse(gameObject.name)])==null)
                    {
                        GameObject drop = GameObject.Instantiate(DroppedWord, transform.position, Quaternion.identity, Canvas);
                        drop.GetComponent<DroppedWord>().Initialize(bag.words[int.Parse(gameObject.name)], false);
                        bag.RemoveIndex(int.Parse(gameObject.name));
                    }
                    else
                    {
                        GameObject drop = Resources.Load<GameObject>(PrefabLocation + bag.words[int.Parse(gameObject.name)]);
                        bag.RemoveIndex(int.Parse(gameObject.name));
                    }
                }
            }
            transform.position = originPosition;
            hasTaken = false;
        }
    }
    private void Drag()
    {
        if (!CanDrag)
            return;
        if(!hasTaken)
        {
            hasTaken = true;
            originPosition = transform.position;
        }
        Vector2 castPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        this.gameObject.transform.position = castPoint;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Item")
            index = -1;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Item")
            index = int.Parse(collision.name);
    }
}
