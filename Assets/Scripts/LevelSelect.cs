using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    private string LevelSelected = "None";
    public Text Test;
    public Button startButton, backButton, Level1, Level2, Level3;

    //start out with grayed out start button
    void Start(){
        startButton.interactable = false;
    }

    //make start button clickable when a level is selected
    void Update(){
        if(LevelSelected != "None"){
            startButton.interactable = true;
        }
    }

    public void Lvl1()
    {
        LevelSelected = "Map_1";
        Test.text = "Selected Level: " + LevelSelected; // for testing purposes

    }

    public void Lvl2()
    {
        LevelSelected = "Map_2";
        Test.text = "Selected Level: " + LevelSelected;// for testing purposes
    }

    public void Lvl3()
    {
        LevelSelected = "Map_3";
        Test.text = "Selected Level: " + LevelSelected;// for testing purposes
    }

    public void SelectLevel()
    {
        SceneManager.LoadScene(LevelSelected);
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}