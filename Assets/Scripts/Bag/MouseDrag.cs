using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDrag : MonoBehaviour
{
    public Select select;
    private bool hasTaken = false;
    private Vector3 originPosition;
    public LayerMask EnvironmentMask = 1 << 9;

    // Update is called once per frame
    void Update()
    { 
        if (Input.GetMouseButton(0) && select.CurrentObject == this.gameObject)
            Drag();
        else if(hasTaken && Input.GetMouseButtonUp(0))
        {
            Collider2D temp = Physics2D.OverlapBox(transform.position, new Vector2(10f, 10f), 0f);

            if (temp.tag == "Item")
                Debug.Log("Merge");
            else if (temp.gameObject.layer != EnvironmentMask)
                Debug.Log("Outside");
            transform.position = originPosition;
        }
    }
    private void Drag()
    {
        if(!hasTaken)
        {
            hasTaken = true;
            originPosition = transform.position;
        }
        Vector2 castPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        this.gameObject.transform.position = castPoint;
    }
}
