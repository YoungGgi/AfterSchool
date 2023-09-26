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

    public AudioClip btnClick_Clip;       // 타이핑 효과음

    // 공용 버튼 클릭 효과음 재생 함수
    public void Typing_Play()
    {
        Typing_Source.PlayOneShot(btnClick_Clip);
    }


}
