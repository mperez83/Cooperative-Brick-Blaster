using UnityEngine;
using System.Collections;

public class Bricks : MonoBehaviour
{
    public int breakCounter;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        breakCounter--;
        if(breakCounter <= 0){
            Destroy(gameObject);
        }
    }

}