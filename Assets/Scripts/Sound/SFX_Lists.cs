using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SFX", menuName = "SFX Object/SFX_Data")]
public class SFX_Lists : ScriptableObject
{
    // 연출 효과음 목록

    // 0 = 단서 획득
    public List<AudioClip> direction_sfx_Clips;


}
