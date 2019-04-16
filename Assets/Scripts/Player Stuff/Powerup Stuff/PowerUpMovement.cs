using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpMovement : MonoBehaviour
{
    public float fallSpeed = 6;

    void Update()
    {
        Vector2 moveAmount = new Vector2(0, -fallSpeed);
        transform.Translate(moveAmount * Time.deltaTime);

        if (transform.position.y < GameMaster.instance.screenBottomEdge)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            int randRoll = Random.Range(0, 2);

            if (randRoll == 0)
            {
                if (!other.GetComponent<PlayerWidthPowerUp>())
                    other.gameObject.AddComponent<PlayerWidthPowerUp>();
            }
            else if (randRoll == 1)
            {
                if (!other.GetComponent<PlayerLaserPowerUp>())
                    other.gameObject.AddComponent<PlayerLaserPowerUp>();
            }

            Destroy(gameObject);
        }
    }
}