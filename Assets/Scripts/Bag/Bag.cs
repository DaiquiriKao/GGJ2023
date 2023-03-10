using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public class InventoryField {
    public Image icon;
    public TextMeshProUGUI word;
}

public class Bag : MonoBehaviour
{
    public int MaxNumber = 14;
    private int currentSize = 0;
    public List<InventoryField> fields = new List<InventoryField>();
    public List<string> words = new List<string>();
    public GameObject droppedWord;
    public Merge IconList;
    
    public bool isFull()
    {
        if (words.Count >= MaxNumber)
            return true;
        else
            return false;
    }
    public void MergeWord(int a, int b)
    {
        Debug.Log(a+ " " + b);
        if (a == b)
            return;
        string first = words[a];
        string second = words[b];
        string str1 = first + second;
        string str2 = second + first;
        if (IconList.isAvaliableWord(str1) != null)
        {
            RemoveWord(first);
            RemoveWord(second);
            AddWord(str1);
            return;
        }
        else if(IconList.isAvaliableWord(str2) != null)
        {
            RemoveWord(first);
            RemoveWord(second);
            AddWord(str2);
            return;
        }
    }
    public bool AddWord(string s)
    {
        if (words.Count < MaxNumber)
        {
            Sprite icon = IconList.isAvaliableWord(s);
            if (icon != null)
            {
                fields[words.Count].icon.sprite = icon;
                fields[words.Count].icon.color = new Color(1f, 1f, 1f, 1f);
                fields[words.Count].word.text = "";
            }
            else
            {
                fields[words.Count].word.text = s;
            }
            fields[words.Count].icon.GetComponent<MouseDrag>().CanDrag = true;
            words.Add(s);
            return true;
        }
        else
            return false;
    }
    public void RemoveIndex(int index)
    {
        words.RemoveAt(index);

        for (int i = index; i <= words.Count; i++)
        {
            fields[i].icon.sprite = fields[i + 1].icon.sprite;
            fields[i].icon.color = fields[i + 1].icon.color;
            fields[i].word.text = fields[i + 1].word.text;
        }
        fields[words.Count].icon.GetComponent<MouseDrag>().CanDrag = true;
        fields[words.Count].icon.sprite = null;
        fields[words.Count].icon.color = new Color(1f, 1f, 1f, 0f);
        fields[words.Count].word.text = "";
    }
    public void RemoveWord(string s)
    {
        int index = -1;
        for(int i = 0;i<words.Count;i++)
        {
            if (s == words[i])
            {
                index = i;
                break;
            }
        }
        if (index == -1)
            return;

        words.RemoveAt(index);

        for (int i = index; i < words.Count; i++) {
            fields[i].icon.sprite = fields[i+1].icon.sprite;
            fields[i].icon.color = fields[i+1].icon.color;
            fields[i].word.text = fields[i + 1].word.text;
        }
        fields[words.Count].icon.GetComponent<MouseDrag>().CanDrag = true;
        fields[words.Count].icon.sprite = null;
        fields[words.Count].icon.color = new Color(1f, 1f, 1f, 0f);
        fields[words.Count].word.text = "";
    }
    private void DropWord(string s)
    {
        GameObject gm = GameObject.Instantiate(droppedWord, transform.position, Quaternion.identity);
        gm.name = s;
    }
}
