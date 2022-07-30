using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class FindControlManager : MonoBehaviour
{
    int chapterNumber;

    AudioClip clip;

    public bool buttonTake;

    int letterNumber;

    AudioSource[] AllSoundSources;

    FindControlManager findControlManager;



    private void Start()
    {
        StartCoroutine(LetterRoutine());
        findControlManager = Object.FindObjectOfType<FindControlManager>();
    }

    IEnumerator LetterRoutine()
    {
        GameObject obje = this.transform.GetChild(chapterNumber).gameObject;

        SoundTakeOff();

        while(letterNumber <3)
        {
            obje.transform.GetChild(letterNumber).GetComponent<CanvasGroup>().DOFade(1, .1f);
            yield return new WaitForSeconds(.2f);
            letterNumber++;
        }
    }
    void SoundTakeOff()
    {
        buttonTake = false;

        Transform obje = this.gameObject.transform.GetChild(chapterNumber);

        clip = obje.GetComponent<AudioSource>().clip;

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
