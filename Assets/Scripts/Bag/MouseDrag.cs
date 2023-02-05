using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDrag : MonoBehaviour
{
    public Select select;
    private bool hasTaken = false;
    private Vector3 originPosition;
    public LayerMask EnvironmentMask = 1 << 9;

    public GameObject DroppedWord;
    public Transform Canvas;
    public Transform Inventory;
    private int index = -1;

    public Bag bag;
    // Update is called once per frame
    void Update()
    { 
        if (Input.GetMouseButton(0) && select.CurrentObject == this.gameObject)
            Drag();
        else if(hasTaken && Input.GetMouseButtonUp(0))
        {
            if(index != -1) // inside
            {
                int minCheck = Mathf.Clamp(index - 1, 0, Inventory.childCount);
                int maxCheck = Mathf.Clamp(index + 1, 0, Inventory.childCount);
                float f = Mathf.Infinity;
                int minIndex = index;
                for(int i = minCheck; i <= maxCheck;i++)
                {
                    if(f < Mathf.Abs(Inventory.GetChild(i).transform.position.x - transform.position.x))
                    {
                        f = Mathf.Abs(Inventory.GetChild(i).transform.position.x - transform.position.x);
                        minIndex = i;
                    }
                }
                bag.MergeWord(minIndex, int.Parse(gameObject.name));
            }
            Collider2D temp = Physics2D.OverlapBox(transform.position, new Vector2(1f, 1f), 0f, EnvironmentMask);
            if (temp == null)// outside and not collide with environment
                GameObject.Instantiate(DroppedWord, transform.position, Quaternion.identity, Canvas);
            transform.position = originPosition;
        }
    }
    private void Drag()
    {
        if (bag.words.Count <= int.Parse(gameObject.name))
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
