﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpawnScoreBoards : MonoBehaviour
{
    public TextMeshProUGUI CoopScore, Player1Score, Player2Score;
    GameObject gameController;

    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController");

        if (GameMaster.instance.g_coop)
        {
            CoopScore.gameObject.SetActive(true);
        }
        else
        {
            Player1Score.gameObject.SetActive(true);
            Player2Score.gameObject.SetActive(true);
        }
    }
}