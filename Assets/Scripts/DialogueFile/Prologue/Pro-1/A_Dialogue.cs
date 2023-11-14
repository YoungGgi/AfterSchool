using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class A_Dialogue : MonoBehaviour
{
    
    [Header("대화 텍스트 / 배경 이미지 / 백로그")]
    public TextMeshProUGUI dialogueTxt;        // 대화 텍스트
    public TextMeshProUGUI nameTxt;            // 이름 텍스트
    public Image backGroundImg;                // 배경 이미지
    public BackGroundFold backGroundFold;      // 배경 이미지가 담긴 폴더
    public GameObject next;                    // 진행 화살표
    public GameObject textPrefab;              // 백로그용 텍스트 프리팹
    public Transform parentContents;           // 텍스트 프리팹 출력할 위치

    public CharacterNameMgn nameChanges;       // 캐릭터 관련 연출용 클래스

    [Header("텍스트 타이핑")]
    public float delay;                        // 텍스트 출력 딜레이
    private bool isTextTyping;                 // 텍스트 출력 논리 변수
    public bool isTextComplete = false;        // 대화 완료 논리 변수
    private string completeText;               // 출력할 대화

    private bool isDialoge;                   // 대화 진행 논리 변수

    [Header("대화 종료 시 활성/비활성 UI")]
    public GameObject dialogueUI;              // 대화 관련 전체 UI
    public GameObject dialoguePanelText;       // 대화창 UI
    public GameObject dialogueSetting;         // 대화 메뉴 관련 UI(오토, 2배속, 메뉴)

    [Header("캐릭터 이미지")]
    public Image hujungImg_CloseUp;           // 효정 클로즈업 이미지
    public Image youngjunImg_CloseUp;         // 용진 클로즈업 이미지
    public Image jisuImg_CloseUp;             // 지수 클로즈업 이미지
    public Image minseok_CloseUp;             // 민석 클로즈업 이미지

    // 캐릭터 표정 스프라이트 Scriptable
    [Header("캐릭터 감정표현")]
    public CharacterSprite hujung_Sprite;
    public CharacterSprite youngjing_Sprite;
    public CharacterSprite jisu_Sprite;
    public CharacterSprite minSeok_Sprite;

    // 캐릭터 별 애니메이션
    [Header("캐릭터 애니메이션")]
    public Animator Hujung;                    
    public Animator YoungJin;                  
    public Animator Jisu;                      
    public Animator MinSeok;                   
    

    [Header("연출 효과")]
    public Animator fadeManager;               // 화면 암전 연출
    public Animator backGroundEffect;          // 배경 흔들기 연출

    // 타이틀 or 오브젝트 출력
    public GameObject titleObj;
    public GameObject subTitleObj;
    public GameObject subTitleObj_2;
    public GameObject subTitleObj_3;

    // 대화중 단서 획득 오브젝트 및 단서 Scriptable
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
    public bool isGame;                            // 게임 진행 논리 변수
    public GameObject dialogueObject;              // 대화 관련 전체 UI
    public GameObject miniGameObject;              // 미니게임 관련 전체 UI

    // Dialogue_Base 정보를 dialogueInfo 리스트 할당
    public Queue<Dialogue_Base.Info> dialogueInfo = new Queue<Dialogue_Base.Info>();

    // 대화 관련 함수들을 호출할 델리게이트
    public delegate void DialogueDirections(Dialogue_Base.Info info);
    DialogueDirections directions;

    private void OnEnable()
    {
        // 대화 리스트 할당, 로딩(자동저장) 
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

    IEnumerator Loading()
    {
        yield return new WaitForSeconds(1.5f);
        dialogueUI.gameObject.SetActive(true);
    }

    private void Update()
    {
        NowScene = SceneManager.GetActiveScene();
        SceneNum = NowScene.buildIndex;

    }

    // 대화 리스트 시작(EnQueue)
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

    //대화 리스트 출력(DeQueue)
    public void DequeueDialogue()
    {
        #region TextTyping

        isTextComplete = false;

        // 대화가 모두 진행시 대화 종료 함수 실행(EndDialogue)
        if(dialogueInfo.Count == 0)
        {
            EndDialogue();
            return;
        }

        // 텍스트 타이핑 중일 경우 CompleteText 실행
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
        // Dequeue, info(Dialogue_Base) 정보 할당
        Dialogue_Base.Info info = dialogueInfo.Dequeue();

        completeText = info.myText;
        dialogueTxt.text = info.myText;
        directions(info);
        #endregion

        // 폰트 사이즈 키우기 연출
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
        // 백로그 호출
        if(dialogueTxt.text != "")
        {
            // 대화 텍스트 프리팹 생성
            GameObject clone = Instantiate(textPrefab, parentContents);

            // 현재 대화 텍스트를 할당해 백로그 호출 위치에 생성, 독백 중(Blank)일 경우 이름 텍스트 X
            if (info.charName == Name.Blank)
            {
                clone.GetComponent<TextMeshProUGUI>().text = dialogueTxt.text;
            }
            else
            {
                clone.GetComponent<TextMeshProUGUI>().text = nameTxt.text + " : " + dialogueTxt.text;

            }

        }

        #endregion

        #region UI_Off_Direction
        // StroyDataMgn의 isAutoStroy 상태일경우 대화 UI 비활성화
        StroyDataMgn.instance.IsAutoStory = info.UI_Off_Story;
        #endregion

        #region ChapterClose
        // 각 챕터 종료시 종료상황 저장후(ChapterCheck) 메인화면 이동
        if (info.isPrologueClose)
        {
            ChapterCheck.instance.PrologeClear(1);
            SceneManager.LoadScene(0);
        }

        if(info.isChapter1Close)
        {
            ChapterCheck.instance.Chapter1Clear(1);
            SceneManager.LoadScene(0);
        }

        if (info.isChapter2Close)
        {
            ChapterCheck.instance.Chapter2Clear(1);
            SceneManager.LoadScene(0);
        }

        if (info.isChapter3Close)
        {
            ChapterCheck.instance.Chapter3Clear(1);
            SceneManager.LoadScene(0);
        }

        if (info.isEpilogueClose)
        {
            ChapterCheck.instance.EpilogueClear(1);
            SceneManager.LoadScene(0);
        }

        #endregion

        dialogueTxt.text = "";
        StartCoroutine(TypeText(info));
    }

    // 배경 이미지 연출 함수
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

    // 캐릭터 이름 연출 함수
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
                nameTxt.text = PlayerName.instance.player + "&" + "효정";
                nameChanges.NameChangeDirection(10);
                break;
            case Name.HujungJisu:
                nameChanges.NameChangeDirection(11);
                break;
            case Name.PlayerYoungJin:
                nameTxt.text = PlayerName.instance.player + "&" + "용진";
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

    // 캐릭터 애니메이션 연출 함수
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

    // 캐릭터 표정 연출 함수
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
            case H_Sprite.Think:
                nameChanges.HujungSpriteDirection(4);
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
            case J_Sprite.Shame :
                nameChanges.JisuSpriteDirection(4);
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

    // 캐릭터 위치 연출 함수
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

    // 캐릭터 클로즈업 연출 함수
    public void CharacterCloseUp(Dialogue_Base.Info info)
    {
        hujungImg_CloseUp.color = info.isHujung_CloseUp ? new Color(225, 225, 225, 1) : new Color(225, 225, 225, 0);

        youngjunImg_CloseUp.color = info.isYoungjin_CloseUp ? new Color(225, 225, 225, 1) : new Color(225, 225, 225, 0);

        jisuImg_CloseUp.color = info.isJisu_CloseUp ? new Color(225, 225, 225, 1) : new Color(225, 225, 225, 0);

        minseok_CloseUp.color = info.isMinseok_CloseUp ? new Color(225, 225, 225, 1) : new Color(225, 225, 225, 0);
    }

    // 화면 암전, 단서 획득, 오브젝트 출력 연출 함수
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
        else if (info.UI_Off_Story)
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

    // BGM 플레이 함수
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

    // 효과음 플레이 함수
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

        if(info.isEmotionSFx)
        {
            SFX_Mgn.instance.SFX_Emotion_Play(info.SFX_Index);
        }

        if(info.isSFX_Off)
        {
            SFX_Mgn.instance.SFX_Stop();
        }
    }

    // 텍스트 타이핑 코루틴
    IEnumerator TypeText(Dialogue_Base.Info info)
    {
        isTextTyping = true;
        next.SetActive(false);

        // 현재 인덱스의 대화 텍스트 출력 기능
        foreach(char c in info.myText.ToCharArray())
        {
            /* 단서 획득 시를 제외한 모든 구간에서 타이핑 효과음 출력
            if (!info.UI_Off)
            {
               TextTyping_Player.instance.Typing_Play();    
            }
            */

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
