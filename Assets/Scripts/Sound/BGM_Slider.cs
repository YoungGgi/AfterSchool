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
        // BGM 슬라이더와 SFX 슬라이더의 값을 각각 BGM_Source, SFX_Source 의 volume 값과 동일하게 
        slider_BGM.value = BGM_Mgn.instance.BGM_Source.volume;
        slider_SFX.value = SFX_Mgn.instance.SFX_Source.volume;
    }

    public void SetBGM_Volume(float volume)
    {
        // BGM 슬라이더 value 값에 따라 BGM_Source 의 volume 변경
        BGM_Mgn.instance.BGM_Source.volume = volume;
    }

    public void SetSFX_Volume(float volume)
    {
        // SFX 슬라이더 value 값에 따라 SFX_Source 의 volume 변경
        SFX_Mgn.instance.SFX_Source.volume = volume;
    }

}
