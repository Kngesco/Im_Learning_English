using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class DiscoverManager : MonoBehaviour
{
    [SerializeField]
    GameObject letterPrefab;
    
    [SerializeField]
    Transform letterHolder;

    [SerializeField]
    AudioClip[] letterSound;

    string[] letter = { "a", "b", "c", "d", "e", "f", "g" };

    int letterPiece;


    private void Start()
    {
        LetterSort();
        StartCoroutine(LetterShowRoutine());
    }

    void LetterSort()
    {
        for (int i = 0; i < letter.Length; i++)
        {
            GameObject letterObje = Instantiate(letterPrefab, letterPrefab.transform.position, Quaternion.identity);

            letterObje.transform.GetChild(0).GetComponent<Text>().text = letter[i];
            letterObje.name = letter[i];
            letterObje.transform.SetParent(letterHolder);

            letterHolder.localPosition = new Vector3(470, 0, 0);
        }
        
    }


    IEnumerator LetterShowRoutine()
    {
        while (letterPiece < letterSound.Length)
        {
            letterHolder.GetChild(letterPiece).GetComponent<CanvasGroup>().DOFade(1,0.5f);
            letterHolder.GetChild(letterPiece).GetComponent<RectTransform>().DOScale(1,0.5f).SetEase(Ease.OutBack);

            letterHolder.GetChild(letterPiece).GetComponent<AudioSource>().clip = letterSound[letterPiece];



            yield return new WaitForSeconds(0.2f);
            letterPiece++;

            
        }
        
    }

}












