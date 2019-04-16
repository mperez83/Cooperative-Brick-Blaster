using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserMovement : MonoBehaviour
{
    public float travelSpeed = 20;

    void Update()
    {
        Vector2 moveAmount = new Vector2(0, travelSpeed);
        transform.Translate(moveAmount * Time.deltaTime);

        if (transform.position.y > GameMaster.instance.screenTopEdge)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //This is where you can put the code for gaining points for destroying a brick
        /*if (other.CompareTag("Brick"))
        {
            Destroy(other.gameObject);
            //score.Add(100);
            Destroy(gameObject);
        }*/
    }
}