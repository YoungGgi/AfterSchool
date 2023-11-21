using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SFX", menuName = "SFX Object/SFX_Data")]
public class SFX_Lists : ScriptableObject
{
    // 연출용 효과음 목록
    public List<AudioClip> direction_sfx_Clips;

    // 단서 획득용 효과음
    public List<AudioClip> clue_sfx_Clips;

    // 감정 표현용 효과음
    public List<AudioClip> emotion_sfx_Clips;

}
