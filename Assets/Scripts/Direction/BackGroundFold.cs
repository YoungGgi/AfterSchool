using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "BackGround", menuName = "Back/Ground")]
public class BackGroundFold : ScriptableObject
{
    // 0 = Black, 1 = hall, 2 = classroom, 3 = hall_Chap1, 4 = Library, 5 = TeacherRoom, 6 = Library_Room
    [Header("배경 이미지")]
    public Sprite[] backGround;
}
