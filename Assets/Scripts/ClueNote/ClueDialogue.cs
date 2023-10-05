using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClueDialogue : MonoBehaviour
{
    public Dialogue_Base dialogue;                    // ������ ��ȭ ������(ScriptableObject)
    public A_Dialogue a_Dialogue;                     // ��ȭ ���� Ŭ����

    public bool isAuto;                               // ���� ��� ���� ����
    public float dealyCool;                           // ���� ��ȭ �ؽ�Ʈ�� �Ѿ �� ������

    public GameObject autoText;                       // ���� ��� Ȱ��ȭ �� ��µ� ���� ������Ʈ

    public GameObject black;
    public GameObject loadingTextGroup;               // �� ���� �� ��µ� �� ȭ�� ������Ʈ

    bool isLoading;                                   // �ε� ���� ����

    public GameObject auto_Btn;                       // ���� ��ư
    public GameObject auto_true_Btn;                  // ���� ��Ȱ��ȭ ��ư

    public GameObject speed2_Btn;                     // 2��� ��ư
    public GameObject speed2_true_Btn;                // 2��� ��Ȱ��ȭ ��ư

    public GameObject dialogueObj;

    // �ش� ������Ʈ Ȱ��ȭ �� ȣ��Ǵ� �Լ�
    void OnEnable()
    {
        // �ε� ���¸� true�� ��ȯ �� LoadingAnim �ڷ�ƾ ����
        isLoading = true;
        StartCoroutine(LoadingAnim());
        
        // �� ���� �� ���� ����� Ȱ��ȭ�Ǿ� �ִٸ� ���� ������Ʈ, ��ư Ȱ��ȭ
        if (StroyDataMgn.instance.IsAutoLive)
        {
            autoText.gameObject.SetActive(true);

            auto_Btn.gameObject.SetActive(false);
            auto_true_Btn.gameObject.SetActive(true);
        }

        // �� ���� �� 2��� ����� Ȱ��ȭ�Ǿ� �ִٸ� 2��� ������Ʈ, ��ư Ȱ��ȭ
        if (StroyDataMgn.instance.IsTwoSpeed)
        {
            speed2_Btn.gameObject.SetActive(false);
            speed2_true_Btn.gameObject.SetActive(true);
        }

    }

    IEnumerator LoadingAnim()
    {
        // �� 1.5�� ������ �� �ڵ� ���� �ε� ȭ�� ��Ȱ��ȭ, ��ȭ ����(EnQueue), �ε� ���� ���� false ��ȯ
        yield return new WaitForSeconds(0.5f);
        Debug.Log("Start");
        dialogueObj.gameObject.SetActive(true);

        black.SetActive(false);
        loadingTextGroup.SetActive(false);

        a_Dialogue.EnqueuDialogue(dialogue);

        isLoading = false;

    }

    void Update()
    {
        // �ε� ���� �� return
        if (isLoading || StroyDataMgn.instance.IsSettingOn)
            return;
        else
        {
            // StroyDataMgn �� ���� ����� true �Ǿ� �ְ�, ���� ��ȭ �ؽ�Ʈ ���� ��� ��
            if (StroyDataMgn.instance.IsAutoLive && a_Dialogue.isTextComplete == true)
            {
                // ���� ������Ʈ Ȱ��ȭ
                autoText.gameObject.SetActive(true);
                // �ణ�� ������ �� ���� �ؽ�Ʈ ���.
                StartCoroutine(NextDelay());
                a_Dialogue.DequeueDialogue();
            }

            // StroyDataMgn�� ���� ����� false �� �� ���� ������Ʈ ��Ȱ��ȭ
            if (StroyDataMgn.instance.IsAutoLive == false)
            {
                autoText.gameObject.SetActive(false);
            }

            // �����̽� Ű Ȥ�� Enter �Է� ��
            if ((Input.GetKeyUp(KeyCode.Space)) || (Input.GetKeyUp(KeyCode.Return)))
            {
                // �ణ�� ������ �� ���� �ؽ�Ʈ ���
                StartCoroutine(NextDelay());
                a_Dialogue.DequeueDialogue();
            }

            // StroyDataMgn�� ����� ���� ����� true �̰�, ���� ��ȭ �ؽ�Ʈ�� ��� ��� ��
            if (StroyDataMgn.instance.IsAutoStory && a_Dialogue.isTextComplete == true)
            {
                // �ణ�� ������ �� ���� �ؽ�Ʈ ���
                StartCoroutine(NextDelay());
                a_Dialogue.DequeueDialogue();
            }

        }
    }

    // ���� ��ȭ �ؽ�Ʈ ���� �� ������
    IEnumerator NextDelay()
    {
        yield return new WaitForSeconds(dealyCool);
    }

    // ��ȭ ȭ���� ��ư Ŭ�� �� ���� ��ȭ �ؽ�Ʈ ����(DeQueue)
    public void Next() => a_Dialogue.DequeueDialogue();

}
