using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Brick : MonoBehaviour
{
    public int breakCounter;
    public Ball.BallType brickType;
    public Sprite redBrick;
    public Sprite blueBrick;
    public Sprite greyBrick;
    public GameObject powerUpPrefab;

    GameObject gameController;



    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController");

        if (GameMaster.instance.g_coop == false)
        {
            brickType = Ball.BallType.Grey;
            GetComponent<SpriteRenderer>().sprite = greyBrick;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Ball>() != null)
        {
            Ball ball = collision.gameObject.GetComponent<Ball>();

            if (ball.ballType == brickType || brickType == Ball.BallType.Grey)
            {
                breakCounter--;
                if (breakCounter <= 0)
                {
                    if (GameMaster.instance.g_coop)
                    {
                        gameController.GetComponent<CoopHandler>().coopScore += 100;
                        gameController.GetComponent<CoopHandler>().UpdateScoreText();
                    }
                    else
                    {
                        if (ball.ballType == Ball.BallType.Red)
                            gameController.GetComponent<VersusHandler>().player1Score += 100;
                        else if (ball.ballType == Ball.BallType.Blue)
                            gameController.GetComponent<VersusHandler>().player2Score += 100;

                        gameController.GetComponent<VersusHandler>().UpdateScoreText();
                    }

                    if (transform.parent.childCount == 1)
                    {
                        GameObject.FindGameObjectWithTag("Results").transform.Find("Results").GetComponent<Results>().showResults();
                    }

                    if (Random.Range(0, 10) == 0) Instantiate(powerUpPrefab, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);

                    Destroy(gameObject);
                }
            }
        }
    }
}