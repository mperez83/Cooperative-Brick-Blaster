using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpMovement : MonoBehaviour
{
    public float fallSpeed = 6;

    void Start()
    {

    }

    void Update()
    {
        Vector2 moveAmount = new Vector2(0, -fallSpeed);
        transform.Translate(moveAmount);

        if (transform.position.y < GameMaster.instance.screenBottomEdge)
        {
            Destroy(gameObject);
        }
    }
}