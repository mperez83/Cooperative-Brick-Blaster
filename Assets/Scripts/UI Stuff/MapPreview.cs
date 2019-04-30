using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapPreview : MonoBehaviour
{
    public Image preview;
    //sprites for preview. keep adding as more maps are added.
    public Sprite previewDefault;
    public Sprite previewMap1;
    public Sprite previewMap2;
    public Sprite previewMap3;
    // Start is called before the first frame update
    void Start()
    {
        //start with default image preview sprite
        preview.sprite = previewDefault;
    }

    // Update is called once per frame
    void Update()
    {
        //update preview image
        if(GameMaster.instance.LevelSelected == "Map_1"){
            preview.sprite = previewMap1;
        }
        else if(GameMaster.instance.LevelSelected == "Map_2"){
            preview.sprite = previewMap2;
        }
        else if(GameMaster.instance.LevelSelected == "Map_3"){
            preview.sprite = previewMap3;
        }
    }
}
