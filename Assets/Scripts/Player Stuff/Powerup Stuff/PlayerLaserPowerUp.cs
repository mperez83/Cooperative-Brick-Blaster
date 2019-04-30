using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLaserPowerUp : MonoBehaviour
{
    float powerUpTimer = 12;
    KeyCode keyToPress;

    PaddleAudioHandler pah;
    GameObject laserPrefab;

    void Start()
    {
        if (!GetComponent<PaddleController>())
        {
            print("SOMEONE tried to give a LASER POWERUP to an object that DOESN'T HAVE A PADDLE CONTROLLER COMPONENT");
            Destroy(this);
        }

        keyToPress = (GetComponent<PlayerData>().playerNumber == 1) ? KeyCode.F : KeyCode.RightControl;
        pah = GetComponent<PaddleAudioHandler>();
        laserPrefab = GetComponent<PlayerData>().laserPrefab;
    }

    void Update()
    {
        if (Input.GetKeyDown(keyToPress))
        {
            GameObject laser = Instantiate(laserPrefab, new Vector2(transform.position.x, transform.position.y + 0.5f), Quaternion.identity);
            laser.GetComponent<LaserMovement>().playerNum = GetComponent<PlayerData>().playerNumber;
            pah.PlayLaserSound();
        }

        powerUpTimer -= Time.deltaTime;
        if (powerUpTimer < 0)
        {
            Destroy(this);
        }
    }
}