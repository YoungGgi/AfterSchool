using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class A_Dialogue : MonoBehaviour
{
    
    [Header("DialogueGroup")]
    public TextMeshProUGUI dialogueTxt;        // 대화 텍스트
    public TextMeshProUGUI nameTxt;            // 이름 텍스트
    public Image backGroundImg;                // 배경 이미지
    public BackGroundFold backGroundFold;
    public GameObject next;                    // 화살표 오브젝트
    public GameObject textPrefab;              // 백로그 전용 텍스트 프리팹
    public Transform parentContents;           // 백로그의 Contents에서 출력됨

    [Header("TextTypingGroup")]
    public float delay;                        //텍스트 출력 딜레이
    private bool isTextTyping;                 // 텍스트 출력 여부 확인
    public bool isTextComplete = false;               // 텍스트 출력 완성 여부 확인
    private string completeText;               // 완성된 텍스트

    private bool isDialoge;                   // 대화 여부 확인

    [Header("DialogueEnd")]
    public GameObject dialogueUI;              // 대화씬 전용 UI
    public GameObject dialoguePanelText;       // 대화창 UI
    public GameObject dialogueSetting;         // 대화 기능 UI(오토, 로그, 설정)

    [Header("Character")]
    public Image hujungImg;                   // 효정 스프라이트
    public Image hujungImg_CloseUp;           // 효정 클로즈업 스프라이트
    public Image youngjinImg;                 // 용진 스프라이트
    public Image youngjunImg_CloseUp;         // 용진 클로즈업 스프라이트
    public Image jisuImg;                     // 지수 스프라이트
    public Image jisuImg_CloseUp;             // 지수 클로즈업 스프라이트
    public Image minSeckImg;                  // 민석 스프라이트
    public Image minseok_CloseUp;             // 민석 클로즈업 스프라이트
    public Transform center;                  // 캐릭터 위치(용진)
    public Transform left;
    public Transform right;
    public Transform out_pos;
    public RectTransform center1;             // 캐릭터 위치(효정, 지수, 민석?)
    public RectTransform left1;
    public RectTransform right1;

    [Header("Character_Emotion")]             // 각 캐릭터 표정 스프라이트
    public CharacterSprite hujung_Sprite;
    public CharacterSprite youngjing_Sprite;
    public CharacterSprite jisu_Sprite;
    public CharacterSprite minSeok_Sprite;

    [Header("Animation")]
    public Animator Hujung;                    // 효정 전용 애니메이터
    public Animator YoungJin;                  // 용진 전용 애니메이터
    public Animator Jisu;                      // 지수 전용 애니메이터
    public Animator MinSeok;                   // 민석 전용 애니메이터
    

    [Header("Direction")]
    public Animator fadeManager;               // 페이드 인 / 아웃 전용 효과
    
    public GameObject titleObj;                // 게임 타이틀 오브젝트
    public GameObject subTitleObj;

    [Header("Add Clue")]                       // 대화 진행 중 추가될 단서목록
    public ClueManager clue;
    public ClueObject clueObj0;
    public ClueObject clueObj1;
    public ClueObject clueObj2;
    public ClueObject clueObj3;
    public bool isClueUpdate;

    public Scene NowScene;
    public int SceneNum;

    // Dialogue_Base 에서 선언한 Queue문 선언
    public Queue<Dialogue_Base.Info> dialogueInfo = new Queue<Dialogue_Base.Info>();

    private void OnEnable()
    {
        dialogueInfo = new Queue<Dialogue_Base.Info>();
        dialogueUI.gameObject.SetActive(false);
        StartCoroutine(Loading());

        StroyDataMgn.instance.isSettingOn = false;
    }

    // 게임 시작 시 로딩 화면(자동저장) 출력, 딜레이 후 대화 화면 등장
    IEnumerator Loading()
    {
        yield return new WaitForSeconds(1.5f);
        dialogueUI.gameObject.SetActive(true);
    }

    private void Update()
    {
        NowScene = SceneManager.GetActiveScene(); // 매 프레임마다 현재 씬 확인하기
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

    //대화 출력 시작(DeQueue)
    public void DequeueDialogue()
    {
        #region TextTyping
        isTextComplete = false;

        // 해당 대사 리스트가 전부 끝났다면 대화 종료 함수로 이동
        if(dialogueInfo.Count == 0)
        {
            EndDialogue();
            return;
        }

        // 텍스트가 출력 중일 경우 
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
        // Dequeue, info(Dialogue_Base)에 있는 정보 담기
        Dialogue_Base.Info info = dialogueInfo.Dequeue();

        completeText = info.myText;

        dialogueTxt.text = info.myText;

        BackGroundChange(info);
        #endregion

        hujungImg_CloseUp.color = info.isHujung_CloseUp ? new Color(225, 225, 225, 1) : new Color(225, 225, 225, 0);

        youngjunImg_CloseUp.color = info.isYoungjin_CloseUp ? new Color(225, 225, 225, 1) : new Color(225, 225, 225, 0);

        jisuImg_CloseUp.color = info.isJisu_CloseUp ? new Color(225, 225, 225, 1) : new Color(225, 225, 225, 0);

        minseok_CloseUp.color = info.isMinseok_CloseUp ? new Color(225, 225, 225, 1) : new Color(225, 225, 225, 0);

        CharacterName(info);

        CharacterAnim(info);

        CharacterEmotion(info);

        CharacterDirection(info);

        BackGroundDirection(info);
 

        #region BackLog
        // 백로그 텍스트 등록
        if(dialogueTxt.text != "")
        {
            GameObject clone = Instantiate(textPrefab, parentContents);

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
        StroyDataMgn.instance.isAutoStory = info.UI_Off;
        #endregion


        #region ChapterClose
        // 챕터 종료시 메인 로비로 이동
        if (info.isPrologueClose)
        {
            ChapterCheck.instance.isPrologueComplete = true;
            SceneManager.LoadScene(0);
        }
        #endregion

        dialogueTxt.text = "";
        StartCoroutine(TypeText(info));
    }

    // 대화 진행 중 배경 설정 함수
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
        }
    }

    // 대화 진행 중 캐릭터 이름 함수
    public void CharacterName(Dialogue_Base.Info info)
    {
        switch (info.charName)
        {
            case Name.Blank:
                nameTxt.text = "";
                nameTxt.color = Color.white;
                dialogueTxt.color = Color.white;
                hujungImg.color = youngjinImg.color = jisuImg.color = minSeckImg.color = Color.gray;
                break;
            case Name.Player:
                nameTxt.text = PlayerName.instance.player;
                nameTxt.color = Color.white;
                dialogueTxt.color = Color.white;
                hujungImg.color = youngjinImg.color = jisuImg.color = minSeckImg.color = Color.gray;
                break;
            case Name.Hujung:
                nameTxt.text = "정효정";
                hujungImg.color = new Color(255, 255, 255);
                nameTxt.color = Color.white;
                dialogueTxt.color = Color.white;
                youngjinImg.color = jisuImg.color = minSeckImg.color = Color.gray;
                break;
            case Name.YoungJin:
                nameTxt.text = "이용진";
                youngjinImg.color = new Color(255, 255, 255);
                nameTxt.color = Color.white;
                dialogueTxt.color = Color.white;
                hujungImg.color = jisuImg.color = minSeckImg.color = Color.gray;
                break;
            case Name.Jisu:
                nameTxt.text = "은지수";
                jisuImg.color = new Color(255, 255, 255);
                nameTxt.color = Color.white;
                dialogueTxt.color = Color.white;
                hujungImg.color = youngjinImg.color = minSeckImg.color = Color.gray;
                break;
            case Name.MinSeok:
                nameTxt.text = "염민석";
                minSeckImg.color = new Color(255, 255, 255);
                nameTxt.color = Color.white;
                dialogueTxt.color = Color.white;
                hujungImg.color = youngjinImg.color = jisuImg.color = Color.gray;
                break;
            case Name.Who:
                nameTxt.text = "???";
                nameTxt.color = Color.white;
                dialogueTxt.color = Color.white;
                hujungImg.color = youngjinImg.color = jisuImg.color = minSeckImg.color = Color.gray;
                break;
            case Name.HujungYoung:
                nameTxt.text = "효정&용진";
                nameTxt.color = Color.white;
                dialogueTxt.color = Color.white;
                hujungImg.color = youngjinImg.color = new Color(255, 255, 255);
                break;
            case Name.Who_Jisu:
                nameTxt.text = "???";
                jisuImg.color = new Color(255, 255, 255);
                nameTxt.color = Color.white;
                dialogueTxt.color = Color.white;
                hujungImg.color = youngjinImg.color = minSeckImg.color = Color.gray;
                break;
            case Name.Who_Min:
                nameTxt.text = "???";
                minSeckImg.color = new Color(255, 255, 255);
                nameTxt.color = Color.white;
                dialogueTxt.color = Color.white;
                hujungImg.color = youngjinImg.color = jisuImg.color = Color.gray;
                break;
            case Name.PlayerHujung:
                nameTxt.text = PlayerName.instance.player + "&" + "효정";
                hujungImg.color = new Color(255, 255, 255);
                nameTxt.color = Color.white;
                dialogueTxt.color = Color.white;
                youngjinImg.color = jisuImg.color = minSeckImg.color = Color.gray;
                break;
            case Name.HujungJisu:
                nameTxt.text = "효정&지수";
                nameTxt.color = Color.white;
                dialogueTxt.color = Color.white;
                hujungImg.color = jisuImg.color = new Color(255, 255, 255);
                youngjinImg.color = Color.gray;
                break;
            case Name.PlayerYoungJin:
                nameTxt.text = PlayerName.instance.player + "&" + "용진";
                youngjinImg.color = new Color(255, 255, 255);
                nameTxt.color = Color.white;
                dialogueTxt.color = Color.white;
                hujungImg.color = jisuImg.color = minSeckImg.color = Color.gray;
                break;
            case Name.All:
                nameTxt.text = "일동";
                nameTxt.color = Color.white;
                dialogueTxt.color = Color.white;
                break;
            case Name.Teacher:
                nameTxt.text = "선생님";
                nameTxt.color = Color.white;
                dialogueTxt.color = Color.white;
                hujungImg.color = youngjinImg.color = jisuImg.color = minSeckImg.color = Color.gray;
                break;
            case Name.YoungJinJisu:
                nameTxt.text = "용진&지수";
                youngjinImg.color = jisuImg.color = new Color(255, 255, 255);
                nameTxt.color = Color.white;
                dialogueTxt.color = Color.white;
                hujungImg.color = minSeckImg.color = Color.gray;
                break;
            case Name.Student01:
                nameTxt.text = "학생1";
                hujungImg.color = youngjinImg.color = jisuImg.color = minSeckImg.color = Color.gray;
                break;
            case Name.Student02:
                nameTxt.text = "학생2";
                hujungImg.color = youngjinImg.color = jisuImg.color = minSeckImg.color = Color.gray;
                break;
            case Name.Student03:
                nameTxt.text = "학생3";
                hujungImg.color = youngjinImg.color = jisuImg.color = minSeckImg.color = Color.gray;
                break;
            case Name.Bear:
                nameTxt.text = "기지개를 펴는 곰탱이";
                nameTxt.color = Color.gray;
                dialogueTxt.color = Color.yellow;
                hujungImg.color = youngjinImg.color = jisuImg.color = minSeckImg.color = Color.gray;
                break;
            case Name.Rabbit:
                nameTxt.text = "노래를 부르는 토끼";
                nameTxt.color = Color.gray;
                dialogueTxt.color = Color.yellow;
                hujungImg.color = youngjinImg.color = jisuImg.color = minSeckImg.color = Color.gray;
                break;
        }
    }

    // 대화 진행 중 캐릭터 애니메이션 함수
    public void CharacterAnim(Dialogue_Base.Info info)
    {

        #region HujungAnim
        // 헤정 애니메이션
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
        // 용진 애니메이션
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
        // 민석 애니메이션 재생
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

    // 대화 진행 중 캐릭터 표정 변화 함수
    public void CharacterEmotion(Dialogue_Base.Info info)
    {
        #region HujungEmotion
        switch(info.h_sprite)
        {
            case H_Sprite.Idle:
                hujungImg.sprite = hujung_Sprite.characterSprite[0];
                hujungImg_CloseUp.sprite = hujung_Sprite.characterSprite[0];
                break;
            case H_Sprite.Angry:
                hujungImg.sprite = hujung_Sprite.characterSprite[1];
                hujungImg_CloseUp.sprite = hujung_Sprite.characterSprite[1];
                break;
        }
        #endregion

        #region YoungjinEmotion
        switch(info.y_sprite)
        {
            case Y_Sprite.Idle:
                youngjinImg.sprite = youngjing_Sprite.characterSprite[0];
                break;
            case Y_Sprite.Idle01:
                youngjinImg.sprite = youngjing_Sprite.characterSprite[1];
                break;
            case Y_Sprite.Angry:
                youngjinImg.sprite = youngjing_Sprite.characterSprite[2];
                break;
            case Y_Sprite.Smile:
                youngjinImg.sprite = youngjing_Sprite.characterSprite[3];
                break;
            case Y_Sprite.Smile01:
                youngjinImg.sprite = youngjing_Sprite.characterSprite[4];
                break;
            case Y_Sprite.Surprise:
                youngjinImg.sprite = youngjing_Sprite.characterSprite[5];
                break;
        }
        #endregion

        #region JisuEmotion
        switch (info.j_sprite)
        {
            case J_Sprite.Idle:
                jisuImg.sprite = jisu_Sprite.characterSprite[0];
                break;
            case J_Sprite.Angry:
                jisuImg.sprite = jisu_Sprite.characterSprite[1];
                break;
            case J_Sprite.Smile:
                jisuImg.sprite = jisu_Sprite.characterSprite[2];
                break;
            case J_Sprite.Surprise:
                jisuImg.sprite = jisu_Sprite.characterSprite[3];
                break;
        }
        #endregion

        #region MinSeokEmotion
        switch (info.m_sprite)
        {
            case M_Sprite.Idle:
                minSeckImg.sprite = minSeok_Sprite.characterSprite[0];
                break;
            case M_Sprite.Angry:
                youngjinImg.sprite = minSeok_Sprite.characterSprite[1];
                break;
            case M_Sprite.Smile:
                youngjinImg.sprite = minSeok_Sprite.characterSprite[2];
                break;
            case M_Sprite.Surprise:
                youngjinImg.sprite = minSeok_Sprite.characterSprite[3];
                break;
        }
        #endregion
    }

    // 대화 진행 중 캐릭터 위치 설정 함수
    public void CharacterDirection(Dialogue_Base.Info info)
    {
        #region CharacterDirection

        #region HujungImgDirection

        switch(info.h_Direction)
        {
            case H_Direction.Center:
                hujungImg.transform.localPosition = center1.transform.localPosition;
                break;
            case H_Direction.Right:
                hujungImg.transform.localPosition = right1.transform.localPosition;
                break;
            case H_Direction.Left:
                hujungImg.transform.localPosition = left1.transform.localPosition;
                break;
            case H_Direction.Out:
                hujungImg.transform.position = out_pos.transform.position;
                break;
        }

        #endregion

        #region YoungjinImgDirection

        switch (info.y_Direction)
        {
            case Y_Direction.Center:
                youngjinImg.transform.position = center.transform.position;
                break;
            case Y_Direction.Right:
                youngjinImg.transform.position = right.transform.position;
                break;
            case Y_Direction.Left:
                youngjinImg.transform.position = left.transform.position;
                break;
            case Y_Direction.Out:
                youngjinImg.transform.position = out_pos.transform.position;
                break;

        }
        #endregion

        #region JisuImgDirection

        switch (info.j_Direction)
        {
            case J_Direction.Center:
                jisuImg.transform.localPosition = center1.transform.localPosition;
                break;
            case J_Direction.Right:
                jisuImg.transform.localPosition = right1.transform.localPosition;
                break;
            case J_Direction.Left:
                jisuImg.transform.localPosition = left1.transform.localPosition;
                break;
            case J_Direction.Out:
                jisuImg.transform.localPosition = out_pos.transform.localPosition;
                break;
        }
        #endregion

        #region MinSeokImgDirection

        switch (info.m_Direction)
        {
            case M_Direction.Center:
                minSeckImg.transform.localPosition = center1.transform.localPosition;
                break;
            case M_Direction.Right:
                minSeckImg.transform.localPosition = right1.transform.localPosition;
                break;
            case M_Direction.Left:
                minSeckImg.transform.localPosition = left1.transform.localPosition;
                break;
            case M_Direction.Out:
                minSeckImg.transform.localPosition = out_pos.transform.localPosition;
                break;
        }
        #endregion

        #endregion

    }

    // 대화 진행 중 기타 연출 함수(화면 암전, 단서 획득, 타이틀 등장 등)
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

        if (info.UI_Off)
        {
            dialoguePanelText.gameObject.SetActive(false);
            dialogueSetting.gameObject.SetActive(false);
        }
        else
        {
            dialoguePanelText.gameObject.SetActive(true);
            dialogueSetting.gameObject.SetActive(true);
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

        #endregion

        #region Inven
        if (info.isFirstClue)
        {
            clue.clues.Add(clueObj0);
            clue.clueAddCount++;
            isClueUpdate = true;
        }

        if (info.isSecondClue)
        {
            clue.clues.Add(clueObj1);
            clue.clueAddCount++;
            isClueUpdate = true;
        }

        if (info.isThirdClue)
        {
            clue.clues.Add(clueObj2);
            clue.clueAddCount++;
            isClueUpdate = true;
        }

        if (info.isForthClue)
        {
            clue.clues.Add(clueObj3);
            clue.clueAddCount++;
            isClueUpdate = true;
        }

        #endregion
    }

    // 텍스트 입력 코루틴
    IEnumerator TypeText(Dialogue_Base.Info info)
    {
        isTextTyping = true;
        next.SetActive(false);

        foreach(char c in info.myText.ToCharArray())
        {
            if(StroyDataMgn.instance.isTwoSpeed)
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
        next.SetActive(true);
        isTextTyping = false;
        yield return new WaitForSeconds(2f);
        isTextComplete = true;
        
    }

    // 텍스트 자동완성 메소드(클릭 시 자동으로 텍스트가 완성되도록)
    private void CompleteText()
    {
        isTextComplete = true;
        dialogueTxt.text = completeText;
        next.SetActive(true);
    }

    // 대화 종료 메소드
    public void EndDialogue()
    {
        isDialoge = false;
        dialogueUI.SetActive(false);
        SceneManager.LoadScene(SceneNum + 1);
    }

}
