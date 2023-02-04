using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    public Image FadeImage;
    private IEnumerator _coroutine;

    [ContextMenu("FadeIn")]
    public void FadeIn()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);
        _coroutine = FadeTo(1f);
        StartCoroutine(_coroutine);
    }
    [ContextMenu("FadeOut")]
    public void FadeOut()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);
        _coroutine = FadeTo(0f);
        StartCoroutine(_coroutine);
    }
    private IEnumerator FadeTo(float target)
    {
        float init = FadeImage.color.a;
        Color initC = FadeImage.color;
        Color targetC = initC;
        targetC.a = target;
        float delta = target - init >= 0 ? 0.025f : -0.025f;
        float originGap = Mathf.Abs(target - init);
        while(Mathf.Abs(target - init) > 0.03f)
        {
            FadeImage.color = Color.Lerp(initC, targetC, 1 - Mathf.Abs(target - init) / originGap);
            init += delta;
            yield return null;
        }
        FadeImage.color = targetC;
    }
}
