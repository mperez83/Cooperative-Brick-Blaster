using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpeedup : MonoBehaviour
{
    public float minMagnitude;
    float curMagnitude;
    public float maxMagnitude;

    public float minVerticalSpeed;

    Rigidbody2D rb;

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
        }

        //Makes ball move faster if it isn't going fast enough
        if (rb.velocity.magnitude < curMagnitude)
        {
            //Vector2 normalizedVelocity = rb.velocity.normalized;
            rb.AddForce(rb.velocity * 10 * Time.deltaTime);
        }

        //This makes sure the vertical velocity never stays stagnant
        if (rb.velocity.y >= 0 && rb.velocity.y < minVerticalSpeed)
            rb.AddForce(new Vector2(0, 25) * Time.deltaTime);
        else if (rb.velocity.y < 0 && rb.velocity.y > -minVerticalSpeed)
            rb.AddForce(new Vector2(0, -25) * Time.deltaTime);
    }
}