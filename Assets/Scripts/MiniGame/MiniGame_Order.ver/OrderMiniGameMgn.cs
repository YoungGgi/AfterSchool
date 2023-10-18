using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OrderMiniGameMgn : MonoBehaviour
{
    [SerializeField]
    private GameObject failGroup;              // �ܼ� ���� �׷�
    [SerializeField]
    private GameObject clearGroup;             // �ܼ� ���� �׷�


    public List<int> isClear;
    public GameObject[] clueBtns;
    public GameObject[] clueBtns_Press;         // ���õ� ��ư ���

    public int checkCount;

    public GameObject dialogueGroup;
    public GameObject dialogue;
    public GameObject miniGameGroup;

    public AudioClip btnClickSFX;                 // ��ư Ŭ�� ȿ����

    public GameObject loadingTextGroup;                // ���� ���� �� �ε� ȭ��(�ڵ� ����)
    bool isOrderLoading;                               // �ε� ���� Ȯ�� ��������(�Ʒ��� ĸ��ȭ ����)
    public GameObject postProcessing;                  // ��ó�� ȿ�� ������Ʈ
    public GameObject mainMenuGroup;

    public Scene NowScene;
    public int SceneNum;

    public bool IsOrderLoading { get => isOrderLoading; set => isOrderLoading = value; }

    private void OnEnable()
    {
        postProcessing.SetActive(false);
        miniGameGroup.gameObject.SetActive(false);
        isOrderLoading = true;
        StartCoroutine(LoadingAnim());

        NowScene = SceneManager.GetActiveScene(); // �� �����Ӹ��� ���� �� Ȯ���ϱ�
        SceneNum = NowScene.buildIndex;
        SaveLoadMgn.instance.SaveData(SceneNum);
    }

    IEnumerator LoadingAnim()
    {
        // �� 1.5�� �� �ε� ȭ�� ��Ȱ��ȭ, ������Ʈ�� ��� Ȱ��ȭ
        yield return new WaitForSeconds(1.5f);

        loadingTextGroup.gameObject.SetActive(false);

        postProcessing.SetActive(true);
        miniGameGroup.gameObject.SetActive(true);

        isOrderLoading = false;
    }

    private void Update()
    {
        
        if(checkCount == 4)
        {
            Conform();
        }

        if (Input.GetKeyUp(KeyCode.Escape))
        {
            mainMenuGroup.SetActive(true);
        }
    }

    // ������ Ŭ�� �� isClear �迭 ���º����� true,
    // ���� true �� �� clearGroup �� ���
    public void Conform()
    {
        if (isClear[0] == 1 && isClear[1] == 2 && isClear[2] == 3 && isClear[3] == 4)
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

    public void Cancel()
    {
        SFX_Mgn.instance.SFX_Source.PlayOneShot(btnClickSFX);
        Time.timeScale = 1;
        checkCount = 0;

        isClear.Clear();

        for (int j = 0; j < clueBtns.Length; j++)
        {
            clueBtns[j].SetActive(true);
        }

        // ���õ� ��ư ��� �� ��ŭ ���õ� ��ư ��Ȱ��ȭ
        for (int f = 0; f < clueBtns_Press.Length; f++)
        {
            clueBtns_Press[f].SetActive(false);
        }

        failGroup.gameObject.SetActive(false);

    }

    public void TimeOver()
    {
        StartCoroutine(GoGameScene());
    }

    IEnumerator GoGameScene()
    {
        yield return new WaitForSeconds(0.7f);

        SceneManager.LoadScene(SceneNum);
    }

    public void GoDialgoue()
    {
        miniGameGroup.gameObject.SetActive(false);
        dialogueGroup.gameObject.SetActive(true);
        dialogue.gameObject.SetActive(true);
    }
}
