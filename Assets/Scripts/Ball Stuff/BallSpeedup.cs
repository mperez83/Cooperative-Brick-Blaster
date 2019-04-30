using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpeedup : MonoBehaviour
{
    Rigidbody2D rb;
    public float minMagnitude;
    float curMagnitude;
    public float maxMagnitude;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        curMagnitude = minMagnitude;
    }

    void Update()
    {
        if (curMagnitude < maxMagnitude)
        {
            curMagnitude += 0.1f * Time.deltaTime;
            //print(curMagnitude);
        }

        if (rb.velocity.magnitude < minMagnitude)
        {
            Vector2 normalizedVelocity = rb.velocity.normalized;
            rb.AddForce(normalizedVelocity);
        }
    }
}