using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoopVersus : MonoBehaviour
{
    public Toggle coop;

    public Text coopToggleText;

    void Update(){
        if(coop.isOn){
            coopToggleText.text = "Co-op Mode";
            globalVars.g_coop = true;
        }
        else{
            coopToggleText.text = "Versus Mode";
            globalVars.g_coop = false;
        }
    }  
}
