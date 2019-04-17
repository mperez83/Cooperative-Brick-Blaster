using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnScoreBoards : MonoBehaviour
{
    public Text CoopScore, Player1Score, Player2Score;

    void Start()
    {
        if (GameMaster.instance.g_coop)
        {
            //initialize and show coop score
            CoopScore.gameObject.SetActive(true);
        }
        else
        {
            //Initialize and show player 1 score
            Player1Score.gameObject.SetActive(true);

            // //initialize and show player 2 score
            Player2Score.gameObject.SetActive(true);
        }
    }



    //call this method in other scripts to update the score, arguments are a string to which the score is added onto, and the amount/points added to the score
    public void UpdateScores(string score, int amount)
    {
        if (score == "coop")
        {
            GameMaster.instance.g_coopScore += amount;
            CoopScore.text = "Score: " + GameMaster.instance.g_coopScore.ToString();
        }
        else if (score == "player1")
        {
            GameMaster.instance.g_player1Score += amount;
            Player1Score.text = "Score: " + GameMaster.instance.g_player1Score.ToString();
        }
        else if (score == "player2")
        {
            GameMaster.instance.g_player2Score += amount;
            Player2Score.text = "Score: " + GameMaster.instance.g_player2Score.ToString();
        }
    }
}