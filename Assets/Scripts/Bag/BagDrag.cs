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
    private GameObject[] items;
    private Transform[] BagItems;
    private Merge merge;
    private Bag bag;

    void Start()
    {
        merge = FindObjectOfType<Merge>();
        bag = GetComponent<Bag>();
        BagItems = GetComponentsInChildren<Transform>().Where(x => x.gameObject.name.Length > 6 && x.gameObject.name.Substring(0, 7) == "BagItem").ToArray();
    }

    void Update()
    {
        ItemDrag();
    }

    private GameObject mouseClickObject = null;
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

                if (raycastResults.Count > 0 && raycastResults[0].gameObject.tag == "Item")
                {
                    raycastResults[0].gameObject.transform.position = rayPos;
                    mouseClickObject = raycastResults[0].gameObject;
                    //bag.AddWord("");
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
                    //若物體能合併則合併並刪除物件
                    mergeItem(mouseClickObject);
                    mouseClickObject = null;
                    break;
                }
            }
        }
    }

    private void mergeItem(GameObject mouseClickObject)
    {
        if (mouseClickObject == null)
            return;

        items = GameObject.FindGameObjectsWithTag("Item");
        foreach (GameObject item in items)
        {
            if (item.name == mouseClickObject.name
                || Vector2.Distance(item.transform.position, mouseClickObject.transform.position) > DragItemEndDistance)
                continue;

            TMP_Text tragText = item.GetComponent<TMP_Text>();
            TMP_Text thisText = mouseClickObject.GetComponent<TMP_Text>();



            //todo : 判斷可否合併
            item.GetComponent<TMP_Text>().text = tragText.text + thisText.text;

            Destroy(mouseClickObject);
            return;
        }
    }

}
