using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedPaddle : MonoBehaviour
{
    public float speed = 1;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float moveAmount = speed * Time.deltaTime;

        if (Input.GetKey(KeyCode.A))
        {
            //transform.position += (Vector3.left * moveAmount);
            rb.MovePosition(new Vector2(transform.position.x - moveAmount, transform.position.y));
            //rb.velocity = Vector2.left * moveAmount;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            //transform.position += (Vector3.right * moveAmount);
            rb.MovePosition(new Vector2(transform.position.x + moveAmount, transform.position.y));
            //rb.velocity = Vector2.right * moveAmount;
        }
    }
}