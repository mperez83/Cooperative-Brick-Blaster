using UnityEngine;
using System.Collections;

public class Bricks : MonoBehaviour
{

    public GameObject brickParticle;

    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(brickParticle, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

}