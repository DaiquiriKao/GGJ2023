using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillSelf : MonoBehaviour
{
    public float StayTime = 1f;
    private void OnEnable()
    {
        Invoke("DestroySelf", StayTime);
    }
    private void DestroySelf()
    {
        Destroy(gameObject);
    }
}
