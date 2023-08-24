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
    public Image backGroundImg;                // ��� �̹���
    public GameObject next;                    // ȭ��ǥ ������Ʈ
    public GameObject textPrefab;              // ��α� ���� �ؽ�Ʈ ������
    public Transform parentContents;           // ��α��� Contents���� ��µ�

    [Header("TextTypingGroup")]
    public float delay;                        //�ؽ�Ʈ ��� ������
    private bool isTextTyping;                 // �ؽ�Ʈ ��� ���� Ȯ��
    public bool isTextComplete = false;               // �ؽ�Ʈ ��� �ϼ� ���� Ȯ��
    private string completeText;               // �ϼ��� �ؽ�Ʈ

    private bool isDialoge;                   // ��ȭ ���� Ȯ��

    [Header("DialogueEnd")]
    public GameObject dialogueUI;              // ��ȭ�� ���� UI
    public GameObject dialoguePanelText;
    public GameObject dialogueSetting;

    [Header("Character")]
    public Image hujungImg;                   // ȿ�� ��������Ʈ
    public Image youngjinImg;                 // ���� ��������Ʈ
    public Image jisuImg;                     // ȿ�� ��������Ʈ
    public Image minSeckImg;                  // �μ� ��������Ʈ
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
    public Animator Hujung;                    // ȿ�� ���� �ִϸ�����
    public Animator YoungJin;                  // ���� ���� �ִϸ�����
    public Animator Jisu;                      // ���� ���� �ִϸ�����
    public Animator MinSeok;                   // �μ� ���� �ִϸ�����
    

    [Header("Direction")]
    public Animator fadeManager;                // ���̵� �� / �ƿ� ���� ȿ��
    
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

    // Dialogue_Base ���� ������ Queue�� ����
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

        // �ش� ��� ����Ʈ�� ���� �����ٸ� ��ȭ ���� �Լ��� �̵�
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
                nameTxt.text = "��ȿ��";
                hujungImg.color = new Color(255, 255, 255);
                youngjinImg.color = Color.gray;
                break;
            case Name.YoungJin:
                nameTxt.text = "�̿���";
                youngjinImg.color = new Color(255, 255, 255);
                hujungImg.color = Color.gray;
                break;
            case Name.Jisu:
                nameTxt.text = "������";
                break;
            case Name.MinSeok:
                nameTxt.text = "���μ�";
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
        // ��α� �ؽ�Ʈ ���
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
        // ���� �ִϸ��̼�
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

        if (info.j_Anim == J_Anim.J_DisAppear)
        {
            Jisu.Play("J_Start");
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

    // �ؽ�Ʈ �Է� �ڷ�ƾ
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

    // �ؽ�Ʈ �ڵ��ϼ� �޼ҵ�(Ŭ�� �� �ڵ����� �ؽ�Ʈ�� �ϼ��ǵ���)
    private void CompleteText()
    {
        isTextComplete = true;
        dialogueTxt.text = completeText;
        next.SetActive(true);
    }

    // ��ȭ ���� �޼ҵ�
    public void EndDialogue()
    {
        isDialoge = false;
        dialogueUI.SetActive(false);
        //ChapterCheck.instance.isPrologueComplete = true;
        SceneManager.LoadScene(SceneNum + 1);
    }

}
