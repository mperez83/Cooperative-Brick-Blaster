using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoopVersus : MonoBehaviour
{
    public Toggle coop;
    public Text coopToggleText;

    void Update()
    {
        if (coop.isOn)
        {
            coopToggleText.text = "Mode:\nCo-op";
            GameMaster.instance.g_coop = true;
        }
        else
        {
            coopToggleText.text = "Mode:\nVersus";
            GameMaster.instance.g_coop = false;
        }
    }
}