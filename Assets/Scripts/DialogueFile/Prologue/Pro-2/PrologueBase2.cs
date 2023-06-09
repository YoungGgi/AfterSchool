using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dialogue2", menuName = "Dialogues2_sprite")]
public class PrologueBase2 : ScriptableObject
{
    [System.Serializable]
    public class Pro2
    {
        [TextArea(3, 12)]
        public string myText;

        [Header("대화 인덱스")]
        public int dialogueIndex;

        [Header("캐릭터 이름")]
        public Name charName;

        [Header("캐릭터 이미지")]
        public Sprite Hujung;
        public Sprite Youngjin;

        [Header("효정 애니메이션")]
        public H_Anim h_Anim;
        [Header("용진 애니메이션")]
        public Y_Anim y_Anim;

        [Header("연출효과")]
        public Direction direction;

        [Header("연출 체크")]
        public bool isCheck;

        [Header("단서획득")]
        public bool UI_Off;

        [Header("배경 이미지")]
        public Sprite backGround;


    }

    public Pro2[] dialogueInfo;

}


