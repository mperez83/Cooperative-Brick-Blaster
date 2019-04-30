using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MapButton : MonoBehaviour
{
    // string button map is whatever map/scene the button is supposed to go to. edit this in unity
    public void selectMap(string buttonMap)
    {
        GameMaster.instance.LevelSelected = buttonMap;
    }
}