using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextTyping_Player : MonoBehaviour
{
    public static TextTyping_Player instance;

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

    public AudioSource Typing_Source;

    public AudioClip btnClick_Clip;       // Ÿ���� ȿ����

    // ���� ��ư Ŭ�� ȿ���� ��� �Լ�
    public void Typing_Play()
    {
        Typing_Source.PlayOneShot(btnClick_Clip);
    }


}
