using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class SceneSwitcher : MonoBehaviour
{
    public string SceneName;
    public UnityEvent OnChangeScene;
    public Fade fade;

    public void ChangeScene()
    {
        StartCoroutine(Change());
    }
    IEnumerator Change()
    {
        fade.FadeIn();
        yield return new WaitForSeconds(1.2f);
        OnChangeScene.Invoke();
        SceneManager.LoadScene(SceneName);
    }
}
