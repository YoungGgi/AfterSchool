using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class A_Dialogue : MonoBehaviour
{
    
    [Header("대화 텍스트 / 배경 이미지 / 백로그")]
    public TextMeshProUGUI dialogueTxt;        // ��ȭ �ؽ�Ʈ
    public TextMeshProUGUI nameTxt;            // �̸� �ؽ�Ʈ
    public Image backGroundImg;                // ��� �̹���
    public BackGroundFold backGroundFold;
    public GameObject next;                    // ȭ��ǥ ������Ʈ
    public GameObject textPrefab;              // ��α� ���� �ؽ�Ʈ ������
    public Transform parentContents;           // ��α��� Contents���� ��µ�

    public CharacterNameMgn nameChanges;

    [Header("텍스트 타이핑")]
    public float delay;                        //�ؽ�Ʈ ��� ������
    private bool isTextTyping;                 // �ؽ�Ʈ ��� ���� Ȯ��
    public bool isTextComplete = false;        // �ؽ�Ʈ ��� �ϼ� ���� Ȯ��
    private string completeText;               // �ϼ��� �ؽ�Ʈ

    private bool isDialoge;                   // ��ȭ ���� Ȯ��

    [Header("대화 종료 시 활성/비활성 UI")]
    public GameObject dialogueUI;              // ��ȭ�� ���� UI
    public GameObject dialoguePanelText;       // ��ȭâ UI
    public GameObject dialogueSetting;         // ��ȭ ��� UI(����, �α�, ����)

    [Header("캐릭터 이미지")]
    public Image hujungImg_CloseUp;           // ȿ�� Ŭ����� ��������Ʈ
    public Image youngjunImg_CloseUp;         // ���� Ŭ����� ��������Ʈ
    public Image jisuImg_CloseUp;             // ���� Ŭ����� ��������Ʈ
    public Image minseok_CloseUp;             // �μ� Ŭ����� ��������Ʈ

    // �� ĳ���� ǥ�� ��������Ʈ
    [Header("캐릭터 감정표현")]
    public CharacterSprite hujung_Sprite;
    public CharacterSprite youngjing_Sprite;
    public CharacterSprite jisu_Sprite;
    public CharacterSprite minSeok_Sprite;

    [Header("캐릭터 애니메이션")]
    public Animator Hujung;                    // ȿ�� ���� �ִϸ�����
    public Animator YoungJin;                  // ���� ���� �ִϸ�����
    public Animator Jisu;                      // ���� ���� �ִϸ�����
    public Animator MinSeok;                   // �μ� ���� �ִϸ�����
    

    [Header("연출 효과")]
    public Animator fadeManager;               // ���̵� �� / �ƿ� ���� ȿ��
    public Animator backGroundEffect;          // ��� ���� ȿ��

    // ���� Ÿ��Ʋ ������Ʈ��
    public GameObject titleObj;
    public GameObject subTitleObj;
    public GameObject subTitleObj_2;
    public GameObject subTitleObj_3;

    // ��ȭ ���� �� �߰��� �ܼ����
    [Header("단서 추가")]
    public ClueManager clue;
    public ClueObject clueObj0;
    public ClueObject clueObj1;
    public ClueObject clueObj2;
    public ClueObject clueObj3;
    public ClueObject clueObj4;
    public ClueObject clueObj5;

    public GameObject cluePopUp_0;
    public GameObject cluePopUp_1;
    public GameObject cluePopUp_2;
    public GameObject cluePopUp_3;
    public GameObject cluePopUp_4;
    public GameObject cluePopUp_5;
    public bool isClueUpdate;
    public bool isMainMenu_RedDot;

    public ClueObject replaceClue;
    public GameObject replaceCluePopUp;

    public Scene NowScene;
    public int SceneNum;

    [Header("미니게임용 UI")]
    public bool isGame;                            // �̴� ���� ���� ���� Ȯ�� ��������
    public GameObject dialogueObject;              // ��ȭ UI ������Ʈ �׷�
    public GameObject miniGameObject;              // �̴� ���� UI ������Ʈ �׷�


    // Dialogue_Base ���� ������ Queue�� ����
    public Queue<Dialogue_Base.Info> dialogueInfo = new Queue<Dialogue_Base.Info>();

    // ����� �Լ����� ȣ���ų ��������Ʈ ����
    public delegate void DialogueDirections(Dialogue_Base.Info info);
    DialogueDirections directions;

    private void OnEnable()
    {
        // �ش� ������Ʈ Ȱ��ȭ �� ��ȭ ���� UI ��� ��Ȱ��ȭ
        Time.timeScale = 1;
        dialogueInfo = new Queue<Dialogue_Base.Info>();
        dialogueUI.gameObject.SetActive(false);
        StartCoroutine(Loading());

        StroyDataMgn.instance.IsSettingOn = false;

        directions += CharacterName;
        directions += CharacterAnim;
        directions += CharacterEmotion;
        directions += CharacterDirection;
        directions += CharacterCloseUp;
        directions += BackGroundChange;
        directions += BackGroundDirection;
        directions += BGM_Play;
        directions += SFX_Play;
    }

    // ���� ���� �� �ε� ȭ��(�ڵ�����) ���� �� ������ �� ��ȭ ȭ�� ����
    IEnumerator Loading()
    {
        yield return new WaitForSeconds(1.5f);
        dialogueUI.gameObject.SetActive(true);
    }

    private void Update()
    {
        NowScene = SceneManager.GetActiveScene(); // �� �����Ӹ��� ���� �� Ȯ���ϱ�
        SceneNum = NowScene.buildIndex;

    }

    // ��ȭ ����Ʈ ����(EnQueue)
    public void EnqueuDialogue(Dialogue_Base db)
    {
        if (isDialoge) return;

        isDialoge = true;

        dialogueInfo.Clear();

        foreach(Dialogue_Base.Info info in db.dialogueInfo)
        {
            dialogueInfo.Enqueue(info);
        }

        DequeueDialogue();

    }

    //��ȭ ��� ����(DeQueue)
    public void DequeueDialogue()
    {
        #region TextTyping

        isTextComplete = false;

        // �ش� ��� ����Ʈ�� ���� ��µǾ��ٸ� ��ȭ ���� �Լ�(EndDialogue)�� �̵�
        if(dialogueInfo.Count == 0)
        {
            EndDialogue();
            return;
        }

        // �ؽ�Ʈ�� ��� ���� ��� 
        if(isTextTyping == true)
        {
            CompleteText();
            StopAllCoroutines();
            isTextTyping = false;
            isTextComplete = true;
            return;
        }
        #endregion

        #region DequeueCon
        // Dequeue, info(Dialogue_Base)�� �ִ� ���� ���
        Dialogue_Base.Info info = dialogueInfo.Dequeue();

        // ��ȭ �ؽ�Ʈ�� �̸� �ؽ�Ʈ, ����� �Լ��� info ���� �Ҵ�
        completeText = info.myText;
        dialogueTxt.text = info.myText;
        directions(info);
        #endregion

        // ��Ʈ ������ ũ�� �����
        if(info.isFontSizeUp)
        {
            dialogueTxt.fontSize = 55;
            dialogueTxt.fontStyle = FontStyles.Bold;
        }
        else
        {
            dialogueTxt.fontSize = 48;
            dialogueTxt.fontStyle = FontStyles.Normal;
        }


        #region BackLog
        // ��α� �ؽ�Ʈ ��� �Լ�
        if(dialogueTxt.text != "")
        {
            // �ؽ�Ʈ ������ ��ȯ
            GameObject clone = Instantiate(textPrefab, parentContents);

            // �̸� �ؽ�Ʈ�� '����'�� ���(����) �̸� �ؽ�Ʈ ��� X
            if (info.charName == Name.Blank)
            {
                clone.GetComponent<TextMeshProUGUI>().text = dialogueTxt.text;
            }
            else
            {
                clone.GetComponent<TextMeshProUGUI>().text = nameTxt.text + " : " + dialogueTxt.text;

            }

            // �ܼ� ȹ�� �� �ؽ�Ʈ ������ �÷� ����
            /*
            if (info.isFirstClue || info.isSecondClue || info.isThirdClue || info.isForthClue || info.isFiveClue || info.isSixClue)
            {
                clone.GetComponent<TextMeshProUGUI>().color = Color.yellow;
            }
            else
            {
                clone.GetComponent<TextMeshProUGUI>().color = Color.black;
            }
            */
        }

        #endregion

        #region UI_Off_Direction
        // ��ȭâ UI�� ��Ȱ��ȭ�Ǵ� ������ ��� StroyDataMgn�� isAutoStroy Ȱ��ȭ
        StroyDataMgn.instance.IsAutoStory = info.UI_Off;
        #endregion

        #region ChapterClose
        // �� é�� ����� ���� �κ�� �̵�
        if (info.isPrologueClose)
        {
            ChapterCheck.instance.isPrologueComplete = true;
            SceneManager.LoadScene(0);
        }

        if(info.isChapter1Close)
        {
            ChapterCheck.instance.is1ChapComplete = true;
            SceneManager.LoadScene(0);
        }

        if (info.isChapter2Close)
        {
            ChapterCheck.instance.is2ChapComplete = true;
            SceneManager.LoadScene(0);
        }

        if (info.isChapter3Close)
        {
            ChapterCheck.instance.is3ChapComplete = true;
            SceneManager.LoadScene(0);

        }

        #endregion

        dialogueTxt.text = "";
        StartCoroutine(TypeText(info));
    }

    // ��ȭ ���� �� ��� ���� �Լ�
    public void BackGroundChange(Dialogue_Base.Info info)
    {
        switch (info.backGroundImg)
        {
            case BackGround.Black:
                backGroundImg.sprite = backGroundFold.backGround[0];
                break;
            case BackGround.Hall:
                backGroundImg.sprite = backGroundFold.backGround[1];
                break;
            case BackGround.ClassRoom_Pro:
                backGroundImg.sprite = backGroundFold.backGround[2];
                break;
            case BackGround.Hall_Chap1:
                backGroundImg.sprite = backGroundFold.backGround[3];
                break;
            case BackGround.Library:
                backGroundImg.sprite = backGroundFold.backGround[4];
                break;
            case BackGround.TeacherRoom:
                backGroundImg.sprite = backGroundFold.backGround[5];
                break;
            case BackGround.Library_Room:
                backGroundImg.sprite = backGroundFold.backGround[6];
                break;
            case BackGround.Street:
                backGroundImg.sprite = backGroundFold.backGround[7];
                break;
            case BackGround.Pro_CutScene:
                backGroundImg.sprite = backGroundFold.backGround[8];
                break;
            case BackGround.Ch1_CutScene:
                backGroundImg.sprite = backGroundFold.backGround[9];
                break;
            case BackGround.Ch2_CutScene:
                backGroundImg.sprite = backGroundFold.backGround[10];
                break;
        }
    }

    // ��ȭ ���� �� ĳ���� �̸� �Լ�
    public void CharacterName(Dialogue_Base.Info info)
    {
        switch (info.charName)
        {
            case Name.Blank:
                nameChanges.NameChangeDirection(0);
                break;
            case Name.Player:
                nameTxt.text = PlayerName.instance.player;
                nameChanges.NameChangeDirection(1);
                break;
            case Name.Hujung:
                nameChanges.NameChangeDirection(2);
                break;
            case Name.YoungJin:
                nameChanges.NameChangeDirection(3);
                break;
            case Name.Jisu:
                nameChanges.NameChangeDirection(4);
                break;
            case Name.MinSeok:
                nameChanges.NameChangeDirection(5);
                break;
            case Name.Who:
                nameChanges.NameChangeDirection(6);
                break;
            case Name.HujungYoung:
                nameChanges.NameChangeDirection(7);
                break;
            case Name.Who_Jisu:
                nameChanges.NameChangeDirection(8);
                break;
            case Name.Who_Min:
                nameChanges.NameChangeDirection(9);
                break;
            case Name.PlayerHujung:
                nameTxt.text = PlayerName.instance.player + "&" + "ȿ��";
                nameChanges.NameChangeDirection(10);
                break;
            case Name.HujungJisu:
                nameChanges.NameChangeDirection(11);
                break;
            case Name.PlayerYoungJin:
                nameTxt.text = PlayerName.instance.player + "&" + "����";
                nameChanges.NameChangeDirection(12);
                break;
            case Name.All:
                nameChanges.NameChangeDirection(13);
                break;
            case Name.Teacher:
                nameChanges.NameChangeDirection(14);
                break;
            case Name.YoungJinJisu:
                nameChanges.NameChangeDirection(15);
                break;
            case Name.Student01:
                nameChanges.NameChangeDirection(16);
                break;
            case Name.Student02:
                nameChanges.NameChangeDirection(17);
                break;
            case Name.Student03:
                nameChanges.NameChangeDirection(18);
                break;
            case Name.Bear:
                nameChanges.NameChangeDirection(19);
                break;
            case Name.Rabbit:
                nameChanges.NameChangeDirection(20);
                break;
            case Name.Who_Hujung:
                nameChanges.NameChangeDirection(21);
                break;
        }
    }

    // ��ȭ ���� �� ĳ���� �ִϸ��̼� �Լ�
    public void CharacterAnim(Dialogue_Base.Info info)
    {

        #region HujungAnim
        // ���� �ִϸ��̼�
        if (info.h_Anim == H_Anim.H_Appear)
        {
            Hujung.Play("H_Appear");
        }

        if (info.h_Anim == H_Anim.H_DisAppear)
        {
            Hujung.Play("H_DisAppear");
        }

        if(info.h_Anim == H_Anim.Start)
        {
            Hujung.Play("H_Start");
        }

        if (info.h_Anim == H_Anim.Bangbang)
        {
            Hujung.Play("H_BangBang");
        }

        #endregion

        #region YoungJinAnim
        // ���� �ִϸ��̼�
        if (info.y_Anim == Y_Anim.Y_Appear)
        {
            YoungJin.Play("Y_Appear");
        }

        if (info.y_Anim == Y_Anim.Y_DisAppear)
        {
            YoungJin.Play("Y_DisAppear");
        }

        if (info.y_Anim == Y_Anim.Start)
        {
            YoungJin.Play("Y_Start");
        }

        if (info.y_Anim == Y_Anim.Y_Bangbang)
        {
            YoungJin.Play("Y_Bangbang");
        }
        
        #endregion

        #region JisuAnim
        if (info.j_Anim == J_Anim.J_Appear)
        {
            Jisu.Play("J_Appear");
        }

        if (info.j_Anim == J_Anim.J_DisAppear)
        {
            Jisu.Play("J_DisAppear");
        }

        if (info.j_Anim == J_Anim.Start)
        {
            Jisu.Play("J_Start");
        }

        if (info.j_Anim == J_Anim.J_BangBang)
        {
            Jisu.Play("J_BangBang");
        }

        #endregion

        #region MinSeokAnim
        // �μ� �ִϸ��̼� ���
        if (info.m_Anim == M_Anim.M_Appear)
        {
            MinSeok.Play("M_Appear");
        }

        if (info.m_Anim == M_Anim.M_DisAppear)
        {
            MinSeok.Play("M_DisAppear");
        }

        if (info.m_Anim == M_Anim.Start)
        {
            MinSeok.Play("M_Start");
        }

        if(info.m_Anim == M_Anim.M_BangBang)
        {
            MinSeok.Play("M_BangBang");
        }
        #endregion

    }

    // ��ȭ ���� �� ĳ���� ǥ�� ��ȭ �Լ�
    public void CharacterEmotion(Dialogue_Base.Info info)
    {
        #region HujungEmotion
        switch(info.h_sprite)
        {
            case H_Sprite.Idle:
                nameChanges.HujungSpriteDirection(0);
                break;
            case H_Sprite.Angry:
                nameChanges.HujungSpriteDirection(1);
                break;
            case H_Sprite.Smile:
                nameChanges.HujungSpriteDirection(2);
                break;
            case H_Sprite.Surprise:
                nameChanges.HujungSpriteDirection(3);
                break;
        }
        #endregion

        #region YoungjinEmotion
        switch(info.y_sprite)
        {
            case Y_Sprite.Idle:
                nameChanges.YoungJinSpriteDirection(0);
                break;
            case Y_Sprite.Idle01:
                nameChanges.YoungJinSpriteDirection(1);
                break;
            case Y_Sprite.Angry:
                nameChanges.YoungJinSpriteDirection(2);
                break;
            case Y_Sprite.Smile:
                nameChanges.YoungJinSpriteDirection(3);
                break;
            case Y_Sprite.Smile01:
                nameChanges.YoungJinSpriteDirection(4);
                break;
            case Y_Sprite.Surprise:
                nameChanges.YoungJinSpriteDirection(5);
                break;
        }
        #endregion

        #region JisuEmotion
        switch (info.j_sprite)
        {
            case J_Sprite.Idle:
                nameChanges.JisuSpriteDirection(0);
                break;
            case J_Sprite.Angry:
                nameChanges.JisuSpriteDirection(1);
                break;
            case J_Sprite.Smile:
                nameChanges.JisuSpriteDirection(2);
                break;
            case J_Sprite.Surprise:
                nameChanges.JisuSpriteDirection(3);
                break;
        }
        #endregion

        #region MinSeokEmotion
        switch (info.m_sprite)
        {
            case M_Sprite.Idle:
                nameChanges.MinSeokSpriteDirection(0);
                break;
            case M_Sprite.Angry:
                nameChanges.MinSeokSpriteDirection(1);
                break;
            case M_Sprite.Smile:
                nameChanges.MinSeokSpriteDirection(2);
                break;
            case M_Sprite.Surprise:
                nameChanges.MinSeokSpriteDirection(3);
                break;
        }
        #endregion
    }

    // ��ȭ ���� �� ĳ���� ��ġ ���� �Լ�
    public void CharacterDirection(Dialogue_Base.Info info)
    {
        
        #region CharacterDirection

        #region HujungImgDirection

        switch (info.h_Direction)
        {
            case H_Direction.Center:
                nameChanges.HujungPosition(0);
                break;
            case H_Direction.Right:
                nameChanges.HujungPosition(1);
                break;
            case H_Direction.Left:
                nameChanges.HujungPosition(2);
                break;
            case H_Direction.Out:
                nameChanges.HujungPosition(3);
                break;
        }

        #endregion

        #region YoungjinImgDirection

        switch (info.y_Direction)
        {
            case Y_Direction.Center:
                nameChanges.YoungJinPosition(0);
                break;
            case Y_Direction.Right:
                nameChanges.YoungJinPosition(1);
                break;
            case Y_Direction.Left:
                nameChanges.YoungJinPosition(2);
                break;
            case Y_Direction.Out:
                nameChanges.YoungJinPosition(3);
                break;

        }

        #endregion

        #region JisuImgDirection

        switch (info.j_Direction)
        {
            case J_Direction.Center:
                nameChanges.JisuPosition(0);
                break;
            case J_Direction.Right:
                nameChanges.JisuPosition(1);
                break;
            case J_Direction.Left:
                nameChanges.JisuPosition(2);
                break;
            case J_Direction.Out:
                nameChanges.JisuPosition(3);
                break;
        }
        #endregion

        #region MinSeokImgDirection

        switch (info.m_Direction)
        {
            case M_Direction.Center:
                nameChanges.MinSeokPosition(0);
                break;
            case M_Direction.Right:
                nameChanges.MinSeokPosition(1);
                break;
            case M_Direction.Left:
                nameChanges.MinSeokPosition(2);
                break;
            case M_Direction.Out:
                nameChanges.MinSeokPosition(3);
                break;
        }
        #endregion

        #endregion

    }

    // ��ȭ ���� �� ĳ���� Ŭ�����
    public void CharacterCloseUp(Dialogue_Base.Info info)
    {
        hujungImg_CloseUp.color = info.isHujung_CloseUp ? new Color(225, 225, 225, 1) : new Color(225, 225, 225, 0);

        youngjunImg_CloseUp.color = info.isYoungjin_CloseUp ? new Color(225, 225, 225, 1) : new Color(225, 225, 225, 0);

        jisuImg_CloseUp.color = info.isJisu_CloseUp ? new Color(225, 225, 225, 1) : new Color(225, 225, 225, 0);

        minseok_CloseUp.color = info.isMinseok_CloseUp ? new Color(225, 225, 225, 1) : new Color(225, 225, 225, 0);
    }

    // ��ȭ ���� �� ��Ÿ ���� �Լ�(ȭ�� ����, �ܼ� ȹ��, Ÿ��Ʋ ���� ��)
    public void BackGroundDirection(Dialogue_Base.Info info)
    {
        #region Direction
        if (info.direction == Direction.FadeIn)
        {
            fadeManager.Play("FadeIn");
        }

        if (info.direction == Direction.FadeOut)
        {
            fadeManager.Play("FadeOut");
        }

        if (info.back == BackGroundDirections.Idle)
        {
            backGroundEffect.Play("Back_Idle");
        }

        if (info.back == BackGroundDirections.Shake)
        {
            backGroundEffect.Play("Back_Shake");
        }

        if (info.UI_Off)
        {
            dialoguePanelText.gameObject.SetActive(false);
            dialogueSetting.gameObject.SetActive(false);
            isMainMenu_RedDot = true;
        }
        else
        {
            dialoguePanelText.gameObject.SetActive(true);
            dialogueSetting.gameObject.SetActive(true);
            isMainMenu_RedDot = false;
        }

        if (info.Title_On)
        {
            titleObj.gameObject.SetActive(true);
        }
        else
        {
            titleObj.gameObject.SetActive(false);
        }

        if (info.Title_Two)
        {
            subTitleObj.gameObject.SetActive(true);
        }
        else
        {
            subTitleObj.gameObject.SetActive(false);
        }

        if (info.Title_Three)
        {
            subTitleObj_2.gameObject.SetActive(true);
        }
        else
        {
            subTitleObj_2.gameObject.SetActive(false);
        }

        if (info.Title_Four)
        {
            subTitleObj_3.gameObject.SetActive(true);
        }
        else
        {
            subTitleObj_3.gameObject.SetActive(false);
        }

        #endregion

        #region Inven
        if (info.isFirstClue)
        {
            cluePopUp_0.SetActive(true);
            clue.clues.Add(clueObj0);
            clue.clueAddCount++;
            isClueUpdate = true;
        }
        else
        {
            cluePopUp_0.SetActive(false);
        }

        if (info.isSecondClue)
        {
            cluePopUp_1.SetActive(true);
            clue.clues.Add(clueObj1);
            clue.clueAddCount++;
            isClueUpdate = true;
        }
        else
        {
            cluePopUp_1.SetActive(false);
        }

        if (info.isThirdClue)
        {
            cluePopUp_2.SetActive(true);
            clue.clues.Add(clueObj2);
            clue.clueAddCount++;
            isClueUpdate = true;
        }
        else
        {
            cluePopUp_2.SetActive(false);
        }

        if (info.isForthClue)
        {
            cluePopUp_3.SetActive(true);
            clue.clues.Add(clueObj3);
            clue.clueAddCount++;
            isClueUpdate = true;
        }
        else
        {
            cluePopUp_3.SetActive(false);
        }

        if (info.isFiveClue)
        {
            cluePopUp_4.SetActive(true);
            clue.clues.Add(clueObj4);
            clue.clueAddCount++;
            isClueUpdate = true;
        }
        else
        {
            cluePopUp_4.SetActive(false);
        }

        if (info.isSixClue)
        {
            cluePopUp_5.SetActive(true);
            clue.clues.Add(clueObj5);
            clue.clueAddCount++;
            isClueUpdate = true;
        }
        else
        {
            cluePopUp_5.SetActive(false);
        }

        if (info.isClueReplace)
        {
            replaceClue.clueExplain = replaceClue.replaceExplain;
            replaceCluePopUp.SetActive(true);
        }
        else
        {
            replaceCluePopUp.SetActive(false);
        }

        #endregion
    }

    // ��ȭ ���� �� BGM ���� �Լ�
    public void BGM_Play(Dialogue_Base.Info info)
    {
        if (info.isBGM_Stop)
        {
            BGM_Mgn.instance.BGM_Stop();
        }

        if (!info.isBGM_Change)
        {
            return;
        }
        else
        {
            BGM_Mgn.instance.BGM_Change(info.BGM_Index);
        }
    }

    // ��ȭ ���� �� ȿ���� ���� �Լ�
    public void SFX_Play(Dialogue_Base.Info info)
    {
        
        if (info.isDirectionSFX)
        {
            SFX_Mgn.instance.SFX_Direction_Play(info.SFX_Index);
        }

        if (info.isClueOnSfx)
        {
            SFX_Mgn.instance.SFX_Clue_Play(info.SFX_Index);
        }
    }

    // �ؽ�Ʈ �Է� �ڷ�ƾ
    IEnumerator TypeText(Dialogue_Base.Info info)
    {
        isTextTyping = true;
        next.SetActive(false);

        // 현재 인덱스의 대화 텍스트 출력 기능
        foreach(char c in info.myText.ToCharArray())
        {
            // 단서 획득 시를 제외한 모든 구간에서 타이핑 효과음 출력
            if (!info.isFirstClue || !info.isSecondClue || !info.isThirdClue 
                || !info.isForthClue || !info.isFiveClue || !info.isSixClue)
            {
               TextTyping_Player.instance.Typing_Play();    
            }
            
            // 2배속 설정 시 텍스트 출력 속도 변화
            if(StroyDataMgn.instance.IsTwoSpeed)
            {
                float twoDelay = (float)(delay * 0.2);
                yield return new WaitForSeconds(twoDelay);
            }
            else
            {
                yield return new WaitForSeconds(delay);
            }
            dialogueTxt.text += c;
        }
        // 텍스트 모두 출력 시 화살표 생성, 딜레이 후 isTextComplete true
        next.SetActive(true);
        isTextTyping = false;
        yield return new WaitForSeconds(2f);
        isTextComplete = true;
        
    }

    // 텍스트를 바로 전부 출력시키는 함수
    private void CompleteText()
    {
        isTextComplete = true;
        dialogueTxt.text = completeText;
        next.SetActive(true);
    }

    // 대화 종료 함수
    public void EndDialogue()
    {
        isDialoge = false;
        dialogueUI.SetActive(false);

        // 종료 후 미니게임이 없으면 다음 씬 이동
        if (!isGame)
        {
            SceneManager.LoadScene(SceneNum + 1);
            return;
        }
        else
        {
            dialogueObject.SetActive(false);
            miniGameObject.SetActive(true);
        }
    }

}
