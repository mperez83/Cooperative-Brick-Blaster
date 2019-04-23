using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamemodeInitializer : MonoBehaviour
{
    void Start()
    {
        if (GameMaster.instance.g_coop)
        {
            gameObject.AddComponent<CoopHandler>();
        }
        else
        {
            gameObject.AddComponent<VersusHandler>();
        }
    }
}