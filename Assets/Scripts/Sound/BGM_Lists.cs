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
    // 6 = Game                        (미니게임 브금_2챕부터)
    // 7 = JoEnNim                     (감동적인 브금)
    // 8 = Waltz for child             (가벼운 일상 브금)
    // 9 = HOW ARE YOU                 (일상 브금)
    public List<AudioClip> bgm_Clips;
}
