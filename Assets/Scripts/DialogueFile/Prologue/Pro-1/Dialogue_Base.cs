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

        [Header("���� ����")]
        public Y_Anim y_Anim;
        public Y_Sprite y_sprite;
        public Y_Direction y_Direction;

        [Header("���� ����")]
        public J_Anim j_Anim;

        [Header("�μ� ����")]
        public M_Anim m_Anim;


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

        [Header("��� �̹���")]
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

