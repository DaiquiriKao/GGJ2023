using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private float doorOpenTime;

    [ContextMenu("Test Open")]
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
        gameObject.SetActive(false);
    }
}
