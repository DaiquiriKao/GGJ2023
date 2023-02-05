using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Crab : MonoBehaviour
{
    private float speed = 1.0f;
    private Animator m_animator;
    public WordHolder holder;
    private WaitForSeconds _idle = new WaitForSeconds(0.5f);
    private void OnEnable()
    {
        m_animator = GetComponent<Animator>();
        StartCoroutine(Motion());
    }
    private IEnumerator Motion()
    {
        while (!holder.isSplited)
        {
            speed = 0f;
            m_animator.SetFloat("Speed", speed);
            yield return _idle;
            speed = 0.5f;
            m_animator.SetFloat("Speed", speed);
            for(float f = 0f;f <1f;f+=Time.deltaTime)
            {
                transform.position += new Vector3(speed * Time.deltaTime * 5, 0f, 0f);
                yield return null;
            }
            speed = 0f;
            m_animator.SetFloat("Speed", speed);
            yield return _idle;
            speed = 0.5f;
            m_animator.SetFloat("Speed", speed);
            for(float f = 0f;f <1f;f+=Time.deltaTime)
            {
                transform.position += new Vector3(-speed * Time.deltaTime * 5, 0f, 0f);
                yield return null;
            }
        }
    }
}
