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

    // 외부에서 연출용 효과음 index 호출 시 SFXs 리스트의 index 값의 AudioClip 으로 교체 후 재생
    public void SFX_Direction_Play(int index)
    {
        SFX_Source.clip = SFXs.direction_sfx_Clips[index];
        SFX_Source.Play();
    }

}
