using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Initialize : MonoBehaviour
{
    public Fade fade;
    public UnityEvent OnInitialize;
    public UnityEvent OnStartGame;

    public void OnEnable()
    {
        OnInitialize.Invoke();
        StartCoroutine(StartGame());
    }
    private IEnumerator StartGame()
    {
        fade.FadeOut();
        yield return new WaitForSeconds(0.5f);
        OnStartGame.Invoke();
    }
}
