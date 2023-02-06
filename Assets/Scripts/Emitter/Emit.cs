using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class Emit : MonoBehaviour
{
    public Transform EmitPoint;
    public GameObject Fireball;
    public float Force = 1f;
    private IEnumerator coroutine;
    private WaitForSeconds delay = new WaitForSeconds(1f);
    private Animator m_animator;

    
    private void Awake()
    {
        m_animator = GetComponent<Animator>();
        Fire();
    }
    public void CeaseFire()
    {
        if (coroutine != null)
            StopCoroutine(coroutine);
    }
    public void Fire()
    {
        if (coroutine != null)
            StopCoroutine(coroutine);
        coroutine = StartEmit();
        StartCoroutine(coroutine);
    }
    private IEnumerator StartEmit()
    {
        yield return new WaitForSeconds(0.2f);
        while (true)
        {
            EmitBall();
            yield return delay;
        }
    }
    public void EmitBall()
    {
        //m_animator.SetTrigger("Fire");
        GameObject temp = GameObject.Instantiate(Fireball, EmitPoint.position, Quaternion.Euler(0f, 180f, 0f), transform);
        temp.GetComponent<Rigidbody2D>().AddForce(Force * new Vector2(1f, 0f), ForceMode2D.Impulse);
    }
}
