using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Dialogue", menuName = "Dialogues")]
public class Dialogue_Base : ScriptableObject
{
    [System.Serializable]
    public class Info
    {
        [TextArea(3, 12)]
        public string myText;
        
        [Header("캐릭터 이름")]
        public Name charName;

        [Header("효정 연출")]
        public H_Anim h_Anim;
        public H_Sprite h_sprite;
        public H_Direction h_Direction;

        [Header("용진 연출")]
        public Y_Anim y_Anim;
        public Y_Sprite y_sprite;
        public Y_Direction y_Direction;

        [Header("지수 연출")]
        public J_Anim j_Anim;

        [Header("민석 연출")]
        public M_Anim m_Anim;


        [Header("연출효과")]
        public Direction direction;

        [Header("단서 획득")]
        public bool isFirstClue;
        public bool isSecondClue;
        public bool isThirdClue;
        public bool isForthClue;

        [Header("대화창끄기")]
        public bool UI_Off;

        [Header("타이틀")]
        public bool Title_On;

        [Header("배경 이미지")]
        public Sprite backGround;

    
    }

    public Info[] dialogueInfo;
}

public enum Name
{
    Blank, Player, Hujung, YoungJin, Jisu, MinSeok, Who
}

#region HujungEnum
public enum H_Anim
{ 
    Idle,
    H_Appear,
    H_DisAppear,
    Start,
    Bangbang
}

public enum H_Direction
{
    Center,
    Right,
    Left
}

public enum H_Sprite
{
    Idle,
    Angry,
    Smile,
    Sad
}

#endregion

#region YoungjingEnum
public enum Y_Anim
{
    Idle, Y_Appear, Y_DisAppear, Start, Y_Bangbang
}

public enum Y_Direction
{
    Center, Right, Left
}

public enum Y_Sprite
{
    Idle, Angry, Smile, Sad
}

#endregion


public enum J_Anim
{
    Idle, J_Appear, J_DisAppear, Start
}

public enum M_Anim
{
    Idle, M_Appear, M_DisAppear, Start
}


public enum Direction
{
    Blank, FadeIn, FadeOut
}

