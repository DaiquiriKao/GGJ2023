using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Split : MonoBehaviour
{
    public Bag PlayerBag;
    public Select Selection;
    public Transform DroppedCanvas;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && Selection.CurrentObject != null)
            Click();
    }
    
    public void Click()
    {
        if (Vector2.Distance(Selection.CurrentObject.transform.position, transform.position) > 2f)
        {
            Debug.Log(Selection.CurrentObject.transform.position + " " + transform.position);
            Debug.Log("outrange : " + Vector2.Distance(Selection.CurrentObject.transform.position, transform.position));
            return;
        }
        if (Selection.CurrentObject.GetComponent<WordHolder>() == null)
            return;
        WordHolder wh = Selection.CurrentObject.GetComponent<WordHolder>();
        SplitWord(wh);
    }
    public void SplitWord(WordHolder word)
    {
        if (word.isSplited)
            return;
        foreach (string s in word.word.DerivedWords)
        {
            if (!PlayerBag.AddWord(s))
                word.DropWord(s, DroppedCanvas);
        }
        word.isSplited = true;
        word.Delete();
    }
}
