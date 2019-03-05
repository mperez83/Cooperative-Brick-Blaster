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
            transform.Translate(Vector2.left * moveAmount);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector2.right * moveAmount);
        }
    }
}