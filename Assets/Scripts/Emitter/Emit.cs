using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class Emit : MonoBehaviour
{
    public GameObject Fireball;
    private IEnumerator coroutine;
    private WaitForSeconds delay = new WaitForSeconds(0.8f);
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
        EmitBall();
        yield return delay;
    }
    public void EmitBall()
    {
        //m_animator.SetTrigger("Fire");
        GameObject temp = GameObject.Instantiate(Fireball, transform.position, Quaternion.identity, transform);
        temp.GetComponent<Rigidbody2D>().AddForce(new Vector2(1f, 1f), ForceMode2D.Impulse);
    }
}
