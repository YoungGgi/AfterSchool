using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM_Mgn : MonoBehaviour
{
    public static BGM_Mgn instance;

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

    public BGM_Lists BGMs;                // ��� ����Ʈ
    public AudioSource BGM_Source;        // ����� �ҽ�

    // �ܺο��� index ȣ�� �� AudioSource �� ���߰� BGMs ����Ʈ�� index ���� AudioClip ���� ��ü �� ���
    public void BGM_Change(int index)
    {
        BGM_Source.Stop();
        BGM_Source.clip = BGMs.bgm_Clips[index];
        BGM_Source.Play();
    }

    // �ܺο��� ȣ�� �� AudioSource ����
    public void BGM_Stop()
    {
        BGM_Source.Stop();
    }

}
