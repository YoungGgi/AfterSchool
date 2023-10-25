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
        public string myText;                        // 대화 텍스트
        
        [Header("캐릭터 이름")]
        public Name charName;                        

        [Header("정효정 애니 / 표정")]
        public H_Anim h_Anim;                        
        public H_Sprite h_sprite;                    
        public H_Direction h_Direction;             
        public bool isHujung_CloseUp;               

        [Header("이용진 애니 / 표정")]
        public Y_Anim y_Anim;                        
        public Y_Sprite y_sprite;                   
        public Y_Direction y_Direction;              
        public bool isYoungjin_CloseUp;              

        [Header("은지수 애니 / 표정")]
        public J_Anim j_Anim;                        
        public J_Sprite j_sprite;                    
        public J_Direction j_Direction;              
        public bool isJisu_CloseUp;                  

        [Header("염민석 애니 / 표정")]
        public M_Anim m_Anim;                        
        public M_Sprite m_sprite;                    
        public M_Direction m_Direction;              
        public bool isMinseok_CloseUp;               

        [Header("BGM 재생기")]
        public bool isBGM_Change;                    
        public int BGM_Index;                        
        public bool isBGM_Stop;                      

        [Header("효과음 재생기")]
        public bool isDirectionSFX;                  
        public bool isClueOnSfx;                     
        public bool isEmotionSFx;                    
        public int SFX_Index;                        

        [Header("암전 연출")]
        public Direction direction;                  

        [Header("폰트 사이즈 키우기")]
        public bool isFontSizeUp;                    

        [Header("단서 획득")]
        public bool isFirstClue;
        public bool isSecondClue;
        public bool isThirdClue;
        public bool isForthClue;
        public bool isFiveClue;
        public bool isSixClue;

        public bool isClueReplace;

        [Header("UI 창 끄기")]
        public bool UI_Off;                           

        [Header("배경 흔들기 연출")]
        public BackGroundDirections back;             

        [Header("타이틀 / 오브젝트")]
        public bool Title_On;                         
        public bool Title_Two;                        
        public bool Title_Three;                      
        public bool Title_Four;                       

        [Header("배경")]
        public BackGround backGroundImg;              

        [Header("챕터 완료 상태")]
        public bool isPrologueClose;
        public bool isChapter1Close;
        public bool isChapter2Close;
        public bool isChapter3Close;
        public bool isEpilogueClose;

    }

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
    Bangbang,
    Center_Left,
    Center_Right,
    Left_Center,
    Right_Center,
    Left_Out,
    Right_Out,
    Out_Left,
    Out_Right
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
    Idle, Angry, Smile, Surprise, Shame
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
    Street,
    Pro_CutScene,
    Ch1_CutScene,
    Ch2_CutScene
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

