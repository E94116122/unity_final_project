using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class winBGM : MonoBehaviour
{
    AudioSource audioSource;
    public static winBGM instance;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlayAudio();
    }

    void PlayAudio()
    {
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }
    public void PlayBGM()
    {
        PlayAudio();
    }
    public void StopBGM()
    {
        winBGM.instance.StopAudio();
    }
    private void StopAudio()
    {
        audioSource.Stop();
    }
}
