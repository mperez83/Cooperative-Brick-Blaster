using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Results : MonoBehaviour
{
    public Text CoopScore;
    public Text VsScoreP1;
    public Text VsScoreP2;
    public Text title;
    public GameObject results;

    // call this function to show results screen
    public void showResults()
    {
        Time.timeScale = 0f;
        results.SetActive(true);

        GameObject gameController = GameObject.FindGameObjectWithTag("GameController");

        if (GameMaster.instance.g_coop == true)
        {
            CoopScore.gameObject.SetActive(true);
            CoopScore.text = "Final score: " + gameController.GetComponent<CoopHandler>().coopScore.ToString();
        }
        else
        {
            VsScoreP1.gameObject.SetActive(true);
            VsScoreP2.gameObject.SetActive(true);

            int p1Score = gameController.GetComponent<VersusHandler>().player1Score;
            int p2Score = gameController.GetComponent<VersusHandler>().player2Score;

            VsScoreP1.text = p1Score.ToString();
            VsScoreP2.text = p2Score.ToString();

            if (p1Score > p2Score)
                title.text = "Player 1 Wins!";
            else if (p1Score < p2Score)
                title.text = "Player 2 Wins!";
            else
                title.text = "Tie!";
        }
    }

    public void RestartLevel(string CurrentLevel)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(CurrentLevel);
    }

    public void ReturnToLevelSelect()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("LevelSelect");
    }
}
