using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX_Mgn : MonoBehaviour
{
    public static SFX_Mgn instance;

    // 싱글톤 패턴
    private void Awake()
    {
        #region Singletone
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
        #endregion
    }

    public SFX_Lists SFXs;                // 브금 리스트
    public AudioSource SFX_Source;        // 오디오 소스
    public AudioClip sfx_Clip;

    public AudioClip btnClick_Clip;       // 버튼 클릭 효과음

    // 공용 버튼 클릭 효과음 재생 함수
    public void ButtonClick_Play()
    {
        SFX_Source.PlayOneShot(btnClick_Clip);
    }

    // 외부에서 연출용 효과음 index 호출 시 SFXs 리스트의 index 값의 AudioClip 으로 교체 후 재생
    public void SFX_Direction_Play(int index)
    {
        sfx_Clip = SFXs.direction_sfx_Clips[index];
        SFX_Source.PlayOneShot(sfx_Clip);
    }

    public void SFX_Clue_Play(int index)
    {
        sfx_Clip = SFXs.clue_sfx_Clips[index];
        SFX_Source.PlayOneShot(sfx_Clip);
    }

}
