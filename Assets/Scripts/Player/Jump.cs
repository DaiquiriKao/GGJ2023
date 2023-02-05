using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem;

public class Jump : MonoBehaviour
{
    public Status status;
    public float Force = 1.2f;
    public PlayerInput pm;
    private InputAction m_Fly;
    private Rigidbody2D m_rb;
    public Animator m_playerAnimation;
    public LayerMask Gound;
    public AudioSource AudioSound;
    public AudioClip AudioSource;
    private int jumpTimes = 0;

    private void OnEnable()
    {
        status.CurrentSatus |= Status.status.Flyable;
        m_Fly = pm.actions["Jump"];
        m_rb = GetComponent<Rigidbody2D>();
    }
    public void Update()
    {
        if (m_Fly.triggered && (status.CurrentSatus & Status.status.Flyable) != 0 && (isGrounded() || jumpTimes == 1))
        {
            m_playerAnimation.SetTrigger("Jump");

            if (AudioSound != null && AudioSource != null)
            {
                AudioSound.clip = AudioSource;
                AudioSound.Play();
            }

            if (jumpTimes == 1)
                m_rb.AddForce(Force * 200 * new Vector2(0, 1f));
            else
                m_rb.AddForce(Force * 200 * new Vector2(0, 1f));
            jumpTimes++;
        }
    }
    private void OnDisable()
    {
        status.CurrentSatus ^= Status.status.Flyable;
    }
    private bool isGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1f, Gound);
        if (hit.collider != null)
        {
            jumpTimes = 0;
            return true;
        }
        else
            return false;
    }
}
