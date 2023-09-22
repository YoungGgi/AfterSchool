using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BGM", menuName = "Sound Object/SoundData")]
public class BGM_Lists : ScriptableObject
{
    // 0 = Walking                     (������ �ϻ� ���)
    // 1 = Bouble Gum                  (Ȱ���� �ϻ� ���)
    // 2 = FUNNY                       (��� �߻� ���)
    // 3 = MY MISTAKE                  (�߸� ���� ���)
    // 4 = Reflected-light             (ȸ�� ���)
    // 5 = Documentary                 (�̴ϰ��� ���)
    public List<AudioClip> bgm_Clips;
}
