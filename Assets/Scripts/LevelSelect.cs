using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LevelSelect : MonoBehaviour
{
    public Button startButton;
    
    void Start(){
        //start out with no level selected and reset to none when re-entering level select
        GameMaster.instance.LevelSelected = "None";
        
        //start out with grayed out start button
        startButton.interactable = false;
    }
    
    void Update(){
        //update start button if a level/map is selected
        if(GameMaster.instance.LevelSelected != "None"){
            startButton.interactable = true;
        }
    }

    public void SelectLevel()
    {
        SceneManager.LoadScene(GameMaster.instance.LevelSelected);
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}