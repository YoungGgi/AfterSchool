using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SFX", menuName = "SFX Object/SFX_Data")]
public class SFX_Lists : ScriptableObject
{
    // ���� ȿ���� ���
    // 0 - ������
    // 1 - ���� �ɾ
    // 2 - ���� �پ
    
    public List<AudioClip> direction_sfx_Clips;

    // �ܼ� ȹ��� ȿ����
    public List<AudioClip> clue_sfx_Clips;

    // ���� ǥ���� ȿ����
    // 0 - ����(ȭ��)
    // 1 - ����
    // 2 - ��Ȳ(����)
    public List<AudioClip> emotion_sfx_Clips;

}
