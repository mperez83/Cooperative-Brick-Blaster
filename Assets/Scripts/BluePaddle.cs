using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluePaddle : MonoBehaviour
{
    public float speed = 1;

    void Start()
    {
        
    }

    void Update()
    {
        float moveAmount = speed * Time.deltaTime;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //transform.Translate(Vector2.left * moveAmount);
            GetComponent<Rigidbody2D>().MovePosition(new Vector2(transform.position.x - moveAmount, transform.position.y));
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            //transform.Translate(Vector2.right * moveAmount);
            GetComponent<Rigidbody2D>().MovePosition(new Vector2(transform.position.x + moveAmount, transform.position.y));
        }
    }
}