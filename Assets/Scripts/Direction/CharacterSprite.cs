using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "CharacterEmotion", menuName = "EmotionSprite/Emotion")]
public class CharacterSprite : ScriptableObject
{
    [Header("Character_Emotion_Group")]
    // 0 = �⺻  1 = ȭ��  2 = ���  3 = ���
    public Sprite[] characterSprite;

    // ĳ���� ����ǥ�� �̹��� ���� ����

}
