using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameBGM : MonoBehaviour
{
    AudioSource audioSource;
    public static gameBGM instance;

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
        gameBGM.instance.StopAudio();
    }
    private void StopAudio()
    {
        audioSource.Stop();
    }
}
