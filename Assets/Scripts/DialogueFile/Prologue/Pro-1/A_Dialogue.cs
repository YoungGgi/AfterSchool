using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class A_Dialogue : MonoBehaviour
{
    
    [Header("DialogueGroup")]
    public TextMeshProUGUI dialogueTxt;       
    public TextMeshProUGUI nameTxt;
    public Image backGroundImg;                // 배경 이미지
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
    public GameObject dialoguePanelText;
    public GameObject InGameUI;                // 인게임 전용 UI

    [Header("Animation")]
    public Animator Hujung;                    // 효정 전용 애니메이터
    public Animator YoungJin;                  // 용진 전용 애니메이터
    public Animator MinSeok;                   // 민석 전용 애니메이터
    

    [Header("Direction")]
    public Animator fadeManager;                // 페이드 인 / 아웃 전용 효과
    public GameObject invenClue1;
    public GameObject invenClue2;
    public GameObject invenClue3;
    public GameObject invenClue4;

    public GameObject titleObj;

    /*
    [Header("DialogueNum")]
    public int dialogueID;                     // 해당 대화씬 ID
    public int dialogueIndex;                  // 대화 인덱스
    */
    
    public Scene NowScene;
    public int SceneNum;

    // Dialogue_Base 에서 선언한 Queue문 선언
    public Queue<Dialogue_Base.Info> dialogueInfo = new Queue<Dialogue_Base.Info>();

    private void Start()
    {
        dialogueInfo = new Queue<Dialogue_Base.Info>();

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

        //dialogueIndex = info.dialogueIndex;
        
        completeText = info.myText;

        dialogueTxt.text = info.myText;

        backGroundImg.sprite = info.backGround;
        #endregion

        #region CharacterName
        

        if (info.charName == Name.Blank)
        {
            nameTxt.text = "";
        }

        if (info.charName == Name.Player)
        {
            nameTxt.text = "주인공";
        }

        if (info.charName == Name.Hujung)
        {
            nameTxt.text = "정효정";
        }

        if(info.charName == Name.YoungJin)
        {
            nameTxt.text = "이용진";
        }

        if (info.charName == Name.Jisu)
        {
            nameTxt.text = "은지수";
        }

        if (info.charName == Name.MinSeok)
        {
            nameTxt.text = "염민석";
        }

        if (info.charName == Name.Who)
        {
            nameTxt.text = "???";
        }
        #endregion

        #region CharacterAnim

        #region HujungAnim
        // 효정 애니메이션 재생
        if (info.h_Anim == H_Anim.H_Appear)
        {
            Hujung.Play("H_Appear");
        }

        if(info.h_Anim == H_Anim.H_DisAppear)
        {
            Hujung.Play("H_DisAppear");
        }

        if (info.h_Anim == H_Anim.Start)
        {
            Hujung.Play("H_Start");
        }
        #endregion

        #region YoungJinAnim
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
        #endregion

        #endregion

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
        }
        else
        {
            dialoguePanelText.gameObject.SetActive(true);
        }

        if(info.Title_On)
        {
            titleObj.gameObject.SetActive(true);
        }
        else
        {
            titleObj.gameObject.SetActive(false);
        }
        #endregion

        #region Inven
        if (info.isFirstClue)
        {
            invenClue1.gameObject.SetActive(true);
        }
        else
        {
            invenClue1.gameObject.SetActive(false);
        }

        if (info.isSecondClue)
        {
            invenClue2.gameObject.SetActive(true);
        }
        else
        {
            invenClue2.gameObject.SetActive(false);
        }

        if (info.isThirdClue)
        {
            invenClue3.gameObject.SetActive(true);
        }
        else
        {
            invenClue3.gameObject.SetActive(false);
        }

        if (info.isForthClue)
        {
            invenClue4.gameObject.SetActive(true);
        }
        else
        {
            invenClue4.gameObject.SetActive(false);
        }

        #endregion

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

        dialogueTxt.text = "";
        StartCoroutine(TypeText(info));
    }

    // 텍스트 입력 코루틴
    IEnumerator TypeText(Dialogue_Base.Info info)
    {
        isTextTyping = true;
        next.SetActive(false);

        foreach(char c in info.myText.ToCharArray())
        {
            yield return new WaitForSeconds(delay);
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
        //ChapterCheck.instance.isPrologueComplete = true;
        SceneManager.LoadScene(SceneNum + 1);
    }

}
