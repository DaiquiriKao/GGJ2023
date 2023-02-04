using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Move : MonoBehaviour
{
    public float Speed = 1.2f;
    public PlayerInput pm;
    private InputAction m_Move;
    private void Awake()
    {
        m_Move = pm.actions["X-axis"];
    }
    void Update()
    {
        if (m_Move.ReadValue<float>() == -1f)
            this.transform.position = this.transform.position - new Vector3(Speed * Time.deltaTime, 0, 0);
        if (m_Move.ReadValue<float>() == 1f)
            this.transform.position = this.transform.position + new Vector3(Speed * Time.deltaTime, 0, 0);       
    }
}
