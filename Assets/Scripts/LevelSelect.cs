using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelSelect : MonoBehaviour
{
    public Button startButton;
    public Toggle coop;
    public TextMeshProUGUI coopToggleText;
    public Image preview;
    //sprites for preview. keep adding as more maps are added.
    public Sprite previewDefault;
    public Sprite previewMap1;
    public Sprite previewMap2;
    public Sprite previewMap3;

    
    void Start(){
        //start out with no level selected and reset to none when re-entering level select
        GameMaster.instance.LevelSelected = "None";
        //start with default image preview sprite
        preview.sprite = previewDefault;
        //start out with grayed out start button
        startButton.interactable = false;
    }

    
    void Update(){
        //update start button if a level/map is selected
        if(GameMaster.instance.LevelSelected != "None"){
            startButton.interactable = true;
        }
        //update coop toggle & text
        
        if (coop.isOn)
        {
            coopToggleText.text = "Mode:\nCo-op";
            //GameMaster.instance.g_coop = true;
        }
        else
        {
            coopToggleText.text = "Mode:\nVersus";
            //GameMaster.instance.g_coop = false;
        }
         
        //update preview image
        if(GameMaster.instance.LevelSelected == "Map_1"){
            preview.sprite = previewMap1;
        }
        else if(GameMaster.instance.LevelSelected == "Map_2"){
            preview.sprite = previewMap2;
        }
        else if(GameMaster.instance.LevelSelected == "Map_3"){
            preview.sprite = previewMap3;
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