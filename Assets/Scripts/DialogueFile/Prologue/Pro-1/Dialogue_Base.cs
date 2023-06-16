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
        
        [Header("대화 인덱스")]
        public int dialogueIndex;
        
        [Header("캐릭터 이름")]
        public Name charName;

        [Header("효정 애니메이션")]
        public H_Anim h_Anim;
        [Header("용진 애니메이션")]
        public Y_Anim y_Anim;
        [Header("지수 애니메이션")]
        public J_Anim j_Anim;
        [Header("민석 애니메이션")]
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
    Blank,
    Player,
    Hujung,
    YoungJin,
    Jisu,
    MinSeok,
    Who
}

public enum H_Anim
{ 
    Idle,
    H_Appear,
    H_DisAppear,
    Start,
    Bangbang
}

public enum Y_Anim
{
    Idle,
    Y_Appear,
    Y_DisAppear,
    Start,
    Y_Bangbang
}

public enum J_Anim
{
    Idle,
    J_Appear,
    J_DisAppear,
    Start
}

public enum M_Anim
{
    Idle,
    M_Appear,
    M_DisAppear,
    Start
}


public enum Direction
{
    Blank,
    FadeIn,
    FadeOut
}

