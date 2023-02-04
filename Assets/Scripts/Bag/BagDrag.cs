using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class BagDrag : MonoBehaviour
{

    void Start()
    {
        
    }

    void Update()
    {
        ItemDrag();
    }

    private void ItemDrag()
    {
        if (Input.GetMouseButton(0))
        {
            PointerEventData pointer = new PointerEventData(EventSystem.current);
            pointer.position = Input.mousePosition;

            List<RaycastResult> raycastResults = new List<RaycastResult>();
            EventSystem.current.RaycastAll(pointer, raycastResults);

            Vector2 rayPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (raycastResults.Count > 0 && raycastResults[0].gameObject.tag == "EditorOnly")
            {
                Debug.Log(Input.mousePosition);
                raycastResults[0].gameObject.transform.position = rayPos;
            }


        }
    }
}
