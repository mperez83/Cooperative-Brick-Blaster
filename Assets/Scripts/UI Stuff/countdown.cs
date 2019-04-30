using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class countdown : MonoBehaviour
{
    public GameObject cd;

    void Start()
    {
        StartCoroutine("startDelay");
    }

    IEnumerator startDelay()
    {
        Time.timeScale = 0f;
        float pauseTime = Time.realtimeSinceStartup + 3.5f;
        while (Time.realtimeSinceStartup < pauseTime)
        {
            yield return 0;
        }
        cd.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}