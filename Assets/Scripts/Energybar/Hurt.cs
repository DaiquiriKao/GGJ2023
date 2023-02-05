using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hurt : MonoBehaviour
{
    [SerializeField]
    public bool HurtForce = true;
    public string DamgeObjectName = "DamgeObject";
    public float Damge = 1.0f;
    public float Power = 2.0f;

    public EnergyBar EnergyBar;

    private Rigidbody2D rigidbody2;

    void Start()
    {
        rigidbody2 = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == DamgeObjectName)
        {
            EnergyBar.LostEnergy(Damge);

            if (HurtForce)
            {
                //todo: 受傷之後動作
                Debug.Log();
                //rigidbody2.AddForce(new Vector2(gameObject.transform.forward.x * -1, gameObject.transform.forward.y + 0.5f) * Power);
            }
        }
    }
}
