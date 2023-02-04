using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MergableWord {
    public string word;
    [SerializeField]
    public Effect effect;
}

public class Merge : MonoBehaviour
{
    public List<MergableWord>MergeList = new List<MergableWord>();

    public bool MergeWords(string a, string b)
    {
        string final = a + b;
        bool isFound = false;
        foreach(MergableWord mw in MergeList)
        {
            if(mw.word == final)
            {
                Debug.Log("Find word");
                mw.effect.Execution();
                isFound = true;
                break;
            }
        }
        if(!isFound)
        {
            Debug.Log("Fail!");
        }
        return isFound;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
            MergeWords("fly", "able");
    }
}
