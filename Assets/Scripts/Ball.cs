using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour
{
    public enum BallType { Red, Blue, Grey };
    public BallType ballType;
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
            Destroy(gameObject);
        }
    }
}