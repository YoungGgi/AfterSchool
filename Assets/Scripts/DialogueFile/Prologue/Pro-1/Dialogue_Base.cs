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
        public string myText;                        // 대화 내용
        
        [Header("캐릭터 이름")]
        public Name charName;                        // 화자(Enum)

        [Header("효정 연출")]
        public H_Anim h_Anim;                        // 효정 애니메이션
        public H_Sprite h_sprite;                    // 효정 스프라이트(표정)
        public H_Direction h_Direction;              // 효정 등장 위치
        public bool isHujung_CloseUp;                // 효정 클로즈업 여부 상태

        [Header("용진 연출")]
        public Y_Anim y_Anim;                        // 용진 애니메이션
        public Y_Sprite y_sprite;                    // 용진 스프라이트(표정)
        public Y_Direction y_Direction;              // 용진 등장 위치
        public bool isYoungjin_CloseUp;              // 용진 클로즈업 여부 상태

        [Header("지수 연출")]
        public J_Anim j_Anim;                        // 지수 애니메이션
        public J_Sprite j_sprite;                    // 지수 스프라이트(표정)
        public J_Direction j_Direction;              // 지수 등장 위치
        public bool isJisu_CloseUp;                  // 지수 클로즈업 여부 상태

        [Header("민석 연출")]
        public M_Anim m_Anim;                        // 민석 애니메이션
        public M_Sprite m_sprite;                    // 민석 스프라이트(표정)
        public M_Direction m_Direction;              // 민석 등장 위치
        public bool isMinseok_CloseUp;               // 민석 클로즈업 여부 상태

        [Header("BGM 플레이")]
        public bool isBGM_Change;                    // BGM 변경 여부 상태
        public int BGM_Index;                        // 변경할 BGM 인덱스
        public bool isBGM_Stop;                      // BGM 정지 여부 상태

        [Header("효과음 플레이")]
        public bool isDirectionSFX;                  // 연출용 효과음 목록 논리변수
        public int SFX_Index;                        // SFX 인덱스

        [Header("연출효과")]
        public Direction direction;                  // 화면 연출 (암전 유무)

        [Header("폰트 키우기 효과")]
        public bool isFontSizeUp;                    // 폰트 크기 키우기 여부 논리변수

        [Header("단서 획득")]
        // 단서 획득 시 상태 여부 (차례대로)
        public bool isFirstClue;
        public bool isSecondClue;
        public bool isThirdClue;
        public bool isForthClue;
        public bool isFiveClue;
        public bool isSixClue;

        [Header("대화창끄기")]
        public bool UI_Off;                           // 대화 UI 비활성화 여부 상태

        [Header("배경 흔들기 등 기타 연출")]
        public BackGroundDirections back;             // 배경 흔들기 연출

        [Header("타이틀")]
        public bool Title_On;                         // 타이틀 오브젝트1 출력 여부 상태
        public bool Title_Two;                        // 타이틀 오브젝트2 출력 여부 상태

        [Header("배경 이미지")]
        public BackGround backGroundImg;              // 출력할 배경 이미지

        [Header("챕터 종료 여부")]
        // 각 챕터 종료 여부 상태
        public bool isPrologueClose;
        public bool isChapter1Close;
        public bool isChapter2Close;
        public bool isChapter3Close;


    }

    // 해당 클래스를 리스트화
    public Info[] dialogueInfo;
}

// 캐릭터 이름 목록
public enum Name
{
    Blank, Player, Hujung, YoungJin, Jisu, MinSeok, Who, HujungYoung, Who_Jisu, Who_Min, 
    PlayerHujung, HujungJisu, PlayerYoungJin, All, Teacher, YoungJinJisu,
    Student01, Student02, Student03, Bear, Rabbit, Who_Hujung
}

// 효정 연출 목록
#region HujungEnum
public enum H_Anim                // 효정 애니메이션 목록
{ 
    Idle,
    H_Appear,
    H_DisAppear,
    Start,
    Bangbang
}

public enum H_Direction           // 효정 등장 위치 목록
{
    Center,
    Right,
    Left,
    Out
}

public enum H_Sprite              // 효정 표정 목록
{
    Idle,
    Angry,
    Smile,
    Surprise
}

#endregion

// 용진 연출 목록
#region YoungjingEnum
public enum Y_Anim                // 용진 애니메이션 목록
{
    Idle, 
    Y_Appear, 
    Y_DisAppear, 
    Start, 
    Y_Bangbang
}

public enum Y_Direction           // 용진 등장 위치 목록
{
    Center, 
    Right, 
    Left, 
    Out
}

public enum Y_Sprite               // 용진 표정 목록
{
    Idle, 
    Idle01, 
    Angry, 
    Smile, 
    Smile01, 
    Surprise
}

#endregion

// 지수 연출 목록
#region JisuEnum
public enum J_Anim             // 지수 애니메이션 목록
{
    Idle, 
    J_Appear, 
    J_DisAppear, 
    Start, 
    J_BangBang
}

public enum J_Direction         // 지수 등장 위치 목록
{
    Center, Right, Left, Out
}

public enum J_Sprite            // 지수 표정 목록
{
    Idle, Angry, Smile, Surprise
}

#endregion

// 민석 연출 목록
#region MinSeokEnum
public enum M_Anim              // 민석 애니메이션 목록
{
    Idle, 
    M_Appear, 
    M_DisAppear, 
    Start, 
    M_BangBang
}

public enum M_Direction           // 민석 등장 위치 목록
{
    Center, 
    Right, 
    Left, 
    Out
}

public enum M_Sprite             // 민석 표정 목록
{
    Idle, 
    Angry, 
    Smile, 
    Surprise
}

#endregion

// 배경 목록
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

// 화면 연출 목록
public enum Direction
{
    Blank, FadeIn, FadeOut
}

// 화면 흔들기 연출 상태 목록
public enum BackGroundDirections
{
    Idle,
    Shake,
    Start
}

