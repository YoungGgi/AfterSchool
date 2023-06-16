using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Prologue2 : MonoBehaviour
{
    /*
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

    public Queue<Dialogue_Base.second> dialoguesecond = new Queue<Dialogue_Base.second>();


    // Start is called before the first frame update
    void Start()
    {
        dialoguesecond = new Queue<Dialogue_Base.second>();
    }

    // Update is called once per frame
    void Update()
    {
        NowScene = SceneManager.GetActiveScene(); // �� �����Ӹ��� ���� �� Ȯ���ϱ�
        SceneNum = NowScene.buildIndex;
    }

    public void EnqueuDialogue(Dialogue_Base db)
    {
        if (isDialoge) return;

        isDialoge = true;

        dialoguesecond.Clear();

        foreach (Dialogue_Base.second info in db.dialogueSecond)
        {
            dialoguesecond.Enqueue(info);
        }

        DequeueDialogue();


    }

    public void DequeueDialogue()
    {
        #region TextTyping
        isTextComplete = false;

        // �ش� ��� ����Ʈ�� ���� �����ٸ� ��ȭ ���� �Լ��� �̵�
        if (dialoguesecond.Count == 0)
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

        Dialogue_Base.second info = dialoguesecond.Dequeue();

        completeText = info.myText;

        dialogueTxt.text = info.myText;

        #endregion



        #region CharacterName
        
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

    IEnumerator TypeText(Dialogue_Base.second info)
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
    */
}
