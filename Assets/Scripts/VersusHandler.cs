﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VersusHandler : MonoBehaviour
{
    public int player1Score = 0;
    public int player2Score = 0;

    void Start()
    {

    }

    void Update()
    {

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
            scoreboard.transform.Find("Player1Score").GetComponent<Text>().text = "Score: " + player1Score.ToString();
            scoreboard.transform.Find("Player2Score").GetComponent<Text>().text = "Score: " + player2Score.ToString();
        }
    }
}