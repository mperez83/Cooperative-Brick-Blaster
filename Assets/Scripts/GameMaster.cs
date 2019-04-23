using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{
    public static GameMaster instance;

    [HideInInspector]
    public bool g_coop = false;
    [HideInInspector]
    public int g_coopScore = 0;
    [HideInInspector]
    public int g_coopLives = 3;
    [HideInInspector]
    public int g_player1Score = 0;
    [HideInInspector]
    public int g_player2Score = 0;

    [HideInInspector]
    public float screenTopEdge;
    [HideInInspector]
    public float screenBottomEdge;
    [HideInInspector]
    public float screenLeftEdge;
    [HideInInspector]
    public float screenRightEdge;



    void Awake()
    {
        if (instance != null && instance != this)
            Destroy(gameObject);
        else
            instance = this;
        DontDestroyOnLoad(this);

        screenTopEdge = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, -(Camera.main.transform.position.z))).y;
        screenBottomEdge = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, -(Camera.main.transform.position.z))).y;
        screenLeftEdge = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, -(Camera.main.transform.position.z))).x;
        screenRightEdge = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, -(Camera.main.transform.position.z))).x;
    }

    void Update()
    {
        //Constantly update the screen bounds (could be performance taxing?)
        screenTopEdge = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, -(Camera.main.transform.position.z))).y;
        screenBottomEdge = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, -(Camera.main.transform.position.z))).y;
        screenLeftEdge = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, -(Camera.main.transform.position.z))).x;
        screenRightEdge = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, -(Camera.main.transform.position.z))).x;
    }

    public void ResetLevelData()
    {
        g_coopLives = 3;
        g_coopScore = 0;
        g_player1Score = 0;
        g_player2Score = 0;
    }

    public void UpdateScoreText()
    {
        GameObject scoreboard = GameObject.FindGameObjectWithTag("Scoreboard");

        if (scoreboard == null)
        {
            print("panic");
            return;
        }
        else
        {
            if (g_coop)
            {
                scoreboard.transform.Find("CoopScore").GetComponent<Text>().text = "Score: " + g_coopScore.ToString();
            }
            else
            {
                scoreboard.transform.Find("Player1Score").GetComponent<Text>().text = "Score: " + g_player1Score.ToString();
                scoreboard.transform.Find("Player2Score").GetComponent<Text>().text = "Score: " + g_player2Score.ToString();
            }
        }
    }
}