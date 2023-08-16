using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "CharacterEmotion", menuName = "EmotionSprite/Emotion")]
public class CharacterSprite : ScriptableObject
{
    [Header("Character_Emotion_Group")]
    // 0 = 기본  1 = 화남  2 = 기쁨  3 = 놀람
    public Sprite[] characterSprite;

    // 캐릭터 감정표현 이미지 넣을 예정

}
