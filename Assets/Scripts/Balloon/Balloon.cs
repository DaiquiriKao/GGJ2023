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

    [SerializeField] private bool isControllable;

    private void Start()
    {
        balloon.SetActive(true);
        balloonPlayer.SetActive(false);
        balloonTrigger.SetCallback(OnBalloonTouched);
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

    private void Fly()
    {
        balloon.SetActive(false);
        balloonPlayer.SetActive(true);
        isControllable = true;
    }

    private void WaitInput()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position -= new Vector3(speed, 0, 0);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += new Vector3(speed, 0, 0);
        }
    }
}
