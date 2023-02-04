using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bag : MonoBehaviour
{
    public int MaxNumber = 10;
    public List<string> words = new List<string>();
    public GameObject droppedWord;

    public bool isFull()
    {
        if (words.Count >= MaxNumber)
            return true;
        else
            return false;
    }
    public bool AddWord(string s)
    {
        if (words.Count < MaxNumber)
        {
            words.Add(s);
            return true;
        }
        else
            return false;
    }
    public void RemoveWord(string s)
    {
        words.Remove(s);
    }
    private void DropWord(string s)
    {
        GameObject gm = GameObject.Instantiate(droppedWord, transform.position, Quaternion.identity);
        gm.name = s;
    }
}
