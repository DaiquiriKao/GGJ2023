using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WordHolder : MonoBehaviour
{
    public Word word;
    public GameObject droppedWord;
    public bool isSplited = false;
    private Animator m_animator;
    
    public void DropWord(string s, Transform droppedCanvas)
    {
        
        Debug.Log("Drop");
        GameObject gm = GameObject.Instantiate(droppedWord, transform.position, Quaternion.identity, droppedCanvas);
        gm.GetComponent<DroppedWord>().Initialize(s);
        //Invoke("Delete", 1f);
    }

    public void Delete()
    {
        Destroy(gameObject);
    }
}
