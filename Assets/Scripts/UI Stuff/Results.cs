﻿using System.Collections;
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
    public void showResults(){
        //pause everything when results screen show
        Time.timeScale = 0f;
        // show results screen overlay
        results.SetActive(true); 
        //set scores
        CoopScore.text += GameMaster.instance.g_coopScore.ToString();
        VsScoreP1.text += GameMaster.instance.g_player1Score.ToString();
        VsScoreP2.text += GameMaster.instance.g_player2Score.ToString();
        //show score if in coop mode
        if(GameMaster.instance.g_coop == true){
            title.text = "Level Cleared";
            CoopScore.gameObject.SetActive(true);
        }
        //show score if in vs mode
        else{
            VsScoreP1.gameObject.SetActive(true);
            VsScoreP2.gameObject.SetActive(true);
            //shows which player won
            if(GameMaster.instance.g_player1Score > GameMaster.instance.g_player2Score){
                title.text = "Player 1 Wins!";
            }
            else if (GameMaster.instance.g_player1Score < GameMaster.instance.g_player2Score){
                title.text = "Player 2 Wins!";
            }
            else{
                title.text = "Tie!";
            }
        }
    }

    //when buttons are pressed, game unpauses
    public void retry(string CurrentLevel){
        Time.timeScale = 1f;
        SceneManager.LoadScene(CurrentLevel);
    }

    public void goBackToLvlSlct(){
        Time.timeScale = 1f;
        SceneManager.LoadScene("LevelSelect");
    }
}