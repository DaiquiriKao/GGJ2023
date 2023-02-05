using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TriggerCallback : MonoBehaviour
{
    private Action<Collider2D> callback;

    public void SetCallback(Action<Collider2D> callback)
    {
        this.callback = callback;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        callback?.Invoke(collision);
    }
}
