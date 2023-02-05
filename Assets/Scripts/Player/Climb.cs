using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Climb : MonoBehaviour
{
    public string LadderName = "ladder";
    public float ClimbSpeed = 1.2f;
    public Status status;
    public Jump jump;
    public Animator m_playerAnimation;
    public PlayerInput pm;
    public AudioSource AudioSound;
    public AudioClip AudioSource;

    private InputAction m_Climp;

    private Rigidbody2D m_rb;
    private float tempGravityScale = 0;
    private bool OnLadder = false;

    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();

        m_Climp = pm.actions["Y-axis"];

        tempGravityScale = m_rb.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (OnLadder && m_Climp.ReadValue<float>() != 0)
        {
            if (AudioSound != null && AudioSource != null)
            {
                AudioSound.clip = AudioSource;
                AudioSound.Play();
            }

            transform.position += new Vector3(0, m_Climp.ReadValue<float>() * ClimbSpeed * Time.deltaTime, 0);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.name != LadderName || OnLadder || m_Climp.ReadValue<float>() == 0)
            return;

        tempGravityScale = m_rb.gravityScale;
        m_rb.gravityScale = 0;
        m_rb.velocity = Vector3.zero;

        jump.enabled = false;

        OnLadder = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name != LadderName || !OnLadder)
            return;

        m_rb.gravityScale = tempGravityScale;

        jump.enabled = true;

        OnLadder = false;
    }
}
