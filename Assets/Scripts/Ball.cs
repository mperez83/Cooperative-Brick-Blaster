﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    //<<<<<<< HEAD
    public enum BallType { Red, Blue, Grey };
    public BallType ballType;
    public GameObject respawnBall;

    public AudioClip brickBreakSound;
    public AudioClip laserHitSound;

    Rigidbody2D rb;
    AudioSource audioSource;
    private bool ballInPlay;
    GameObject gameController;

    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController");
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        ballInPlay = false;

        // if (GameMaster.instance.g_coop == false)
        // {
        //     ChangeBallType(BallType.Grey);
        //     gameObject.AddComponent<BallClaim>();
        // }
    }

    void Update()
    {
        // Ball Shoot
        if ((ballType == BallType.Red && Input.GetButtonDown("Jump") && ballInPlay == false)
            || (ballType == BallType.Blue && Input.GetButtonDown("RightControl") && ballInPlay == false))
        {
            transform.parent = null;
            ballInPlay = true;
            rb.isKinematic = false;

            int randX = Random.Range(0, 2);
            int randY = Random.Range(0, 2);

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

            rb.velocity = launchDirection;
        }

        // Ball Destroy & Respawn
        if (transform.position.y < GameMaster.instance.screenBottomEdge)
        {
            ballInPlay = false;
            if (GameMaster.instance.g_coop)
            {
                gameController.GetComponent<CoopHandler>().coopLives--;
                if (gameController.GetComponent<CoopHandler>().coopLives <= 0)
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
                    gameController.GetComponent<VersusHandler>().player1Score -= 100;
                    respawnBall = Instantiate(respawnBall, new Vector2(GameObject.Find("Red_Paddle").transform.position.x, (float)-3.5), Quaternion.identity) as GameObject;
                    respawnBall.transform.parent = GameObject.Find("Red_Paddle").transform;
                }
                else if (ballType == BallType.Blue)
                {
                    gameController.GetComponent<VersusHandler>().player2Score -= 100;
                    respawnBall = Instantiate(respawnBall, new Vector2(GameObject.Find("Blue_Paddle").transform.position.x, (float)-3.5), Quaternion.identity) as GameObject;
                    respawnBall.transform.parent = GameObject.Find("Blue_Paddle").transform;
                }
                rb = respawnBall.GetComponent<Rigidbody2D>();
                rb.isKinematic = true;

                gameController.GetComponent<VersusHandler>().UpdateScoreText();

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

    void OnCollisionEnter2D(Collision2D other)
    {
        switch (other.gameObject.name)
        {
            case "Red_Paddle":
                ChangeBallType(BallType.Red);
                break;

            case "Blue_Paddle":
                ChangeBallType(BallType.Blue);
                break;
        }

        if (other.gameObject.CompareTag("Brick"))
        {
            audioSource.clip = brickBreakSound;
            audioSource.Play();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Laser"))
        {
            audioSource.clip = laserHitSound;
            audioSource.Play();

            Destroy(other.gameObject);
            rb.AddForce(new Vector2(0, 100));
        }
    }
    /*=======
        public enum BallType { Red, Blue, Grey };
        public BallType ballType;
        public GameObject respawnBall;

        public AudioClip brickBreakSound;
        public AudioClip laserHitSound;

        AudioSource audioSource;
        Rigidbody2D rb;
        GameObject gameController;

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

            audioSource = GetComponent<AudioSource>();
            gameController = GameObject.FindGameObjectWithTag("GameController");
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
                    gameController.GetComponent<CoopHandler>().coopLives--;
                    if (gameController.GetComponent<CoopHandler>().coopLives <= 0)
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
                        gameController.GetComponent<VersusHandler>().player1Score -= 100;
                    else if (ballType == BallType.Blue)
                        gameController.GetComponent<VersusHandler>().player2Score -= 100;
                    gameController.GetComponent<VersusHandler>().UpdateScoreText();

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

        void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Brick"))
            {
                audioSource.clip = brickBreakSound;
                audioSource.Play();
            }
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Laser"))
            {
                audioSource.clip = laserHitSound;
                audioSource.Play();

                Destroy(other.gameObject);
                rb.AddForce(new Vector2(0, 100));
            }
        }
    >>>>>>> mvp-rush*/
}