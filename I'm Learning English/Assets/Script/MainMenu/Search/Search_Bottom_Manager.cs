using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Search_Bottom_Manager : MonoBehaviour
{
    AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void MakeNoise()
    {
        if (audioSource)
            audioSource.Play();

    }
}
