using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTimeSetActive : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private float onActiveTime;
    [SerializeField] private bool active;

    void Start()
    {
        StartCoroutine(StartCount());
    }

    private IEnumerator StartCount()
    {
        yield return new WaitForSeconds(onActiveTime);
        target.SetActive(active);
    }
}
