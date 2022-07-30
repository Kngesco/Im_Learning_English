using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MatchDrop : MonoBehaviour,IDropHandler
{
    [SerializeField]
    string letter;

    GameObject transportedLetter;

    public void OnDrop(PointerEventData eventData)
    {
        transportedLetter = eventData.pointerDrag.gameObject;

        if (letter == transportedLetter.transform.GetChild(0).GetComponent<Text>().text)
        {
            transportedLetter.GetComponent<MatchDrag>().settle = true;
            transportedLetter.transform.position = this.transform.position;
            transportedLetter.transform.rotation = this.transform.rotation;
        }

    }

    
}
