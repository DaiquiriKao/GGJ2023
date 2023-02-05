using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unlock : MonoBehaviour
{
    private Animator m_Animator;
    private void OnEnable()
    {
        if (GameObject.Find("Door") != null)
            m_Animator = GameObject.Find("Door").GetComponent<Animator>();
        OnTriggerEvent();
    }
    public void OnTriggerEvent()
    {
        m_Animator.SetTrigger("Event");
    }
}
