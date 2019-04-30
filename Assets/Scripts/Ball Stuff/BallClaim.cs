using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallClaim : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Ball ball = GetComponent<Ball>();
            if (other.gameObject.GetComponent<PlayerData>().playerNumber == 1)
                ball.ChangeBallType(Ball.BallType.Red);
            else
                ball.ChangeBallType(Ball.BallType.Blue);
        }
    }
}