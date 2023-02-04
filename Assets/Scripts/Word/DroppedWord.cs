using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DroppedWord : MonoBehaviour
{
    public string partWord;
    public TextMeshProUGUI tmp;
    public void Initialize(string s)
    {
        partWord = s;
        this.gameObject.name = partWord;
        tmp.text = partWord;
    }
    public void Destroy()
    {
        Destroy(gameObject);
    }
    public void OnDisable()
    {
        partWord = null;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!(other.tag == "Player"))
            return;
        Bag bag = other.transform.GetChild(0).GetComponent<Bag>();
        if (bag.isFull())
            return;
        bag.AddWord(partWord);
        Invoke("Destroy", 0.5f);
    }
}
