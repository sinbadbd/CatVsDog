using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIHandler : MonoBehaviour
{

    public static UIHandler instance;
    public GameObject LavelDialog;
    public Text LevelStatus;
    public Text ScoreText;
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

   public void ShowLevelDialog(string status, string score)
    {
        GetComponent<StartCoinsHandler>().starsAcheive();

        LavelDialog.SetActive(true);
        LevelStatus.text = status;
        ScoreText.text = score.ToString();
    }
}
