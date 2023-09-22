using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BGM_Slider : MonoBehaviour
{
    [SerializeField]
    private Slider slider_BGM;              // BGM 조절 슬라이더


    void Start()
    {
        slider_BGM.value = BGM_Mgn.instance.BGM_Source.volume;
    }

    public void SetBGM_Volume(float volume)
    {
        BGM_Mgn.instance.BGM_Source.volume = volume;
    }
}
