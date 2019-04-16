using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWidthPowerUp : MonoBehaviour
{
    float powerUpTimer = 12;
    float originalXScale;

    void Start()
    {
        originalXScale = transform.localScale.x;
        LeanTween.scaleX(gameObject, transform.localScale.x * 2, 1).setEase(LeanTweenType.easeOutCubic);
    }

    void Update()
    {
        powerUpTimer -= Time.deltaTime;
        if (powerUpTimer < 0)
        {
            powerUpTimer = 999; //@god
            LeanTween.scaleX(gameObject, originalXScale, 1).setOnComplete(() =>
            {
                Destroy(this);
            });
        }
    }
}