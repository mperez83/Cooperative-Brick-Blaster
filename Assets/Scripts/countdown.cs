using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class countdown : MonoBehaviour
{
    // private bool countDownDone = false;
    // public GameObject cd;
    // public void startCountDown(){
    //     //test
    //     Time.timeScale = 0f;
    //     countDownDone = false;
    // }

    // public void countDownFinished(){
    //     countDownDone = true;
    // }

    // void Start(){
    //     startCountDown();
    //     cd.SetActive(true);
    // }
    // void Update(){
    //     if(countDownDone){
    //         Time.timeScale = 1f;
    //     }
    // }

    public GameObject cd;

    void Start(){
        StartCoroutine("startDelay");
    }
    void Update(){

    }

    IEnumerator startDelay(){
        Time.timeScale = 0f;
        float pauseTime = Time.realtimeSinceStartup + 4f;
        while(Time.realtimeSinceStartup < pauseTime){
            yield return 0;
        }
        cd.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
