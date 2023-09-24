using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene_StartSound : MonoBehaviour
{
    [SerializeField]
    private int bgm_Index;

    private void OnEnable()
    {
        BGM_Mgn.instance.BGM_Change(bgm_Index);
    }

}
