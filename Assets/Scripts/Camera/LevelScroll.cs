using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class LevelScroll : MonoBehaviour
{
    public Vector2[] Levels;
    public int CurrentLevel = 0;
    private IEnumerator coroutine;

    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.G))
    //        MoveUp();
    //    else if(Input.GetKeyDown(KeyCode.F))
    //        MoveDown();
    //}
    public void MoveUp()
    {
        if (CurrentLevel + 1 == Levels.Length)
            return;
        if (coroutine != null)
            StopCoroutine(coroutine);
        coroutine = ScrollLevel(CurrentLevel + 1);
        StartCoroutine(coroutine);
        CurrentLevel++;
    }
    public void MoveDown()
    {
        if(CurrentLevel - 1 < 0)
            return;
        if (coroutine != null)
            StopCoroutine(coroutine);
        coroutine = ScrollLevel(CurrentLevel - 1);
        StartCoroutine(coroutine);
        CurrentLevel--;
    }
    private IEnumerator ScrollLevel(int targetLevel)
    {
        yield return null;
        RectTransform rect = GetComponent<RectTransform>();
        Vector2 minInit = rect.offsetMin;
        //minInit.y *= -1;
        Vector2 maxInit = rect.offsetMax;
        //maxInit.y *= -1;
        //Debug.Log(minInit + " " + maxInit);
        Vector2 minFinal = new Vector2(rect.offsetMin.x, Levels[targetLevel].x);
        Vector2 maxFinal = new Vector2(rect.offsetMax.x, Levels[targetLevel].y);
        for(float f = 0f; f<=1.5f;f+=Time.deltaTime)
        {
            rect.offsetMin = Vector2.Lerp(minInit, minFinal, f / 1.5f);
            rect.offsetMax = Vector2.Lerp(maxInit, maxFinal, f / 1.5f);
            yield return null;
        }
        rect.offsetMin = minFinal;
        rect.offsetMax = maxFinal;
    }
}
