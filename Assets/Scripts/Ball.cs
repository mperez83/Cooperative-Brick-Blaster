using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
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
}