using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Dialogue_Test01 : MonoBehaviour
{
    [Header("DialogueGroup")]
    public TextMeshProUGUI dialogueTxt;        // ��ȭ �ؽ�Ʈ
    public TextMeshProUGUI nameTxt;            // �̸� �ؽ�Ʈ
    protected Image backGroundImg;                // ��� �̹���
    protected BackGroundFold backGroundFold;
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
    public GameObject dialoguePanelText;       // ��ȭâ UI
    public GameObject dialogueSetting;         // ��ȭ ��� UI(����, �α�, ����)

    [Header("Character")]
    protected Image hujungImg;                   // ȿ�� ��������Ʈ
    public Image hujungImg_CloseUp;           // ȿ�� Ŭ����� ��������Ʈ
    protected Image youngjinImg;                 // ���� ��������Ʈ
    public Image youngjunImg_CloseUp;         // ���� Ŭ����� ��������Ʈ
    protected Image jisuImg;                     // ���� ��������Ʈ
    public Image jisuImg_CloseUp;             // ���� Ŭ����� ��������Ʈ
    protected Image minSeckImg;                  // �μ� ��������Ʈ
    public Image minseok_CloseUp;             // �μ� Ŭ����� ��������Ʈ
    protected Transform center;                  // ĳ���� ��ġ(����)
    protected Transform left;
    protected Transform right;
    protected Transform out_pos;
    protected RectTransform center1;             // ĳ���� ��ġ(ȿ��, ����, �μ�?)
    protected RectTransform left1;
    protected RectTransform right1;

    [Header("Character_Emotion")]             // �� ĳ���� ǥ�� ��������Ʈ
    protected CharacterSprite hujung_Sprite;
    protected CharacterSprite youngjing_Sprite;
    protected CharacterSprite jisu_Sprite;
    protected CharacterSprite minSeok_Sprite;

    [Header("Animation")]
    protected Animator Hujung;                    // ȿ�� ���� �ִϸ�����
    protected Animator YoungJin;                  // ���� ���� �ִϸ�����
    protected Animator Jisu;                      // ���� ���� �ִϸ�����
    protected Animator MinSeok;                   // �μ� ���� �ִϸ�����


    [Header("Direction")]
    protected Animator fadeManager;               // ���̵� �� / �ƿ� ���� ȿ��

    protected GameObject titleObj;                // ���� Ÿ��Ʋ ������Ʈ
    protected GameObject subTitleObj;

    [Header("Add Clue")]                       // ��ȭ ���� �� �߰��� �ܼ����
    protected ClueManager clue;
    protected ClueObject clueObj0;
    protected ClueObject clueObj1;
    protected ClueObject clueObj2;
    protected ClueObject clueObj3;
    public bool isClueUpdate;

    public Scene NowScene;
    public int SceneNum;

    // Dialogue_Base ���� ������ Queue�� ����
    public Queue<Dialogue_Base.Info> dialogueInfo = new Queue<Dialogue_Base.Info>();

    protected Dialogue_Base.Info Info;

    private void OnEnable()
    {
        dialogueInfo = new Queue<Dialogue_Base.Info>();
        dialogueUI.gameObject.SetActive(false);
        StartCoroutine(Loading());

        //StroyDataMgn.instance.IsSettingOn = false;
    }

    // ���� ���� �� �ε� ȭ��(�ڵ�����) ���, ������ �� ��ȭ ȭ�� ����
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

        foreach (Dialogue_Base.Info info in db.dialogueInfo)
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
        if (dialogueInfo.Count == 0)
        {
            EndDialogue();
            return;
        }

        // �ؽ�Ʈ�� ��� ���� ��� 
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
        // ��α� �ؽ�Ʈ ���
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


        dialogueTxt.text = "";
        StartCoroutine(TypeText(Info));
    }

    // ��ȭ ���� �� ��� ���� �Լ�
    protected virtual void BackGroundChange(Dialogue_Base.Info info)
    {
        
    }

    // ��ȭ ���� �� ĳ���� �̸� �Լ�
    protected virtual void CharacterName(Dialogue_Base.Info info)
    {
        
    }

    // ��ȭ ���� �� ĳ���� �ִϸ��̼� �Լ�
    protected virtual void CharacterAnim(Dialogue_Base.Info info)
    {

    }

    // ��ȭ ���� �� ĳ���� ǥ�� ��ȭ �Լ�
    protected virtual void CharacterEmotion(Dialogue_Base.Info info)
    {
        
    }

    // ��ȭ ���� �� ĳ���� ��ġ ���� �Լ�
    protected virtual void CharacterDirection(Dialogue_Base.Info info)
    {
        

    }

    // ��ȭ ���� �� ��Ÿ ���� �Լ�(ȭ�� ����, �ܼ� ȹ��, Ÿ��Ʋ ���� ��)
    protected virtual void BackGroundDirection(Dialogue_Base.Info info)
    {
        
    }

    // �ؽ�Ʈ �Է� �ڷ�ƾ
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
        SceneManager.LoadScene(SceneNum + 1);
    }

}
