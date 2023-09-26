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
        public string myText;                        // ��ȭ ����
        
        [Header("ĳ���� �̸�")]
        public Name charName;                        // ȭ��(Enum)

        [Header("ȿ�� ����")]
        public H_Anim h_Anim;                        // ȿ�� �ִϸ��̼�
        public H_Sprite h_sprite;                    // ȿ�� ��������Ʈ(ǥ��)
        public H_Direction h_Direction;              // ȿ�� ���� ��ġ
        public bool isHujung_CloseUp;                // ȿ�� Ŭ����� ���� ����

        [Header("���� ����")]
        public Y_Anim y_Anim;                        // ���� �ִϸ��̼�
        public Y_Sprite y_sprite;                    // ���� ��������Ʈ(ǥ��)
        public Y_Direction y_Direction;              // ���� ���� ��ġ
        public bool isYoungjin_CloseUp;              // ���� Ŭ����� ���� ����

        [Header("���� ����")]
        public J_Anim j_Anim;                        // ���� �ִϸ��̼�
        public J_Sprite j_sprite;                    // ���� ��������Ʈ(ǥ��)
        public J_Direction j_Direction;              // ���� ���� ��ġ
        public bool isJisu_CloseUp;                  // ���� Ŭ����� ���� ����

        [Header("�μ� ����")]
        public M_Anim m_Anim;                        // �μ� �ִϸ��̼�
        public M_Sprite m_sprite;                    // �μ� ��������Ʈ(ǥ��)
        public M_Direction m_Direction;              // �μ� ���� ��ġ
        public bool isMinseok_CloseUp;               // �μ� Ŭ����� ���� ����

        [Header("BGM �÷���")]
        public bool isBGM_Change;                    // BGM ���� ���� ����
        public int BGM_Index;                        // ������ BGM �ε���
        public bool isBGM_Stop;                      // BGM ���� ���� ����

        [Header("ȿ���� �÷���")]
        public bool isDirectionSFX;                  // ����� ȿ���� ��� ������
        public int SFX_Index;                        // SFX �ε���

        [Header("����ȿ��")]
        public Direction direction;                  // ȭ�� ���� (���� ����)

        [Header("��Ʈ Ű��� ȿ��")]
        public bool isFontSizeUp;                    // ��Ʈ ũ�� Ű��� ���� ������

        [Header("�ܼ� ȹ��")]
        // �ܼ� ȹ�� �� ���� ���� (���ʴ��)
        public bool isFirstClue;
        public bool isSecondClue;
        public bool isThirdClue;
        public bool isForthClue;
        public bool isFiveClue;
        public bool isSixClue;

        [Header("��ȭâ����")]
        public bool UI_Off;                           // ��ȭ UI ��Ȱ��ȭ ���� ����

        [Header("��� ���� �� ��Ÿ ����")]
        public BackGroundDirections back;             // ��� ���� ����

        [Header("Ÿ��Ʋ")]
        public bool Title_On;                         // Ÿ��Ʋ ������Ʈ1 ��� ���� ����
        public bool Title_Two;                        // Ÿ��Ʋ ������Ʈ2 ��� ���� ����

        [Header("��� �̹���")]
        public BackGround backGroundImg;              // ����� ��� �̹���

        [Header("é�� ���� ����")]
        // �� é�� ���� ���� ����
        public bool isPrologueClose;
        public bool isChapter1Close;
        public bool isChapter2Close;
        public bool isChapter3Close;


    }

    // �ش� Ŭ������ ����Ʈȭ
    public Info[] dialogueInfo;
}

// ĳ���� �̸� ���
public enum Name
{
    Blank, Player, Hujung, YoungJin, Jisu, MinSeok, Who, HujungYoung, Who_Jisu, Who_Min, 
    PlayerHujung, HujungJisu, PlayerYoungJin, All, Teacher, YoungJinJisu,
    Student01, Student02, Student03, Bear, Rabbit, Who_Hujung
}

// ȿ�� ���� ���
#region HujungEnum
public enum H_Anim                // ȿ�� �ִϸ��̼� ���
{ 
    Idle,
    H_Appear,
    H_DisAppear,
    Start,
    Bangbang
}

public enum H_Direction           // ȿ�� ���� ��ġ ���
{
    Center,
    Right,
    Left,
    Out
}

public enum H_Sprite              // ȿ�� ǥ�� ���
{
    Idle,
    Angry,
    Smile,
    Surprise
}

#endregion

// ���� ���� ���
#region YoungjingEnum
public enum Y_Anim                // ���� �ִϸ��̼� ���
{
    Idle, 
    Y_Appear, 
    Y_DisAppear, 
    Start, 
    Y_Bangbang
}

public enum Y_Direction           // ���� ���� ��ġ ���
{
    Center, 
    Right, 
    Left, 
    Out
}

public enum Y_Sprite               // ���� ǥ�� ���
{
    Idle, 
    Idle01, 
    Angry, 
    Smile, 
    Smile01, 
    Surprise
}

#endregion

// ���� ���� ���
#region JisuEnum
public enum J_Anim             // ���� �ִϸ��̼� ���
{
    Idle, 
    J_Appear, 
    J_DisAppear, 
    Start, 
    J_BangBang
}

public enum J_Direction         // ���� ���� ��ġ ���
{
    Center, Right, Left, Out
}

public enum J_Sprite            // ���� ǥ�� ���
{
    Idle, Angry, Smile, Surprise
}

#endregion

// �μ� ���� ���
#region MinSeokEnum
public enum M_Anim              // �μ� �ִϸ��̼� ���
{
    Idle, 
    M_Appear, 
    M_DisAppear, 
    Start, 
    M_BangBang
}

public enum M_Direction           // �μ� ���� ��ġ ���
{
    Center, 
    Right, 
    Left, 
    Out
}

public enum M_Sprite             // �μ� ǥ�� ���
{
    Idle, 
    Angry, 
    Smile, 
    Surprise
}

#endregion

// ��� ���
public enum BackGround
{
    Black,
    Hall,
    ClassRoom_Pro,
    Hall_Chap1,
    Library,
    TeacherRoom,
    Library_Room,
    Street
}

// ȭ�� ���� ���
public enum Direction
{
    Blank, FadeIn, FadeOut
}

// ȭ�� ���� ���� ���� ���
public enum BackGroundDirections
{
    Idle,
    Shake,
    Start
}

