using UnityEngine;
using System.Collections;

public class Bricks : MonoBehaviour
{
    public int breakCounter;
    public string ballCheck;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == ballCheck || ballCheck == "Grey"){
            breakCounter--;
            if(breakCounter <= 0){
                Destroy(gameObject);
            }
        }
    }

}