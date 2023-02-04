using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class IntroManager : MonoBehaviour
{
    [SerializeField] private float introSceneAnimTime;
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
        yield return new WaitForSeconds(introSceneAnimTime);
        title.SetActive(true);
        yield return new WaitForSeconds(titleAnimTime);
        startBtn.interactable = true;
    }

    public void OnClickStartButton()
    {
        if (!isClicked)
        {
            //TODO: Move To Game Scene
            Debug.Log("Enter Game Scene");
        }
    }

    public void OnClickQuitButton()
    {
        Application.Quit();
    }
}
