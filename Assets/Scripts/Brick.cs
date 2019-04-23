using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Brick : MonoBehaviour
{
    public int breakCounter;
    public Ball.BallType brickType;

    private void OnCollisionEnter2D(Collision2D collision)
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
                        GameMaster.instance.g_coopScore += 100;
                    }
                    else
                    {
                        if (ball.ballType == Ball.BallType.Red)
                            GameMaster.instance.g_player1Score += 100;
                        else if (ball.ballType == Ball.BallType.Blue)
                            GameMaster.instance.g_player2Score += 100;
                    }

                    GameMaster.instance.UpdateScoreText();

                    if (transform.parent.childCount == 1)
                    {
                        GameObject.FindGameObjectWithTag("Results").transform.Find("Results").GetComponent<Results>().showResults();
                        GameObject.FindGameObjectWithTag("Results").transform.Find("Results").transform.Find("Title").GetComponent<Text>().text = "Level Complete!";
                    }

                    Destroy(gameObject);
                }
            }
        }
    }
}