using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BGM_Slider : MonoBehaviour
{
    [SerializeField]
    private Slider slider_BGM;              // BGM 조절 슬라이더
    [SerializeField]
    private Slider slider_SFX;              // SFX 조절 슬라이더

    void Start()
    {
        slider_BGM.value = BGM_Mgn.instance.BGM_Source.volume;
        slider_SFX.value = SFX_Mgn.instance.SFX_Source.volume;
    }

    public void SetBGM_Volume(float volume)
    {
        BGM_Mgn.instance.BGM_Source.volume = volume;
    }

    public void SetSFX_Volume(float volume)
    {
        SFX_Mgn.instance.SFX_Source.volume = volume;
    }

}
