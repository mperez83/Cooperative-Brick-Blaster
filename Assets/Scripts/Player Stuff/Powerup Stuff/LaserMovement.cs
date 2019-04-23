using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserMovement : MonoBehaviour
{
    public float travelSpeed = 20;
    [HideInInspector]
    public int playerNum;
    GameObject gameController;

    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController");
    }

    void Update()
    {
        Vector2 moveAmount = new Vector2(0, travelSpeed);
        transform.Translate(moveAmount * Time.deltaTime);

        if (transform.position.y > GameMaster.instance.screenTopEdge)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Brick"))
        {
            if (GameMaster.instance.g_coop)
            {
                gameController.GetComponent<CoopHandler>().coopScore += 100;
                gameController.GetComponent<CoopHandler>().UpdateScoreText();
            }
            else
            {
                if (playerNum == 1)
                    gameController.GetComponent<VersusHandler>().player1Score += 100;
                else if (playerNum == 2)
                    gameController.GetComponent<VersusHandler>().player2Score += 100;

                gameController.GetComponent<VersusHandler>().UpdateScoreText();
            }

            if (other.transform.parent.childCount == 1)
            {
                GameObject.FindGameObjectWithTag("Results").transform.Find("Results").GetComponent<Results>().showResults();
            }

            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}