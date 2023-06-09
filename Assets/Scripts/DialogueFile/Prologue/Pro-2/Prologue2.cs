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
    public GameObject InGameUI;                // �ΰ��� ���� UI

    [Header("CharacterSprite")]
    public Image hujung_sprite;
    public Image youngjin_sprite;

    [Header("Animation")]
    public Animator Hujung;                    // ȿ�� ���� �ִϸ�����
    public Animator YoungJin;                  // ���� ���� �ִϸ�����

    [Header("Direction")]
    public Animator fadeManager;                // ���̵� �� / �ƿ� ���� ȿ��
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
        NowScene = SceneManager.GetActiveScene(); // �� �����Ӹ��� ���� �� Ȯ���ϱ�
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

        // �ش� ��� ����Ʈ�� ���� �����ٸ� ��ȭ ���� �Լ��� �̵�
        if (prologueInfo.Count == 0)
        {
            Debug.Log("End");
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
            nameTxt.text = "���ΰ�";
        }

        if (info.charName == Name.Hujung)
        {
            nameTxt.text = "��ȿ��";
        }

        if (info.charName == Name.YoungJin)
        {
            nameTxt.text = "�̿���";
        }

        if (info.charName == Name.Jisu)
        {
            nameTxt.text = "������";
        }

        if (info.charName == Name.MinSeok)
        {
            nameTxt.text = "���μ�";
        }

        if (info.charName == Name.Who)
        {
            nameTxt.text = "???";
        }
        #endregion

        #region CharacterAnim

        #region HujungAnim
        // ȿ�� �ִϸ��̼� ���
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
        // ��α� �ؽ�Ʈ ���
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
