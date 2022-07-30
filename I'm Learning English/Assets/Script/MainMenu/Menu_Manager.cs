using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class Menu_Manager : MonoBehaviour
{
    [SerializeField]
    GameObject logoİmage;
    void Start()
    {
        OpenLogo();
    }

   void OpenLogo()
    {
        logoİmage.GetComponent<CanvasGroup>().DOFade(1,1f);
        logoİmage.GetComponent<RectTransform>().DOScale(1,0.5f);
    }

    public void chanceScreen(string screenName)
    {
        SceneManager.LoadScene(screenName);
    }
}
