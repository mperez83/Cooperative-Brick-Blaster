using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VersusHandler : MonoBehaviour
{
    public int player1Score = 0;
    public int player2Score = 0;
    bool gameEnded;

    float versusTimerLength = 60;
    float versusTimer;
    Image versusTimerUI;

    void Start()
    {
        versusTimer = versusTimerLength;
        GameObject.FindGameObjectWithTag("Canvas").transform.Find("Versus Timer").gameObject.SetActive(true);
        versusTimerUI = GameObject.FindGameObjectWithTag("Canvas").transform.Find("Versus Timer").GetComponent<Image>();
        
    }

    void Update()
    {
        versusTimer -= Time.deltaTime;
        versusTimerUI.fillAmount = versusTimer / versusTimerLength;

        if (!gameEnded)
        {
            if (versusTimer <= 0)
            {
                versusTimer = 0;
                gameEnded = true;
                GameObject.FindGameObjectWithTag("Results").transform.Find("Results").GetComponent<Results>().showResults();
            }
        }
    }

    public void UpdateScoreText()
    {
        GameObject scoreboard = GameObject.FindGameObjectWithTag("Scoreboard");

        if (scoreboard == null)
        {
            print("panic");
            return;
        }
        else
        {
            scoreboard.transform.Find("Player1Score").GetComponent<TextMeshProUGUI>().text = "Score: " + player1Score.ToString();
            scoreboard.transform.Find("Player2Score").GetComponent<TextMeshProUGUI>().text = "Score: " + player2Score.ToString();
        }
    }
}