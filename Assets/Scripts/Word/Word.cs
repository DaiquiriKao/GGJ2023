using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Word", menuName = "ScriptableObjects/Word", order = 1)]
public class Word : ScriptableObject
{
    public string BaseWord;
    public List<string> DerivedWords = new List<string>();
}
