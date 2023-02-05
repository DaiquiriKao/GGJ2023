using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    [SerializeField] private GameObject balloon;
    [SerializeField] private GameObject balloonPlayer;
    [SerializeField] private TriggerCallback balloonTrigger;
    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] private float speed;
    [SerializeField] private float floatingSpeed = -0.07f;

    [SerializeField] private bool isControllable;

    private void Start()
    {
        balloon.SetActive(true);
        balloonPlayer.SetActive(false);
        balloonTrigger.SetCallback(OnBalloonTouched);
        rigidBody.gravityScale = 0;
    }

    private void Update()
    {
        if (isControllable)
        {
            WaitInput();
        }
    }

    private void OnBalloonTouched(Collider2D collider)
    {
        if(collider.tag == "Player")
        {
            Fly();
        }
    }

    [ContextMenu("Test Fly")]
    private void Fly()
    {
        balloon.SetActive(false);
        balloonPlayer.SetActive(true);
        isControllable = true;
        rigidBody.gravityScale = floatingSpeed;
        GameObject.Find("Player").SetActive(false);
        this.gameObject.tag = "Player";
    }

    private void WaitInput()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            transform.position -= new Vector3(speed, 0, 0);
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(speed, 0, 0);
        }
    }
}
