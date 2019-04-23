using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    public enum BallType { Red, Blue, Grey };
    public BallType ballType;
    public GameObject respawnBall;
    Rigidbody2D rb;

    void Start()
    {
        int randX = Random.Range(0, 2);

        Vector2 launchDirection = new Vector2();
        launchDirection.y = 2f;

        if (randX == 0)
        {
            launchDirection.x = -3f;
        }
        else
        {
            launchDirection.x = 3f;
        }

        rb = GetComponent<Rigidbody2D>();
        rb.velocity = launchDirection;

        if (GameMaster.instance.g_coop == false)
        {
            ChangeBallType(BallType.Grey);
            gameObject.AddComponent<BallClaim>();
        }
    }

    void Update()
    {
        if (transform.position.y < GameMaster.instance.screenBottomEdge)
        {
            if (GameMaster.instance.g_coop)
            {
                GameMaster.instance.g_coopLives--;
                if (GameMaster.instance.g_coopLives <= 0)
                {
                    GameObject.FindGameObjectWithTag("Results").transform.Find("Results").GetComponent<Results>().showResults();
                    GameObject.FindGameObjectWithTag("Results").transform.Find("Results").transform.Find("Title").GetComponent<Text>().text = "Game Over!";
                }
                else
                {
                    Instantiate(respawnBall, new Vector2(0, -2), Quaternion.identity);
                }
            }
            else
            {
                if (ballType == BallType.Red)
                {
                    GameMaster.instance.g_player1Score -= 100;
                    GameMaster.instance.UpdateScoreText();
                }
                else if (ballType == BallType.Blue)
                {
                    GameMaster.instance.g_player2Score -= 100;
                    GameMaster.instance.UpdateScoreText();
                }

                Instantiate(respawnBall, new Vector2(0, -2), Quaternion.identity);
            }

            Destroy(gameObject);
        }
    }

    public void ChangeBallType(BallType newBallType)
    {
        switch (newBallType)
        {
            case BallType.Red:
                ballType = BallType.Red;
                GetComponent<SpriteRenderer>().color = Color.red;
                break;

            case BallType.Blue:
                ballType = BallType.Blue;
                GetComponent<SpriteRenderer>().color = Color.blue;
                break;

            case BallType.Grey:
                ballType = BallType.Grey;
                GetComponent<SpriteRenderer>().color = Color.grey;
                break;
        }
    }
}