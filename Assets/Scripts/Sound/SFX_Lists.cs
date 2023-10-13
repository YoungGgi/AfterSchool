using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SFX", menuName = "SFX Object/SFX_Data")]
public class SFX_Lists : ScriptableObject
{
    // 연출용 효과음 목록
    // 0 - 상황강조
    // 1 - 걸음소리
    // 2 - 뜀걸음 소리
    // 3 - 문 여는 소리
    // 4 - 문 닫는 소리
    // 5 - 두둥
    public List<AudioClip> direction_sfx_Clips;

    // 단서 획득용 효과음
    public List<AudioClip> clue_sfx_Clips;

    // 감정 표현용 효과음
    // 0 - 화남(빠직)
    // 1 - 웃음
    // 2 - 당황(땀 삐질)
    // 3 - 당황(땡)
    // 4 - 충격
    public List<AudioClip> emotion_sfx_Clips;

}
