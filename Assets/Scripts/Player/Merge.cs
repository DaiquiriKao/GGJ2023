using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class MergableWord{
    public string word;
    public Sprite image; 
    [SerializeField]
    public Effect effect;
}

public class Merge : MonoBehaviour
{
    public Bag Words;
    public List<MergableWord> MergeList = new List<MergableWord>();
    public Sprite isAvaliableWord(string s)
    {
        bool isFound = false;
        Sprite temp = null;
        foreach (MergableWord mw in MergeList)
        {
            if (mw.word == s)
            {
                isFound = true;
                temp = mw.image;
                break;
            }
        }
        if (!isFound)
            return null;
        return temp;
    }
    public void MergeWords(string a, string b)
    {
        string final = a + b;
        bool isFound = false;
        foreach (MergableWord mw in MergeList)
        {
            if (mw.word == final)
            {
                Debug.Log("Find word");
                mw.effect.Execution();
                isFound = true;
                break;
            }
        }
        if (!isFound)
        {
            Debug.Log("Fail!");
            return;
        }
        Words.RemoveWord(a);
        Words.RemoveWord(b);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
            MergeWords("fly", "able");
    }
}
