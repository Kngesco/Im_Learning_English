using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Family_Not_Manager : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{

    [SerializeField]
    Text holdForTwoSecondsTxt;

    [SerializeField]
    Image Circle;

    [SerializeField]
    GameObject FamilyNotİmg;

    bool buttonHold;

    float holdTime;
    float totalHoldTime = 2f;

    public void OnPointerDown(PointerEventData eventData)
    {
        buttonHold = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        buttonHold = false;
    }


    void Update()
    {
        if (buttonHold)
        {
            holdForTwoSecondsTxt.gameObject.SetActive(true);

            holdTime += Time.deltaTime;

            if (holdTime >= totalHoldTime)
            {
                buttonHold = false;
                holdForTwoSecondsTxt.gameObject.SetActive(false);
                FamilyNotİmg.gameObject.SetActive(true);
            }

            Circle.fillAmount = holdTime / totalHoldTime;

        }

        if (!buttonHold)
        {
            holdTime -= Time.deltaTime;

            if (holdTime <= 0)
            {
                holdTime = 0;
            }


            holdForTwoSecondsTxt.gameObject.SetActive(false);
            Circle.fillAmount = holdTime / totalHoldTime;
        }

        


    }

    public void FamilyNotClouse()
    {
        holdTime = 0;
        buttonHold = false;

        FamilyNotİmg.SetActive(false);
    }
}
