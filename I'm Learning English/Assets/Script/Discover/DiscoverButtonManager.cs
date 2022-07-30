using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DiscoverButtonManager : MonoBehaviour
{
    [SerializeField]
    AudioSource audioSource;

    Transform letterPanel;

    GameObject obje;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();

        letterPanel = GameObject.Find("AllLetter").transform;
    }

    
    public void AudioOn()
    {
        if (audioSource!=null)
        {
            audioSource.Play();

            obje = this.gameObject;

            Invoke("ScreenLetterOn", 1f);

        }
    }

    void ScreenLetterOn()
    {
        for (int i = 0; i < letterPanel.childCount; i++)
        {
            if (obje.name == letterPanel.GetChild(i).gameObject.name)
            {
                obje.transform.parent.gameObject.SetActive(false);
                letterPanel.GetChild(i).GetComponent<RectTransform>().DOScale(1, 0.4f).SetEase(Ease.OutBack);

                letterPanel.GetChild(i).GetComponent<LetterManager>().AllCircleOn();

                break;
            }
        }
    }
}
