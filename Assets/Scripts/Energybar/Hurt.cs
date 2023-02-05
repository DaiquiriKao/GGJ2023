using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hurt : MonoBehaviour
{
    [SerializeField]
    public bool HurtForce = true;
    public Image Image;
    public AudioSource AudioSound;
    public AudioClip AudioSource;
    public string DamgeObjectName = "DamgeObject";
    public float Damge = 1.0f;
    public float Power = 200.0f;

    public EnergyBar EnergyBar;

    private Rigidbody2D rigidbody2;

    void Start()
    {
        rigidbody2 = GetComponent<Rigidbody2D>();

        if (Image == null)
            HurtForce = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == DamgeObjectName)
        {
            EnergyBar.LostEnergy(Damge);

            if (HurtForce)
            {
                //todo: 受傷之後動作
                float vector = (gameObject.transform.position.x - collision.transform.position.x)
                    / Mathf.Abs(gameObject.transform.position.x - collision.transform.position.x);

                rigidbody2.AddForce(new Vector2(vector, 1) * Power);

                if (AudioSound != null && AudioSource != null)
                {
                    AudioSound.clip = AudioSource;
                    AudioSound.Play();
                }

                StartCoroutine(FlashRed(Image, 3));
            }
        }
    }

    private IEnumerator FlashRed(Image image, int length)
    {
        Color TempColor = image.color;
        for (int i = 0; i < length; i++)
        {
            image.color = Color.red;
            yield return new WaitForSeconds(0.2f);
            image.color = TempColor;
            yield return new WaitForSeconds(0.2f);
        }
    }
}
