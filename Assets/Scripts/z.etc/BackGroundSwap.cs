using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackGroundSwap : MonoBehaviour
{
    
    [SerializeField]
    private Image titleCutScene;
    
    [SerializeField]
    private Sprite title_NoImg;
    [SerializeField]
    private Sprite title_01Img;
    [SerializeField]
    private Sprite title_02Img;
    [SerializeField]
    private Sprite title_03Img;

    
    void Start()
    {
        if(PlayerPrefs.HasKey("PrologueClear"))
        {
            titleCutScene.sprite = title_01Img;
        }

        if (PlayerPrefs.HasKey("Chapter1Clear"))
        {
            titleCutScene.sprite = title_02Img;
        }

        if (PlayerPrefs.HasKey("Chapter3Clear"))
        {
            titleCutScene.sprite = title_03Img;
        }
    }

}
