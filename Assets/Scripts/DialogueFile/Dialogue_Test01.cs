using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Dialogue_Test01 : MonoBehaviour
{
    [Header("DialogueGroup")]
    public TextMeshProUGUI dialogueTxt;        // 대화 텍스트
    public TextMeshProUGUI nameTxt;            // 이름 텍스트
    protected Image backGroundImg;                // 배경 이미지
    protected BackGroundFold backGroundFold;
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
    protected Image hujungImg;                   // 효정 스프라이트
    public Image hujungImg_CloseUp;           // 효정 클로즈업 스프라이트
    protected Image youngjinImg;                 // 용진 스프라이트
    public Image youngjunImg_CloseUp;         // 용진 클로즈업 스프라이트
    protected Image jisuImg;                     // 지수 스프라이트
    public Image jisuImg_CloseUp;             // 지수 클로즈업 스프라이트
    protected Image minSeckImg;                  // 민석 스프라이트
    public Image minseok_CloseUp;             // 민석 클로즈업 스프라이트
    protected Transform center;                  // 캐릭터 위치(용진)
    protected Transform left;
    protected Transform right;
    protected Transform out_pos;
    protected RectTransform center1;             // 캐릭터 위치(효정, 지수, 민석?)
    protected RectTransform left1;
    protected RectTransform right1;

    [Header("Character_Emotion")]             // 각 캐릭터 표정 스프라이트
    protected CharacterSprite hujung_Sprite;
    protected CharacterSprite youngjing_Sprite;
    protected CharacterSprite jisu_Sprite;
    protected CharacterSprite minSeok_Sprite;

    [Header("Animation")]
    protected Animator Hujung;                    // 효정 전용 애니메이터
    protected Animator YoungJin;                  // 용진 전용 애니메이터
    protected Animator Jisu;                      // 지수 전용 애니메이터
    protected Animator MinSeok;                   // 민석 전용 애니메이터


    [Header("Direction")]
    protected Animator fadeManager;               // 페이드 인 / 아웃 전용 효과

    protected GameObject titleObj;                // 게임 타이틀 오브젝트
    protected GameObject subTitleObj;

    [Header("Add Clue")]                       // 대화 진행 중 추가될 단서목록
    protected ClueManager clue;
    protected ClueObject clueObj0;
    protected ClueObject clueObj1;
    protected ClueObject clueObj2;
    protected ClueObject clueObj3;
    public bool isClueUpdate;

    public Scene NowScene;
    public int SceneNum;

    // Dialogue_Base 에서 선언한 Queue문 선언
    public Queue<Dialogue_Base.Info> dialogueInfo = new Queue<Dialogue_Base.Info>();

    protected Dialogue_Base.Info Info;

    private void OnEnable()
    {
        dialogueInfo = new Queue<Dialogue_Base.Info>();
        dialogueUI.gameObject.SetActive(false);
        StartCoroutine(Loading());

        //StroyDataMgn.instance.IsSettingOn = false;
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

        foreach (Dialogue_Base.Info info in db.dialogueInfo)
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
        if (dialogueInfo.Count == 0)
        {
            EndDialogue();
            return;
        }

        // 텍스트가 출력 중일 경우 
        if (isTextTyping == true)
        {
            CompleteText();
            StopAllCoroutines();
            isTextTyping = false;
            isTextComplete = true;
            return;
        }
        #endregion

        #region DequeueCon

        Info = dialogueInfo.Dequeue();

        completeText = Info.myText;

        dialogueTxt.text = Info.myText;

        
        BackGroundChange(Info);
        #endregion

        hujungImg_CloseUp.color = Info.isHujung_CloseUp ? new Color(225, 225, 225, 1) : new Color(225, 225, 225, 0);

        youngjunImg_CloseUp.color = Info.isYoungjin_CloseUp ? new Color(225, 225, 225, 1) : new Color(225, 225, 225, 0);

        jisuImg_CloseUp.color = Info.isJisu_CloseUp ? new Color(225, 225, 225, 1) : new Color(225, 225, 225, 0);

        minseok_CloseUp.color = Info.isMinseok_CloseUp ? new Color(225, 225, 225, 1) : new Color(225, 225, 225, 0);

        CharacterName(Info);

        CharacterAnim(Info);

        CharacterEmotion(Info);

        CharacterDirection(Info);

        BackGroundDirection(Info);


        #region BackLog
        // 백로그 텍스트 등록
        if (dialogueTxt.text != "")
        {
            GameObject clone = Instantiate(textPrefab, parentContents);

            if (Info.charName == Name.Blank)
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
        StroyDataMgn.instance.IsAutoStory = Info.UI_Off;
        #endregion


        #region ChapterClose
        // 챕터 종료시 메인 로비로 이동
        if (Info.isPrologueClose)
        {
            ChapterCheck.instance.isPrologueComplete = true;
            SceneManager.LoadScene(0);
        }
        #endregion

        dialogueTxt.text = "";
        StartCoroutine(TypeText(Info));
    }

    // 대화 진행 중 배경 설정 함수
    protected virtual void BackGroundChange(Dialogue_Base.Info info)
    {
        
    }

    // 대화 진행 중 캐릭터 이름 함수
    protected virtual void CharacterName(Dialogue_Base.Info info)
    {
        
    }

    // 대화 진행 중 캐릭터 애니메이션 함수
    protected virtual void CharacterAnim(Dialogue_Base.Info info)
    {

    }

    // 대화 진행 중 캐릭터 표정 변화 함수
    protected virtual void CharacterEmotion(Dialogue_Base.Info info)
    {
        
    }

    // 대화 진행 중 캐릭터 위치 설정 함수
    protected virtual void CharacterDirection(Dialogue_Base.Info info)
    {
        

    }

    // 대화 진행 중 기타 연출 함수(화면 암전, 단서 획득, 타이틀 등장 등)
    protected virtual void BackGroundDirection(Dialogue_Base.Info info)
    {
        
    }

    // 텍스트 입력 코루틴
    IEnumerator TypeText(Dialogue_Base.Info info)
    {
        isTextTyping = true;
        next.SetActive(false);

        foreach (char c in Info.myText.ToCharArray())
        {
            if (StroyDataMgn.instance.IsTwoSpeed)
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
