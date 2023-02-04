using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DroppedWord : MonoBehaviour
{
    public string partWord;
    public TextMeshProUGUI tmp;
    private Rigidbody2D rb;

    public void Initialize(string s)
    {
        partWord = s;
        this.gameObject.name = partWord;
        tmp.text = partWord;
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(3f * new Vector2(Random.Range(-0.4f, 0.4f), Random.Range(0.5f, 0.8f)));
    }
    public void Destroy()
    {
        Destroy(gameObject);
    }
    public void OnDisable()
    {
        partWord = null;
    }
    private void OnCollistionEnter2D(Collision2D other)
    {
        if (!(other.collider.tag == "Player"))
            return;
        Bag bag = other.transform.GetChild(0).GetComponent<Bag>();
        if (bag.isFull())
            return;
        bag.AddWord(partWord);
        Invoke("Destroy", 0.5f);
    }
}
