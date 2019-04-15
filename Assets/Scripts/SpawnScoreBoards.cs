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
            CoopScore = Instantiate(CoopScore);
            CoopScore.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
            CoopScore.text = "Score: " + GameMaster.instance.g_coopScore.ToString();
        }
        else
        {
            //Initialize and show player 1 score
            Player1Score = Instantiate(Player1Score);
            Player1Score.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
            Player1Score.text = "Score: " + GameMaster.instance.g_player1Score.ToString();

            //initialize and show player 2 score
            Player2Score = Instantiate(Player2Score);
            Player2Score.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
            Player2Score.text = "Score: " + GameMaster.instance.g_player2Score.ToString();

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
            CoopScore.text = "Score: " + GameMaster.instance.g_player1Score.ToString();
        }
        else if (score == "player2")
        {
            GameMaster.instance.g_player2Score += amount;
            CoopScore.text = "Score: " + GameMaster.instance.g_player2Score.ToString();
        }
    }
}