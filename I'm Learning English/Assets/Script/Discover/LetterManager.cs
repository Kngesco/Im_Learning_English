using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class LetterManager : MonoBehaviour
{
    [SerializeField]
    List<Sprite> circleImg;

    int circlePiece;

    bool press;

    GameObject PictureHolder;
    private void Start()
    {
        PictureHolder = GameObject.Find("PictureHolder");
        AllCircleOff();
    }
    void AllCircleOff()
    {
        circleImg = circleImg.OrderBy(i => Random.value).ToList();

        for (int i = 0; i < this.transform.GetChild(0).childCount; i++)
        {
            this.transform.GetChild(0).GetChild(i).gameObject.SetActive(false);

            if (i%2==0)
            {
                this.transform.GetChild(0).GetChild(i).transform.GetComponent<Image>().sprite = circleImg[0];
            }
            else
            {
                this.transform.GetChild(0).GetChild(i).transform.GetComponent<Image>().sprite = circleImg[1];
            }

        }



    }
    public void AllCircleOn()
    {
        circlePiece = 0;
        StartCoroutine(CircleOnRoutine());
    }
    
    
    IEnumerator CircleOnRoutine()
    {
        while (circlePiece<this.transform.GetChild(0).childCount)
        {
            this.transform.GetChild(0).GetChild(circlePiece).gameObject.SetActive(true);
            circlePiece++;

            yield return new WaitForSeconds(0.8f);
        }

        yield return new WaitForSeconds(0.5f);

        while (circlePiece > 1)
        {
            this.transform.GetChild(0).GetChild(circlePiece - 1).gameObject.SetActive(false);
            circlePiece--;
        }
        press = true;
    }

    private void Update()
    {
        GoOver();   
    }

    void GoOver()
    {
        if (Input.GetMouseButtonDown(0)&& press)
        {
            if (circlePiece<this.transform.GetChild(0).childCount)
            {
                float distance = Vector3.Distance(Input.mousePosition, this.transform.GetChild(0).GetChild(circlePiece).transform.position);

                if (distance<45)
                {
                    this.transform.GetChild(0).GetChild(circlePiece).gameObject.SetActive(true);
                    this.transform.GetChild(0).GetChild(circlePiece).GetChild(0).gameObject.SetActive(true);

                    if (this.transform.GetChild(0).GetChild(circlePiece-1).GetChild(0)!=null)
                    {
                        this.transform.GetChild(0).GetChild(circlePiece - 1).GetChild(0).gameObject.SetActive(false);
                    }
                    circlePiece++;
                }
            }
            if (circlePiece == this.transform.GetChild(0).childCount)
            {
                press = false;
                Invoke("ScreenBack",2f);
            }
        }
    }

    void ScreenBack()
    {
        this.transform.gameObject.SetActive(false);
        PictureHolder.gameObject.SetActive(true);
    }

}
