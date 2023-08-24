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
    public GameObject dialogueSetting;

    [Header("Character")]
    public Image hujungImg;                   // 효정 스프라이트
    public Image youngjinImg;                 // 용진 스프라이트
    public Image jisuImg;                     // 효정 스프라이트
    public Image minSeckImg;                  // 민석 스프라이트
    public Transform center;
    public Transform left;
    public Transform right;
    public Transform out_pos;

    [Header("Character_Emotion")]
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
    public Animator fadeManager;                // 페이드 인 / 아웃 전용 효과
    
    public GameObject titleObj;

    [Header("Add Clue")]
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

    /*
    private void Start()
    {
        dialogueInfo = new Queue<Dialogue_Base.Info>();
        dialogueUI.gameObject.SetActive(false);
        StartCoroutine(Loading());

        StroyDataMgn.instance.isSettingOn = false;

    }
    */
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

        backGroundImg.sprite = info.backGround;
        #endregion

        #region CharacterName
        
        switch(info.charName)
        {
            case Name.Blank:
                nameTxt.text = "";
                break;
            case Name.Player:
                nameTxt.text = PlayerName.instance.player;
                hujungImg.color = youngjinImg.color = Color.gray;
                break;
            case Name.Hujung:
                nameTxt.text = "정효정";
                hujungImg.color = new Color(255, 255, 255);
                youngjinImg.color = Color.gray;
                break;
            case Name.YoungJin:
                nameTxt.text = "이용진";
                youngjinImg.color = new Color(255, 255, 255);
                hujungImg.color = Color.gray;
                break;
            case Name.Jisu:
                nameTxt.text = "은지수";
                break;
            case Name.MinSeok:
                nameTxt.text = "염민석";
                break;
            case Name.Who:
                nameTxt.text = "???";
                break;
        }
        #endregion

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

        dialogueTxt.text = "";
        StartCoroutine(TypeText(info));
    }

    public void CharacterAnim(Dialogue_Base.Info info)
    {

        #region HujungAnim
        // 헤정 애니메이션
        if (info.h_Anim == H_Anim.H_Appear)
        {
            YoungJin.Play("Y_Appear");
        }

        if (info.h_Anim == H_Anim.H_DisAppear)
        {
            YoungJin.Play("Y_DisAppear");
        }

        if (info.h_Anim == H_Anim.Start)
        {
            YoungJin.Play("Y_Start");
        }

        if (info.h_Anim == H_Anim.Bangbang)
        {
            YoungJin.Play("Y_Bangbang");
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

        if (info.j_Anim == J_Anim.J_DisAppear)
        {
            Jisu.Play("J_Start");
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

    }

    public void CharacterEmotion(Dialogue_Base.Info info)
    {
        #region HujungEmotion
        switch(info.h_sprite)
        {
            case H_Sprite.Idle:
                hujungImg.sprite = hujung_Sprite.characterSprite[0];
                break;
            case H_Sprite.Angry:
                hujungImg.sprite = hujung_Sprite.characterSprite[1];
                break;
        }
        #endregion

        #region YoungjinEmotion
        switch(info.y_sprite)
        {
            case Y_Sprite.Idle:
                youngjinImg.sprite = youngjing_Sprite.characterSprite[0];
                break;
            case Y_Sprite.Angry:
                youngjinImg.sprite = youngjing_Sprite.characterSprite[1];
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

    public void CharacterDirection(Dialogue_Base.Info info)
    {
        #region CharacterDirection

        #region HujungImgDirection

        switch(info.h_Direction)
        {
            case H_Direction.Center:
                hujungImg.transform.position = center.transform.position;
                break;
            case H_Direction.Right:
                hujungImg.transform.position = right.transform.position;
                break;
            case H_Direction.Left:
                hujungImg.transform.position = left.transform.position;
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
                jisuImg.transform.position = center.transform.position;
                break;
            case J_Direction.Right:
                jisuImg.transform.position = right.transform.position;
                break;
            case J_Direction.Left:
                jisuImg.transform.position = left.transform.position;
                break;
            case J_Direction.Out:
                jisuImg.transform.position = out_pos.transform.position;
                break;
        }
        #endregion

        #region MinSeokImgDirection

        switch (info.m_Direction)
        {
            case M_Direction.Center:
                minSeckImg.transform.position = center.transform.position;
                break;
            case M_Direction.Right:
                minSeckImg.transform.position = right.transform.position;
                break;
            case M_Direction.Left:
                minSeckImg.transform.position = left.transform.position;
                break;
            case M_Direction.Out:
                minSeckImg.transform.position = out_pos.transform.position;
                break;
        }
        #endregion

        #endregion

    }

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
        //ChapterCheck.instance.isPrologueComplete = true;
        SceneManager.LoadScene(SceneNum + 1);
    }

}
