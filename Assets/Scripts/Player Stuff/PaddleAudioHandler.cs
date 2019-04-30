using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleAudioHandler : MonoBehaviour
{
    public AudioClip ballHitSound;
    public AudioClip laserFireSound;
    public AudioClip powerUpCollectSound;

    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayLaserSound()
    {
        audioSource.clip = laserFireSound;
        audioSource.Play();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            audioSource.clip = ballHitSound;
            audioSource.Play();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Power_Up"))
        {
            audioSource.clip = powerUpCollectSound;
            audioSource.Play();
        }
    }
}