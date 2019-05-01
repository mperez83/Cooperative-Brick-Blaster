using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoopHandler : MonoBehaviour
{
    public int coopScore = 0;
    public int coopLives = 3;

    void Start()
    {

    }

    void Update()
    {

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
            scoreboard.transform.Find("CoopScore").GetComponent<TextMeshProUGUI>().text = "Score: " + coopScore.ToString();
        }
    }
}