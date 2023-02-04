using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.Universal;

public class IntroManager : MonoBehaviour
{
    [SerializeField] private float introSceneAnimTime;
    [SerializeField] private float onSinkTime;
    [SerializeField] private Color secondColor;
    [SerializeField] private Light2D globalLight;
    [SerializeField] private GameObject title;
    [SerializeField] private float titleAnimTime;
    [SerializeField] private Button startBtn;
    [SerializeField] private Button quitBtn;

    private bool isClicked;

    private void Start()
    {
        startBtn.interactable = false;
        quitBtn.interactable = false;
        StartCoroutine(ShowIntroAnim());
    }

    private IEnumerator ShowIntroAnim()
    {
        yield return new WaitForSeconds(onSinkTime);
        var num = 0f;
        var previousColor = globalLight.color;
        var remainTime = (introSceneAnimTime - onSinkTime);
        while(num < 1f)
        {
            num += 0.02f;
            var color = Color.Lerp(previousColor, secondColor, num);
            Debug.Log(color);
            globalLight.color = color;
            yield return null;
            Debug.Log(num);
        }
        yield return new WaitForSeconds(remainTime);
        globalLight.color = secondColor;
        
        title.SetActive(true);
        yield return new WaitForSeconds(titleAnimTime);
        startBtn.interactable = true;
        quitBtn.interactable = true;
    }

    public void OnClickStartButton()
    {
        if (!isClicked)
        {
            Debug.Log("Enter Game Scene");
        }
    }

    public void OnClickQuitButton()
    {
        Application.Quit();
    }
}
