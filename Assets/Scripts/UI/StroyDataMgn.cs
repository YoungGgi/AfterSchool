using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StroyDataMgn : MonoBehaviour
{
    public static StroyDataMgn instance;

    private void Awake()
    {
        #region Singletone
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
        #endregion
    }

    public bool isAutoLive;

    public bool isTwoSpeed;

}
