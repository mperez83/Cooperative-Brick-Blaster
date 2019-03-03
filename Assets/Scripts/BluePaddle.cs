using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluePaddle : MonoBehaviour
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

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.MovePosition(new Vector2(transform.position.x - moveAmount, transform.position.y));
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.MovePosition(new Vector2(transform.position.x + moveAmount, transform.position.y));
        }
    }
}