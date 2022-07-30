using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
public class Search_Manager : MonoBehaviour
{
    [SerializeField]
    GameObject fadeImg;

    AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void Start()
    {
        //fadeImg.GetComponent<CanvasGroup>().DOFade(0, 1f).OnComplete(StartSound);        
    }

    void StartSound()
    {
        if (audioSource)
        {
            audioSource.Play();
        }
    }

   public void ChanceScreen(string screenName)
    {
        SceneManager.LoadScene(screenName);
    }
}
