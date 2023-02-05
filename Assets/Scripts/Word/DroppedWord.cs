using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Security.Cryptography;
using Unity.VisualScripting;

public class DroppedWord : MonoBehaviour
{
    public string partWord;
    public TextMeshProUGUI tmp;
    private Rigidbody2D rb;

    private IEnumerator PlayerGain()
    {
        yield return new WaitForSeconds(0.7f);
        Vector3 initPos = transform.localPosition;
        Vector3 final = GameObject.Find("Player").transform.localPosition - new Vector3(0f, 5f, 0f);
        float scale = 5f;
        for (float f = 0f; f <= 1f; f += Time.deltaTime * scale) {
            transform.localPosition = Vector3.Slerp(initPos, final, f);
            if(scale > 1f)
                scale -= 0.1f;
            yield return null;
        }
        Destroy();
    }
    public void Initialize(string s)
    {
        partWord = s;
        this.gameObject.name = partWord;
        tmp.text = partWord;
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(8f * new Vector2(Random.Range(-0.5f, 0.5f), Random.Range(0.2f, 0.4f)));
        if (GameObject.Find("Bag").GetComponent<Bag>().AddWord(partWord))
            StartCoroutine(PlayerGain());
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
