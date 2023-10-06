using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MiniGameMgn : MonoBehaviour
{
    [SerializeField]
    private GameObject failGroup;              // �ܼ� ���� �׷�
    [SerializeField]
    private GameObject clearGroup;             // �ܼ� ���� �׷�


    public bool[] isClear;                      // Ŭ���� ������ ���
    public GameObject[] clueBtns;                   // ��ư ���
    public GameObject[] clueBtns_Press;         // ���õ� ��ư ���

    public int checkCount;                      // ��ư ���� ������ ī��Ʈ�Ǵ� ����

    // ��ȭ �� ���� ���� or ���� ���� �� ��ȭ �� ����Ǵ� ����
    public GameObject dialogueGroup;                             // ��ȭ ���� UI ������Ʈ��
    public GameObject dialogue;                                  // ��ȭ �Ŵ���
    public GameObject miniGameGroup;                             // �̴ϰ��� ���� UI ������Ʈ��

    public GameObject loadingTextGroup;               // ���� ���� �� �ε� ȭ��(�ڵ� ����)
    bool isLoading;                                   // �ε� ���� Ȯ�� ������(�Ʒ��� ĸ��ȭ ����)

    // ���� �� �ε��� Ȯ���ϴ� ������
    public Scene NowScene;
    public int SceneNum;

    public bool isSingleGame;                 // ���� �ϳ��� ���� �̴ϰ����� ���� ���º���
    public bool isTwosGame;                   // ���� �� �� ���� �̴ϰ����� ���� ���º���
    public bool isThirdGame;                  // ���� �� �� ���� �̴ϰ����� ���� ���º���

    public AudioClip clearSFX;                // ���� ȿ����
    public AudioClip failSFX;                 // ���� ȿ����
    public AudioClip btnClickSFX;             // ��ư Ŭ�� ȿ����

    public GameObject postProcessing;         // ��ó�� ȿ�� ������Ʈ
    public GameObject startBGM_Obj;           // BGM ���� ������Ʈ

    // �ε� ���Լ� ������Ƽ
    public bool IsLoading { get => isLoading; set => isLoading = value; }

    void OnEnable()
    {
        // �ش� ������Ʈ Ȱ��ȭ �� ������Ʈ�� ��Ȱ��ȭ, �ε� ȭ�� ���
        //startBGM_Obj.SetActive(false);
        postProcessing.SetActive(false);
        miniGameGroup.gameObject.SetActive(false);
        isLoading = true;
        StartCoroutine(LoadingAnim());

        // ���� �� �ε����� SvaeLoadMgn �� ����
        NowScene = SceneManager.GetActiveScene();
        SceneNum = NowScene.buildIndex;
        SaveLoadMgn.instance.SaveData(SceneNum);
    }

    IEnumerator LoadingAnim()
    {
        // �� 1.5�� �� �ε� ȭ�� ��Ȱ��ȭ, ������Ʈ�� ��� Ȱ��ȭ
        yield return new WaitForSeconds(1.5f);

        loadingTextGroup.gameObject.SetActive(false);

        //startBGM_Obj.SetActive(true);
        postProcessing.SetActive(true);
        miniGameGroup.gameObject.SetActive(true);

        isLoading = false;
    }

    private void Update()
    {
        // ���� �� �� ���� �̴ϰ����ΰ��� ���� �޶���
        // checkCount�� Ư�� ������ �Ǹ� ����/������ �Ǻ�

        // ���� �̴ϰ����� ������ 2���� ��
        if (isTwosGame)
        {
            if (checkCount == 2)
            {
                Conform();
            }

        }
        // ���� �̴ϰ����� ������ 1���� ��
        else if (isSingleGame)
        {
            if (checkCount == 1)
            {
                Conform_ver2();
            }
        }
        // ���� �̴ϰ����� ������ 3���� ��
        else if (isThirdGame)
        {
            if (checkCount == 3)
            {
                Conform_ver3();
            }
        }

    }

    // ������ Ŭ�� �� isClear �迭 ���º����� true,
    // ���� true �� �� clearGroup �� ���

    // ������ 2���� �̴ϰ����� �� ���� �Ǻ� �Լ�
    public void Conform()
    {
        if (isClear[0] && isClear[1])
        {
            Time.timeScale = 0;
            clearGroup.gameObject.SetActive(true);
        }
        else
        {
            Time.timeScale = 0;
            failGroup.gameObject.SetActive(true);
        }
    }

    // ������ 1���� �̴ϰ����� �� ���� �Ǻ� �Լ�
    public void Conform_ver2()
    {
        if (isClear[0])
        {
            Time.timeScale = 0;
            clearGroup.gameObject.SetActive(true);
        }
        else
        {
            Time.timeScale = 0;
            failGroup.gameObject.SetActive(true);
        }
    }

    // ������ 3���� �̴ϰ����� �� ���� �Ǻ� �Լ�
    public void Conform_ver3()
    {
        if (isClear[0] && isClear[1] && isClear[2])
        {
            Time.timeScale = 0;
            clearGroup.gameObject.SetActive(true);
        }
        else
        {
            Time.timeScale = 0;
            failGroup.gameObject.SetActive(true);
        }
    }

    // ���� �� ����Ǵ� ��� �Լ�
    public void Cancel()
    {
        // ��ư Ŭ�� ȿ���� ��� �� timeScale�� 1��, cheackCoung 0���� �ʱ�ȭ
        SFX_Mgn.instance.SFX_Source.PlayOneShot(btnClickSFX);
        Time.timeScale = 1;
        checkCount = 0;

        // Ŭ���� �� ���� ����� ���� ��� �� ��ŭ false �� �ʱ�ȭ
        for(int i = 0; i < isClear.Length; i++)
        {
            isClear[i] = false;
        }

        // ��ư ����� ������Ʈ���� ���� ��ư ��� ����ŭ Ȱ��ȭ
        for(int j = 0; j < clueBtns.Length; j++)
        {
            clueBtns[j].SetActive(true);
        }

        // ���õ� ��ư ��� �� ��ŭ ���õ� ��ư ��Ȱ��ȭ
        for(int f = 0; f < clueBtns_Press.Length; f++)
        {
            clueBtns_Press[f].SetActive(false);
        }

        // �߸� ���� ȭ�� ��Ȱ��ȭ
        failGroup.gameObject.SetActive(false);

    }

    // �ð� �ʰ� �� ���� ����ȭ������ �ٽ� �ε�
    public void TimeOver()
    {
        StartCoroutine(GoGameScene());
    }

    // �ð� �ʰ� �� ���� ����ȭ������ �ٽ� �ε��� �� ������ �� �ε�
    IEnumerator GoGameScene()
    {
        yield return new WaitForSeconds(0.7f);

        SceneManager.LoadScene(SceneNum);
    }

    // �̴ϰ��� �Ϸ� �� ��ȭ ����
    public void GoDialgoue()
    {
        miniGameGroup.gameObject.SetActive(false);
        dialogueGroup.gameObject.SetActive(true);
        dialogue.gameObject.SetActive(true);
    }

}
