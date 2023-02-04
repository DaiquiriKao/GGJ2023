using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WordHolder : MonoBehaviour
{
    public Word word;
    public GameObject droppedWord;
    public bool isSplited = false;

    public void DropWord(string s, Transform droppedCanvas)
    {
        GameObject gm = GameObject.Instantiate(droppedWord, transform.position, Quaternion.identity, droppedCanvas);
        gm.GetComponent<DroppedWord>().Initialize(s);
    }

    public void Delete()
    {
        Destroy(gameObject);
    }
}
