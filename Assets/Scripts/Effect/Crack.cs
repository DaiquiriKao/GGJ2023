using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Crack : MonoBehaviour
{
    private Animator m_Animator;
    private void OnEnable()
    {
        if(GameObject.Find("Crack") != null)
            m_Animator = GameObject.Find("Crack").GetComponent<Animator>();
        OnTriggerEvent();
    }
    public void OnTriggerEvent()
    {
        m_Animator.SetTrigger("Event");
    }
}
