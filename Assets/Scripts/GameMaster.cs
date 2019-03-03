using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public static GameMaster instance;

    void Start()
    {
        if (instance != null && instance != this)
            Destroy(gameObject);
        else
            instance = this;
        DontDestroyOnLoad(this);
    }

    void Update()
    {
        
    }
}