using UnityEngine;
using System.Collections;

public class Bricks : MonoBehaviour
{
    public int breakCounter;
    public string name;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log( "brick: " + name);
        Debug.Log( "ball: " + collision.Ball.name);
        if(collision.gameObject.name == name || name == "grey"){
            breakCounter--;
            if(breakCounter <= 0){
                Destroy(gameObject);
            }
        }
    }

}