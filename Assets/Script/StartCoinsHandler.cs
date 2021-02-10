using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCoinsHandler : MonoBehaviour
{

    public GameObject[] stars;
    private int coinsCount;



    void Start()
    {

        coinsCount = GameObject.FindGameObjectsWithTag("coin").Length;

    }


   public void starsAcheive()
    {
        int coinsLeft = GameObject.FindGameObjectsWithTag("coin").Length;

        int coinsCollected = coinsCount - coinsLeft;

        float percentage = float.Parse(coinsCollected.ToString()) / float.Parse(coinsCount.ToString()) * 100f;

        print(percentage);

        if (percentage >= 33f && percentage < 66)
        {
            //gameObject[0].set
            stars[0].SetActive(true);

        }
        else if (percentage >= 66 && percentage < 70) {

            stars[0].SetActive(true);
            stars[1].SetActive(true);
        } else if (percentage < 33) {

        } else
        {
            stars[0].SetActive(true);
            stars[1].SetActive(true);
            stars[2].SetActive(true);
        }


    }
}
