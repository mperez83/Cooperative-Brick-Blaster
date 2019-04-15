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
            coopToggleText.text = "Co-op Mode";
            GameMaster.instance.g_coop = true;
        }
        else
        {
            coopToggleText.text = "Versus Mode";
            GameMaster.instance.g_coop = false;
        }
    }
}