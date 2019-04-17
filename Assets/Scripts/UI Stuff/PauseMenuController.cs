using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    public string levelSelectScene;
    public GameObject pauseMenu;
    public bool isPaused;

    void Start()
    {

    }

    void Update()
    {
        //for left player press esc key for pause menu; pause menu needs to be turned off by default
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                resumeGame();
            }
            else
            {
                isPaused = true;
                pauseMenu.SetActive(true);
                Time.timeScale = 0f; // can be used to slow down time too
            }
        }
    }

    public void resumeGame()
    {
        isPaused = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void returnToLevelSelect()
    {
        SceneManager.LoadScene(levelSelectScene);
        Time.timeScale = 1f;
    }
}