using UnityEngine;
using System.Collections;

public class Bricks : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Instantiate(brickParticle, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

}