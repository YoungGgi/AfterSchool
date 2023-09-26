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

    // �ܺο��� ����� ȿ���� index ȣ�� �� SFXs ����Ʈ�� index ���� AudioClip ���� ��ü �� ���
    public void SFX_Direction_Play(int index)
    {
        SFX_Source.clip = SFXs.direction_sfx_Clips[index];
        SFX_Source.Play();
    }

}
