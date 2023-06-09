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

        [Header("��ȭ �ε���")]
        public int dialogueIndex;

        [Header("ĳ���� �̸�")]
        public Name charName;

        [Header("ĳ���� �̹���")]
        public Sprite Hujung;
        public Sprite Youngjin;

        [Header("ȿ�� �ִϸ��̼�")]
        public H_Anim h_Anim;
        [Header("���� �ִϸ��̼�")]
        public Y_Anim y_Anim;

        [Header("����ȿ��")]
        public Direction direction;

        [Header("���� üũ")]
        public bool isCheck;

        [Header("�ܼ�ȹ��")]
        public bool UI_Off;

        [Header("��� �̹���")]
        public Sprite backGround;


    }

    public Pro2[] dialogueInfo;

}


