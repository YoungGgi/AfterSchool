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

    private bool isAutoLive;

    private bool isAutoStory;

    private bool isTwoSpeed;

    private bool isSettingOn;

    public bool IsAutoLive { get => isAutoLive; set => isAutoLive = value; }
    public bool IsTwoSpeed { get => isTwoSpeed; set => isTwoSpeed = value; }
    
    public bool IsAutoStory { get => isAutoStory; set => isAutoStory = value; }
    public bool IsSettingOn { get => isSettingOn; set => isSettingOn = value; }
}
