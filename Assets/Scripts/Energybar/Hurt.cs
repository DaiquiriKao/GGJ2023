using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hurt : MonoBehaviour
{
    [SerializeField]
    public bool HurtForce = true;
    public string DamgeObjectName = "DamgeObject";
    public float Damge = 1.0f;

    public EnergyBar EnergyBar;

    void Start()
    {
        
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

            }
        }
    }
}
