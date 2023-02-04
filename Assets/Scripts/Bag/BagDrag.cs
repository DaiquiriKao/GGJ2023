using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class BagDrag : MonoBehaviour
{
    public float DragItemEndDistance = 10.0f;
    public Transform[] BagItems;

    void Start()
    {
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
            PointerEventData pointer = new PointerEventData(EventSystem.current);
            pointer.position = Input.mousePosition;

            List<RaycastResult> raycastResults = new List<RaycastResult>();
            EventSystem.current.RaycastAll(pointer, raycastResults);

            Vector2 rayPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (raycastResults.Count > 0 && raycastResults[0].gameObject.tag == "Item")
            {
                raycastResults[0].gameObject.transform.position = rayPos;
                mouseClickObject = raycastResults[0].gameObject;
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
                    mouseClickObject = null;
                    break;
                }
            }
        }

    }
}
