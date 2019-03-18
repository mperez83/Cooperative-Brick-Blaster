using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour
{
     Vector2 velocity;

     private Rigidbody2D rb;
     private bool ballInPlay;

     void Awake()
     {
          int randX = Random.Range(0,2);
          int randY = Random.Range(0,2);

          Vector2 launchDirection = new Vector2 ();
          launchDirection.y = 2f;
          
          if(randX == 0){
               launchDirection.x = -2f;
          }else{
               launchDirection.x = 2f;
          }

          rb = GetComponent<Rigidbody2D>();
          rb.velocity = launchDirection;
     }

     void Update()
     {
        Vector2 moveAmount = velocity;
     }
}