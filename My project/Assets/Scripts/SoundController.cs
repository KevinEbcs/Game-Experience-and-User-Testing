using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public IEnumerator FadeOut(AudioSource source, float fadeTime)
    {
        float startVolume = source.volume;

        while (source.volume > 0)
        {
            source.volume -= startVolume * Time.deltaTime / fadeTime;
            yield return null;
        }

        source.Stop();
        source.volume = startVolume;
    }

    public IEnumerator FadeIn(AudioSource source, float fadeTime)
    {
        float targetVolume = source.volume;
        source.volume = 0f;
        source.Play();

        while (source.volume < targetVolume)
        {
            source.volume += targetVolume * Time.deltaTime / fadeTime;
            yield return null;
        }
    }
}
