using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM_Mgn : MonoBehaviour
{
    public static BGM_Mgn instance;

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

    public BGM_Lists BGMs;                // 브금 리스트
    public AudioSource BGM_Source;        // 오디오 소스

    // 외부에서 index 호출 시 AudioSource 를 멈추고 BGMs 리스트의 index 값의 AudioClip 으로 교체 후 재생
    public void BGM_Change(int index)
    {
        BGM_Source.Stop();
        BGM_Source.clip = BGMs.bgm_Clips[index];
        BGM_Source.Play();
    }

    // 외부에서 호출 시 AudioSource 정지
    public void BGM_Stop()
    {
        BGM_Source.Stop();
    }

}
