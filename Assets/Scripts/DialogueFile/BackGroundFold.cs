using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "BackGround", menuName = "Back/Ground")]
public class BackGroundFold : ScriptableObject
{
    // 0 = Black, 1 = hall, 2 = classroom
    [Header("��� �̹���")]
    public Sprite[] backGround;
}
