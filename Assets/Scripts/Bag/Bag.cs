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
        if (fields.Count >= MaxNumber)
            return true;
        else
            return false;
    }
    public void MergeWord(int a, int b)
    {
        Debug.Log(a+ " " + b);
        string str1 = words[a];
        string str2 = words[b];
        RemoveWord(str1);
        RemoveWord(str2);
        AddWord(str1 + str2);
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

        for (int i = index; i <= words.Count; i++) {
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
