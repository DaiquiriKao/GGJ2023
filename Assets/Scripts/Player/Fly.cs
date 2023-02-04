using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Fly : MonoBehaviour
{
    public Status status;
    public float Force = 1.2f;
    public PlayerInput pm;
    private InputAction m_Fly;
    private Rigidbody2D m_rb;
    public Animator m_playerAnimation;

    private void OnEnable()
    {
        status.CurrentSatus |= Status.status.Flyable;
        m_Fly = pm.actions["Jump"];
        m_rb = GetComponent<Rigidbody2D>();
    }
    public void Update()
    {
        if (m_Fly.triggered && (status.CurrentSatus & Status.status.Flyable) != 0)
        {
            m_playerAnimation.SetTrigger("Jump");
            m_rb.AddForce(Force * 200 * new Vector2(0, 1f));
        }
            
    }
    private void OnDisable()
    {
        status.CurrentSatus ^= Status.status.Flyable;
    }
}
