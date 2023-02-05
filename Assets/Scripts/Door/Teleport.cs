using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform TeleportTarget;
    public string PlayerTag = "Player";
    public Animation animation;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == PlayerTag)
        {
            //todo: Animation

            collision.gameObject.transform.position = TeleportTarget.position;
        }
    }
}
