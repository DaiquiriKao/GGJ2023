using Mono.Cecil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioFade : MonoBehaviour
{
    private AudioSource m_Source;

    public void CloseAudio()
    {
        m_Source = GetComponent<AudioSource>();
        StartCoroutine(Close());
    }
    private IEnumerator Close()
    {
        float init = m_Source.volume;
        for (float f = 0f; f <= 1f; f += Time.deltaTime)
        {
            m_Source.volume = Mathf.Lerp(init, 0, f);
            yield return null;
        }
        m_Source.volume = 0f;
        yield return null;
        m_Source.Stop();
    }
}
