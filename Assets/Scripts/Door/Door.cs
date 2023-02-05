using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private float doorOpenTime;
    [SerializeField] private Collider2D collider;

    public void Open()
    {
        StartCoroutine(OpenDoor());
    }

    private IEnumerator OpenDoor()
    {
        anim.SetTrigger("Open");
        yield return new WaitForSeconds(doorOpenTime);
        OnOpened();
    }

    public void OnOpened()
    {
        collider.enabled = false;
    }
}
