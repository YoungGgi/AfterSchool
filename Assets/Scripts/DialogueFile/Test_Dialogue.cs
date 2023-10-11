using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class Test_Dialogue : MonoBehaviour
{

    public Dialogue_Base dialogue;                    // 대화 데이터(ScriptableObject)
    public A_Dialogue a_Dialogue;                     // 대화 스크립트

    public bool isAuto;                               // 오토 상태 논리 함수
    public float dealyCool;                           // 대화 진행 딜레이

    public GameObject autoText;                       // 오토 오브젝트

    public GameObject loadingTextGroup;               // 로딩 화면(자동 저장)

    bool isLoading;                                   // 로딩 논리 함수(아래의 캡슐화 참조)

    public GameObject auto_Btn;                       // 오토 버튼
    public GameObject auto_true_Btn;                  // 오토 활성화 버튼

    public GameObject speed2_Btn;                     // 2배속 버튼
    public GameObject speed2_true_Btn;                // 2배속 활성화 버튼

    public Scene NowScene;                            // 현재 씬 넘버
    public int SceneNum;                              

    // �ش� ������Ʈ Ȱ��ȭ �� ȣ��Ǵ� �Լ�
    void OnEnable()
    {
        // �ε� ���¸� true�� ��ȯ �� LoadingAnim �ڷ�ƾ ����
        isLoading = true;
        StartCoroutine(LoadingAnim());

        // ���� ���� �ε��� �ѹ��� SaveLoadMgn(�ڵ�����) �����Ϳ� ����
        NowScene = SceneManager.GetActiveScene();
        SceneNum = NowScene.buildIndex;
        SaveLoadMgn.instance.SaveData(SceneNum);

        // �� ���� �� ���� ����� Ȱ��ȭ�Ǿ� �ִٸ� ���� ������Ʈ, ��ư Ȱ��ȭ
        if (StroyDataMgn.instance.IsAutoLive)
        {
            autoText.gameObject.SetActive(true);

            auto_true_Btn.gameObject.SetActive(false);
            auto_Btn.gameObject.SetActive(true);
        }

        // �� ���� �� 2��� ����� Ȱ��ȭ�Ǿ� �ִٸ� 2��� ������Ʈ, ��ư Ȱ��ȭ
        if (StroyDataMgn.instance.IsTwoSpeed)
        {
            speed2_true_Btn.gameObject.SetActive(false);
            speed2_Btn.gameObject.SetActive(true);
        }

    }

    // �ε� ȭ���� ��µǴ� �ڷ�ƾ
    IEnumerator LoadingAnim()
    {
        // �� 1.5�� ������ �� �ڵ� ���� �ε� ȭ�� ��Ȱ��ȭ, ��ȭ ����(EnQueue), �ε� ���� ���� false ��ȯ
        yield return new WaitForSeconds(1.5f);

        loadingTextGroup.gameObject.SetActive(false);

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
            if(StroyDataMgn.instance.IsAutoLive == false)
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
            if(StroyDataMgn.instance.IsAutoStory && a_Dialogue.isTextComplete == true)
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
