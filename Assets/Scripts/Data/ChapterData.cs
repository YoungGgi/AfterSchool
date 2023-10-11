using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChapterData : MonoBehaviour
{
    public static ChapterData instance;

    private void Awake()
    {
        #region SingleTone
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


    
}
