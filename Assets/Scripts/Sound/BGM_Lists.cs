using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BGM", menuName = "Sound Object/SoundData")]
public class BGM_Lists : ScriptableObject
{
    // 0 = Walking                     (잔잔한 일상 브금)
    // 1 = Bouble Gum                  (활기찬 일상 브금)
    // 2 = FUNNY                       (사건 발생 브금)
    // 3 = MY MISTAKE                  (추리 느낌 브금)
    // 4 = Reflected-light             (회상 브금)
    // 5 = Documentary                 (미니게임 브금)
    public List<AudioClip> bgm_Clips;
}
