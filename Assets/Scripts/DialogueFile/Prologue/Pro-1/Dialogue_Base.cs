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
        
        [Header("ĳ���� �̸�")]
        public Name charName;

        [Header("ȿ�� ����")]
        public H_Anim h_Anim;
        public H_Sprite h_sprite;
        public H_Direction h_Direction;
        public bool isHujung_CloseUp;

        [Header("���� ����")]
        public Y_Anim y_Anim;
        public Y_Sprite y_sprite;
        public Y_Direction y_Direction;
        public bool isYoungjin_CloseUp;

        [Header("���� ����")]
        public J_Anim j_Anim;
        public J_Sprite j_sprite;
        public J_Direction j_Direction;
        public bool isJisu_CloseUp;

        [Header("�μ� ����")]
        public M_Anim m_Anim;
        public M_Sprite m_sprite;
        public M_Direction m_Direction;
        public bool isMinseok_CloseUp;


        [Header("����ȿ��")]
        public Direction direction;

        [Header("�ܼ� ȹ��")]
        public bool isFirstClue;
        public bool isSecondClue;
        public bool isThirdClue;
        public bool isForthClue;

        [Header("��ȭâ����")]
        public bool UI_Off;

        [Header("Ÿ��Ʋ")]
        public bool Title_On;
        public bool Title_Two;

        [Header("��� �̹���")]
        public BackGround backGroundImg;

        [Header("é�� ���� ����")]
        public bool isPrologueClose;
        public bool isChapter1Close;
        public bool isChapter2Close;
        public bool isChapter3Close;


    }

    public Info[] dialogueInfo;
}

public enum Name
{
    Blank, Player, Hujung, YoungJin, Jisu, MinSeok, Who, HujungYoung, Who_Jisu, Who_Min, PlayerHujung, HujungJisu, PlayerYoungJin, All, Teacher
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
    Left,
    Out
}

public enum H_Sprite
{
    Idle,
    Angry,
    Smile,
    Surprise
}

#endregion

#region YoungjingEnum
public enum Y_Anim
{
    Idle, Y_Appear, Y_DisAppear, Start, Y_Bangbang
}

public enum Y_Direction
{
    Center, Right, Left, Out
}

public enum Y_Sprite
{
    Idle, Idle01, Angry, Smile, Smile01, Surprise
}

#endregion

#region JisuEnum
public enum J_Anim
{
    Idle, J_Appear, J_DisAppear, Start, J_BangBang
}

public enum J_Direction
{
    Center, Right, Left, Out
}

public enum J_Sprite
{
    Idle, Angry, Smile, Surprise
}

#endregion


#region MinSeokEnum
public enum M_Anim
{
    Idle, M_Appear, M_DisAppear, Start
}

public enum M_Direction
{
    Center, Right, Left, Out
}

public enum M_Sprite
{
    Idle, Angry, Smile, Surprise
}

#endregion

public enum BackGround
{
    Black,
    Hall,
    ClassRoom_Pro,
    Hall_Chap1,
    Library,
    TeacherRoom
}

public enum Direction
{
    Blank, FadeIn, FadeOut
}

