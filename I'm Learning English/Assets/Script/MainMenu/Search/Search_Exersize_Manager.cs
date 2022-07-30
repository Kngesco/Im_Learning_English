using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
public class Search_Exersize_Manager : MonoBehaviour
{
    int chapterNumber;

    public bool buttonTake;

    AudioClip clip;

    AudioSource[] AllSoundSources;

    Star_Controller star_Controller;


    private void Awake()
    {
        star_Controller = Object.FindObjectOfType<Star_Controller>();
    }

    private void Start()
    {
        buttonTake = false;

        AllSoundStop();

        SoundTakeOff();
    }






    public void PanelMove()
    {
        if (chapterNumber >= 36)
        {
            return;
        }
        chapterNumber++;

        star_Controller.StarFlare(chapterNumber);
        this.gameObject.GetComponent<RectTransform>().DOLocalMoveX(this.gameObject.GetComponent<RectTransform>().localPosition.x - 1280f,.5f);
        //AllSoundStop();
        SoundTakeOff();

    }


    void SoundTakeOff()
    {
        buttonTake = false;

        Transform obje = this.gameObject.transform.GetChild(chapterNumber);

        for (int i = 0; i < 3; i++)
        {
            if (!obje.GetChild(i).GetComponent<Search_Exersize>().correct)
            {
                clip = obje.GetChild(i).GetComponent<AudioSource>().clip;
                break;
            }
            

        }
        AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position);

        Invoke("TakeButton", clip.length);
    }

    void TakeButton()
    {
        buttonTake = true;
    }

    void AllSoundStop()
    {
        AllSoundSources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];

        foreach (AudioSource audio in AllSoundSources)
        {
            audio.Stop();
        }
    }
    public void AgainSound()
    {
        AllSoundStop();
        SoundTakeOff();
    }
    public void MainScreenTurnBack()
    {
        SceneManager.LoadScene("Main_Menu");
    }
}
