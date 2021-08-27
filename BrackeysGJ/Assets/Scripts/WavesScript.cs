using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WavesScript : MonoBehaviour
{
    AudioSource wavesaudio;
    // bool keepFadeingIn;
    // bool keepFadeingOut;
    int currentVolume = 0;
    [SerializeField] float lerpSpeed = 0.25f;

    private void Start()
    {
        wavesaudio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        wavesaudio.volume = Mathf.Lerp(wavesaudio.volume, currentVolume, Time.deltaTime * lerpSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // wavesaudio.Play();
            // wavesaudio.loop = true;
            // StartCoroutine("FadeIn(wavesaudio, .03f, 1f)");
            currentVolume = 1;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // StartCoroutine("FadeOut(wavesaudio, 3f)");
            // wavesaudio.Stop();
            // wavesaudio.loop = false;
            currentVolume = 0;
        }
    }

    // public IEnumerator FadeIn(AudioSource track, float speed, float maxVol)
    // {
    //     keepFadeingIn = true;
    //     keepFadeingOut = false;
    //     track.volume = 0;
    //     float audioVol = track.volume;

    //     while (audioVol < maxVol && keepFadeingIn)
    //     {
    //         audioVol += speed;
    //         track.volume = audioVol;
    //         yield return new WaitForSeconds(3f);
    //     }

    // }



    // public IEnumerator FadeOut(AudioSource track, float speed)
    // {
    //     keepFadeingIn = false;
    //     keepFadeingOut = true;
    //     float audioVol = track.volume;

    //     while (audioVol >= speed && keepFadeingOut)
    //     {
    //         audioVol -= speed;
    //         track.volume = audioVol;
    //         yield return new WaitForSeconds(0.1f);
    //     }
    // }
}
