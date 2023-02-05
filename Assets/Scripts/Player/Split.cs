using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Split : MonoBehaviour
{
    public Bag PlayerBag;
    public Select Selection;
    public Transform DroppedCanvas;
    public Animator m_PlayerAttack;
    public GameObject Explosion;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && Selection.CurrentObject != null)
            Click();
    }
    
    public void Click()
    {
        if (Vector2.Distance(Selection.CurrentObject.transform.position, transform.position) > 2f)
        {
            Debug.Log("outrange : " + Vector2.Distance(Selection.CurrentObject.transform.position, transform.position));
            return;
        }
        if (Selection.CurrentObject.GetComponent<WordHolder>() == null)
            return;
        m_PlayerAttack.SetTrigger("Attack");
        WordHolder wh = Selection.CurrentObject.GetComponent<WordHolder>();
        GameObject explode = GameObject.Instantiate(Explosion, Selection.CurrentObject.transform);
        explode.transform.localPosition = Vector3.zero;
        explode.transform.parent = explode.transform.parent.parent;
        SplitWord(wh);
    }
    public void SplitWord(WordHolder word)
    {
        if (word.isSplited)
            return;
        Animator m_animator = word.gameObject.GetComponent<Animator>();
        m_animator.SetTrigger("Split");
        foreach (string s in word.word.DerivedWords)
        {
            //if (!PlayerBag.AddWord(s))
            word.DropWord(s, DroppedCanvas);
        }
        word.isSplited = true;
        word.Delete();
    }
}
