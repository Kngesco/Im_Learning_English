using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindButtonManager : MonoBehaviour
{
    AudioSource audioSource;

    public bool correct;


    AudioSource[] AllSoundSources;

    FindControlManager findControlManager;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        findControlManager = Object.FindObjectOfType<FindControlManager>();
    }
    public void SoundOpen()
    {
        if (audioSource && findControlManager.buttonTake)
        {
            AllSoundStop();
            audioSource.Play();
        }
        if (correct && findControlManager.buttonTake)
        {
            AllSoundStop();
            audioSource.Play();
           
        }
    }
    void AllSoundStop()
    {
        AllSoundSources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];

        foreach (AudioSource audio in AllSoundSources)
        {
            audio.Stop();
        }
    }




}
