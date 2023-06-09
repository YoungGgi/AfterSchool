using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Prologue2 : MonoBehaviour
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

    [Header("CharacterSprite")]
    public Image hujung_sprite;
    public Image youngjin_sprite;

    [Header("Animation")]
    public Animator Hujung;                    // 효정 전용 애니메이터
    public Animator YoungJin;                  // 용진 전용 애니메이터

    [Header("Direction")]
    public Animator fadeManager;                // 페이드 인 / 아웃 전용 효과
    public GameObject invenTest;
    public GameObject titleObj;

    public Scene NowScene;
    public int SceneNum;

    public Queue<PrologueBase2.Pro2> prologueInfo = new Queue<PrologueBase2.Pro2>();


    // Start is called before the first frame update
    void Start()
    {
        prologueInfo = new Queue<PrologueBase2.Pro2>();
    }

    // Update is called once per frame
    void Update()
    {
        NowScene = SceneManager.GetActiveScene(); // 매 프레임마다 현재 씬 확인하기
        SceneNum = NowScene.buildIndex;
    }

    public void EnqueuDialogue(PrologueBase2 db)
    {
        if (isDialoge) return;

        isDialoge = true;

        prologueInfo.Clear();

        foreach (PrologueBase2.Pro2 info in db.dialogueInfo)
        {
            prologueInfo.Enqueue(info);
        }

        DequeueDialogue();


    }

    public void DequeueDialogue()
    {
        #region TextTyping
        isTextComplete = false;

        // 해당 대사 리스트가 전부 끝났다면 대화 종료 함수로 이동
        if (prologueInfo.Count == 0)
        {
            Debug.Log("End");
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

        PrologueBase2.Pro2 info = prologueInfo.Dequeue();

        completeText = info.myText;

        dialogueTxt.text = info.myText;

        backGroundImg.sprite = info.backGround;
        #endregion



        #region CharacterName
        if (info.isCheck == true)
        {
            Debug.Log("CheckOn");
        }

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

        if (info.charName == Name.YoungJin)
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

        if (info.h_Anim == H_Anim.H_DisAppear)
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

        #endregion

        #region Inven
        if (info.isCheck)
        {
            invenTest.gameObject.SetActive(true);
        }
        else
        {
            invenTest.gameObject.SetActive(false);
        }

        #endregion

        #region BackLog
        // 백로그 텍스트 등록
        GameObject clone = Instantiate(textPrefab, parentContents);
        if (info.charName == Name.Blank)
        {
            clone.GetComponent<TextMeshProUGUI>().text = dialogueTxt.text;
        }
        else
        {
            clone.GetComponent<TextMeshProUGUI>().text = nameTxt.text + " : " + dialogueTxt.text;
        }
        #endregion

        dialogueTxt.text = "";
        StartCoroutine(TypeText(info));
    }

    IEnumerator TypeText(PrologueBase2.Pro2 info)
    {
        isTextTyping = true;
        next.SetActive(false);

        foreach (char c in info.myText.ToCharArray())
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
