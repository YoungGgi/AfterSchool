using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChapterCheck : MonoBehaviour
{
    #region Singleton
    public static ChapterCheck instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    #endregion

    public bool isPrologueComplete;
}
