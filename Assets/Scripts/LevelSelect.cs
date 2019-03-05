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
    
    public void Lvl1(){
        LevelSelected = "Level1";
        Test.text = "Selected Level: " + LevelSelected;
    }

    public void Lvl2(){
        LevelSelected = "Level2";
        Test.text = "Selected Level: " + LevelSelected;
    }

    public void Lvl3(){
        LevelSelected = "Level3";
        Test.text = "Selected Level: " + LevelSelected;
    }

    public void SelectLevel(){
        SceneManager.LoadScene(LevelSelected);
    }

    public void BackToMainMenu(){
        SceneManager.LoadScene("MainMenu");
    }

    //Create new script/add to level# scripts
    // public void backToLevelSelect(){
    //     SceneManager.LoadScene("LevelSelect");
    // }
    
}
