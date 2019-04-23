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

            }

            Destroy(gameObject);
        }
    }
}