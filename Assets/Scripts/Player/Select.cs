using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Select : MonoBehaviour
{
    public GameObject CurrentObject;
    public Transform Cursor;
    public Vector2 MousePosition;
    [Space(20)]
    public Vector2 ClickPosition;

    [NonSerialized]
    public GameObject TakenObject = null;
    private void Update()
    {
        MouseTrack();
    }
    private void MouseTrack()
    {
        Vector2 rayPos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        ////Debug.Log(rayPos);
        //RaycastHit2D hit = Physics2D.Raycast(rayPos, Vector2.zero);
        RaycastHit2D hit = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition));
        CurrentObject = null;
        if (hit.collider != null)
        {
            CurrentObject = hit.collider.transform.gameObject;
        }
    }

    public void SetTakeObject(GameObject gameObject)
    {
        if (gameObject != null)
            TakenObject = gameObject;
    }

    public void RemoveTakeObject()
    {
        if (TakenObject != null)
            TakenObject = null;
    }


}
