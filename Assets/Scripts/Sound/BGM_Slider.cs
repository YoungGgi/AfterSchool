using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BGM_Slider : MonoBehaviour
{
    [SerializeField]
    private Slider slider_BGM;              // BGM ���� �����̴�
    [SerializeField]
    private Slider slider_SFX;              // SFX ���� �����̴�

    void Start()
    {
        // BGM �����̴��� SFX �����̴��� ���� ���� BGM_Source, SFX_Source �� volume ���� �����ϰ� 
        slider_BGM.value = BGM_Mgn.instance.BGM_Source.volume;
        slider_SFX.value = SFX_Mgn.instance.SFX_Source.volume;
    }

    public void SetBGM_Volume(float volume)
    {
        // BGM �����̴� value ���� ���� BGM_Source �� volume ����
        BGM_Mgn.instance.BGM_Source.volume = volume;
    }

    public void SetSFX_Volume(float volume)
    {
        // SFX �����̴� value ���� ���� SFX_Source �� volume ����
        SFX_Mgn.instance.SFX_Source.volume = volume;
    }

}
