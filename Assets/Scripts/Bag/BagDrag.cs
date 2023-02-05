using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class BagDrag : MonoBehaviour
{
    public float DragItemEndDistance = 1.0f;
    public string BagItemName = "BagItem";
    public string WordItemTag = "Item";
    public GameObject BagList;
    private GameObject mouseClickObject = null;
    private Transform[] BagItems;
    private Vector2? DragWordPostion;
    private Merge merge;
    private Bag bag;

    void Start()
    {
        merge = FindObjectOfType<Merge>();
        bag = GetComponent<Bag>();
        BagItems = BagList.GetComponentsInChildren<Transform>()
            .Where(x => x.gameObject.name.Length > 6 && x.gameObject.name.Substring(0, 7) == BagItemName).ToArray();
    }

    void Update()
    {
        ItemDrag();
    }

    private void ItemDrag()
    {
        if (Input.GetMouseButton(0))
        {
            Vector2 rayPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (mouseClickObject != null)
            {
                mouseClickObject.transform.position = rayPos;
            }
            else
            {
                PointerEventData pointer = new PointerEventData(EventSystem.current);
                pointer.position = Input.mousePosition;

                List<RaycastResult> raycastResults = new List<RaycastResult>();
                EventSystem.current.RaycastAll(pointer, raycastResults);

                if (raycastResults.Count > 0 && raycastResults[0].gameObject.tag == WordItemTag)
                {
                    raycastResults[0].gameObject.transform.position = rayPos;

                    //暫存物體
                    mouseClickObject = raycastResults[0].gameObject;
                    DragWordPostion = raycastResults[0].gameObject.transform.position;

                    bag.RemoveWord(raycastResults[0].gameObject.GetComponent<TMP_Text>().text);
                }
            }
        }
        else if (mouseClickObject != null)
        {

            foreach (Transform bagItem in BagItems)
            {
                Vector2 rayPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                if (Vector2.Distance(bagItem.position, mouseClickObject.transform.position) < DragItemEndDistance)
                {
                    mouseClickObject.transform.position = bagItem.position;
                    bag.AddWord(mouseClickObject.GetComponent<TMP_Text>().text);

                    //若物體能合併則合併並刪除物件
                    DragWordPostion = DragItemMerge(mouseClickObject);
                    if (DragWordPostion == null)
                    {
                        mouseClickObject = null;
                        return;
                    }
                }
            }
            //復原放置前的位置
            mouseClickObject.transform.position = (Vector2)DragWordPostion;
            bag.AddWord(mouseClickObject.GetComponent<TMP_Text>().text);

            //放開暫持物體
            mouseClickObject = null;
        }
    }

    private Vector2? DragItemMerge(GameObject mouseClickObject)
    {
        Vector2 tempVector2 = mouseClickObject.transform.position;
        GameObject[] items = GameObject.FindGameObjectsWithTag(WordItemTag);
        foreach (GameObject item in items)
        {
            if (item.name == mouseClickObject.name
                || Vector2.Distance(item.transform.position, mouseClickObject.transform.position) > DragItemEndDistance)
                continue;

            string tragText = item.GetComponent<TMP_Text>().text;
            string thisText = mouseClickObject.GetComponent<TMP_Text>().text;

            tempVector2 = (Vector2)DragWordPostion;

            //判斷可否合併
            Debug.Log(tragText + thisText);
            if (!merge.MergeWords(tragText, thisText))
                continue;

            bag.RemoveWord(tragText);
            bag.RemoveWord(thisText);
            bag.AddWord(tragText + thisText);

            item.GetComponent<TMP_Text>().text = tragText + thisText;

            Destroy(mouseClickObject);
            return null;
        }
        return tempVector2;
    }

}
