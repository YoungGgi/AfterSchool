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


    public bool[] isClear;
    public Button[] clueBtns;

    public int checkCount;

    public GameObject dialogueGroup;
    public GameObject dialogue;
    public GameObject miniGameGroup;

    public GameObject loadingTextGroup;
    bool isLoading;

    public Scene NowScene;
    public int SceneNum;

    public bool isSingleGame;                 // ���� �ϳ��� ���� �̴ϰ����� ���� ���º���
    public bool isTwosGame;                   // ���� �� �� ���� �̴ϰ����� ���� ���º���
    public bool isThirdGame;                  // ���� �� �� ���� �̴ϰ����� ���� ���º���

    public bool IsLoading { get => isLoading; set => isLoading = value; }

    void OnEnable()
    {
        miniGameGroup.gameObject.SetActive(false);
        isLoading = true;
        StartCoroutine(LoadingAnim());
    }

    IEnumerator LoadingAnim()
    {
        yield return new WaitForSeconds(1.5f);

        loadingTextGroup.gameObject.SetActive(false);

        miniGameGroup.gameObject.SetActive(true);

        isLoading = false;
    }

    private void Update()
    {
        NowScene = SceneManager.GetActiveScene(); // �� �����Ӹ��� ���� �� Ȯ���ϱ�
        SceneNum = NowScene.buildIndex;

        // ���� �� �� ���� �̴ϰ����ΰ��� ���� �޶���
        // checkCount�� Ư�� ������ �Ǹ� ����/������ �Ǻ�
        if (isTwosGame)
        {
            if (checkCount == 2)
            {
                Conform();
                //conformGroup.gameObject.SetActive(true);
            }

        }
        else if (isSingleGame)
        {
            if (checkCount == 1)
            {
                Conform_ver2();
            }
        }
        else if (isThirdGame)
        {
            if (checkCount == 3)
            {
                Conform_ver2();
            }
        }

    }

    // ������ Ŭ�� �� isClear �迭 ���º����� true,
    // ���� true �� �� clearGroup �� ���
    public void Conform()
    {
        if (isClear[0] && isClear[1])
        {
            clearGroup.gameObject.SetActive(true);
        }
        else
        {
            failGroup.gameObject.SetActive(true);
        }
    }

    public void Conform_ver2()
    {
        if (isClear[0])
        {
            clearGroup.gameObject.SetActive(true);
        }
        else
        {
            failGroup.gameObject.SetActive(true);
        }
    }

    public void Conform_ver3()
    {
        if (isClear[0] && isClear[1] && isClear[2])
        {
            clearGroup.gameObject.SetActive(true);
        }
        else
        {
            failGroup.gameObject.SetActive(true);
        }
    }

    public void Cancel()
    {
        checkCount = 0;

        for(int i = 0; i < isClear.Length; i++)
        {
            isClear[i] = false;
        }


        for(int j = 0; j < clueBtns.Length; j++)
        {
            clueBtns[j].enabled = true;
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
