using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SFX", menuName = "SFX Object/SFX_Data")]
public class SFX_Lists : ScriptableObject
{
    // 연출 효과음 목록
    // 0 - 번뜩임
    // 1 - 교실 걸어감
    // 2 - 교실 뛰어감
    
    public List<AudioClip> direction_sfx_Clips;

    // 단서 획득용 효과음
    public List<AudioClip> clue_sfx_Clips;

    // 감정 표현용 효과음
    // 0 - 빠직(화남)
    // 1 - 웃음
    // 2 - 당황(삐질)
    public List<AudioClip> emotion_sfx_Clips;

}
