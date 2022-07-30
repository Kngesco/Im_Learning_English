using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Search_Exersize : MonoBehaviour
{
    AudioSource audioSource;

    public bool correct;

    Search_Exersize_Manager search_Exersize_Manager;

    AudioSource[] AllSoundSources;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        search_Exersize_Manager = Object.FindObjectOfType<Search_Exersize_Manager>();
    }
    public void SoundOpen()
    {
        if (audioSource && search_Exersize_Manager.buttonTake)
        {
            AllSoundStop();
            audioSource.Play();
        }
        if (correct && search_Exersize_Manager.buttonTake)
        {
            AllSoundStop();
            audioSource.Play();
            search_Exersize_Manager.PanelMove();
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
