using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX_Mgn : MonoBehaviour
{
    public static SFX_Mgn instance;

    // �̱��� ����
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

    public SFX_Lists SFXs;                // ��� ����Ʈ
    public AudioSource SFX_Source;        // ����� �ҽ�
    public AudioClip sfx_Clip;

    public AudioClip btnClick_Clip;       // ��ư Ŭ�� ȿ����

    // ���� ��ư Ŭ�� ȿ���� ��� �Լ�
    public void ButtonClick_Play()
    {
        SFX_Source.PlayOneShot(btnClick_Clip);
    }

    // �ܺο��� ����� ȿ���� index ȣ�� �� SFXs ����Ʈ�� index ���� AudioClip ���� ��ü �� ���
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

    public void SFX_Emotion_Play(int index)
    {
        sfx_Clip = SFXs.emotion_sfx_Clips[index];
        SFX_Source.PlayOneShot(sfx_Clip);
    }

}
