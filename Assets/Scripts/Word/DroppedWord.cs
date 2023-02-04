using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DroppedWord : MonoBehaviour
{
    public string partWord;
    public TextMeshProUGUI tmp;
    private Rigidbody2D rb;
    private void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void Initialize(string s)
    {
        partWord = s;
        this.gameObject.name = partWord;
        tmp.text = partWord;
        rb.AddForce(3f * new Vector2(Random.Range(-0.4f, 0.4f), Random.Range(0.1f, 0.5f)));
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
