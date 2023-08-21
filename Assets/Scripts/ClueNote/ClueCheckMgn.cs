using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClueCheckMgn : MonoBehaviour
{
    #region Singletone
    public static ClueCheckMgn instance;

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

    public bool[] isCheck;

}
