using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "CharacterEmotion", menuName = "EmotionSprite/Emotion")]
public class CharacterSprite : ScriptableObject
{
    [Header("Character_Emotion_Group")]
    // 0 = 기본  1 = 화남  2 = 웃음  3 = 놀람
    public Sprite[] characterSprite;


}
