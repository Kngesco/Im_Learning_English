using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Star_Controller : MonoBehaviour
{

    [SerializeField]
    GameObject fullStar1, fullStar2, fullStar3;

    [SerializeField]
    GameObject flarestar1, flarestar2, flarestar3;


    public void StarFlare(int incomingValue)
    {
        if (incomingValue<12)
        {
            flarestar1.GetComponent<RectTransform>().DOScale(1, .2f).SetEase(Ease.OutBack);
            fullStar1.GetComponent<Image>().fillAmount = incomingValue / 12f;
        }
        else if (incomingValue>=12 && incomingValue<24)
        {
            flarestar2.GetComponent<RectTransform>().DOScale(1, .2f).SetEase(Ease.OutBack);
            fullStar2.GetComponent<Image>().fillAmount = (incomingValue-12) / 12f;
        }
        else if (incomingValue >= 24 && incomingValue < 36)
        {
            flarestar3.GetComponent<RectTransform>().DOScale(1, .2f).SetEase(Ease.OutBack);
            fullStar3.GetComponent<Image>().fillAmount = (incomingValue-24) / 12f;
        }


        Invoke("StarFlareStop", .5f);

    }
    void StarFlareStop()
    {
        flarestar1.GetComponent<RectTransform>().DOScale(0, .2f);
        flarestar2.GetComponent<RectTransform>().DOScale(0, .2f);
        flarestar3.GetComponent<RectTransform>().DOScale(0, .2f);
    }




}
