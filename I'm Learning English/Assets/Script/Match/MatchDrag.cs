using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;

public class MatchDrag : MonoBehaviour,IBeginDragHandler,IEndDragHandler,IDragHandler
{
    CanvasGroup canvasGroup;
    RectTransform rectTransform;

    public bool settle;

    Vector3 targetPos;

    AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        audioSource.Play();
        settle = false;
        targetPos = rectTransform.anchoredPosition;
        canvasGroup.alpha = .8f;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta;

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!settle)
        {
            rectTransform.DOAnchorPos(targetPos, .5f);
            canvasGroup.blocksRaycasts = true;
        }
        else
        {
            canvasGroup.blocksRaycasts = false;
            canvasGroup.alpha = 1f;

        }
    }

   
}
