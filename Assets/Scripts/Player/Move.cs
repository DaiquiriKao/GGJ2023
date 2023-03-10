using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Move : MonoBehaviour
{
    public float Speed = 1.5f;
    public PlayerInput pm;
    private InputAction m_Move;
    public Animator m_PlayerAnimator;
    public AudioSource AudioSound;
    public AudioClip AudioSource;
    private void Awake()
    {
        m_Move = pm.actions["X-axis"];
    }
    void Update()
    {
        if (m_Move.ReadValue<float>() == -1f)
        {
            if (GetComponent<RectTransform>().localScale.x == -1)
                GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);

            m_PlayerAnimator.SetFloat("Speed", 1f);
            this.transform.position = this.transform.position - new Vector3(Speed * Time.deltaTime, 0, 0);

            if (AudioSound != null && AudioSource != null)
            {
                AudioSound.clip = AudioSource;
                AudioSound.Play();
            }
        }
        else if (m_Move.ReadValue<float>() == 1f)
        {
            if (GetComponent<RectTransform>().localScale.x == 1)
                GetComponent<RectTransform>().localScale = new Vector3(-1, 1, 1);
            m_PlayerAnimator.SetFloat("Speed", 0.5f);
            this.transform.position = this.transform.position + new Vector3(Speed * Time.deltaTime, 0, 0);

            if (AudioSound != null && AudioSource != null)
            {
                AudioSound.clip = AudioSource;
                AudioSound.Play();
            }
        }
        else
            m_PlayerAnimator.SetFloat("Speed", 0f);
    }
}
