using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WavesScript : MonoBehaviour
{
    private string theCollider;
    public AudioSource wavesaudio;
    bool keepFadeingIn;
    bool keepFadeingOut;

    private void OnTriggerEnter(Collider other)
    {
        theCollider = other.tag;

        if (theCollider == "Player")
        {
            wavesaudio.Play();
            wavesaudio.loop = true;
            StartCoroutine("FadeIn(wavesaudio, .03f, 1f)");

        }
    }


    private void OnTriggerExit(Collider other)
    {
        theCollider = other.tag;

        if (theCollider == "Player")
        {


            StartCoroutine("FadeOut(wavesaudio, 3f)");
            wavesaudio.Stop();
            wavesaudio.loop = false;


        }
    }

    public IEnumerator FadeIn(AudioSource track, float speed, float maxVol)
    {
        keepFadeingIn = true;
        keepFadeingOut = false;
        track.volume = 0;
        float audioVol = track.volume;

        while (audioVol < maxVol && keepFadeingIn)
        {
            audioVol += speed;
            track.volume = audioVol;
            yield return new WaitForSeconds(3f);
        }

    }



    public IEnumerator FadeOut(AudioSource track, float speed)
    {
        keepFadeingIn = false;
        keepFadeingOut = true;
        float audioVol = track.volume;

        while (audioVol >= speed && keepFadeingOut)
        {
            audioVol -= speed;
            track.volume = audioVol;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
