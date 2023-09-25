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

    public AudioClip clearSFX;                // ���� ȿ����
    public AudioClip failSFX;                 // ���� ȿ����
    public AudioClip btnClickSFX;             // ��ư Ŭ�� ȿ����

    public GameObject postProcessing;
    public GameObject startBGM_Obj;

    public bool IsLoading { get => isLoading; set => isLoading = value; }

    void OnEnable()
    {
        startBGM_Obj.SetActive(false);
        postProcessing.SetActive(false);
        miniGameGroup.gameObject.SetActive(false);
        isLoading = true;
        StartCoroutine(LoadingAnim());

        NowScene = SceneManager.GetActiveScene();
        SceneNum = NowScene.buildIndex;
        SaveLoadMgn.instance.SaveData(SceneNum);
    }

    IEnumerator LoadingAnim()
    {
        yield return new WaitForSeconds(1.5f);

        loadingTextGroup.gameObject.SetActive(false);

        startBGM_Obj.SetActive(true);
        postProcessing.SetActive(true);
        miniGameGroup.gameObject.SetActive(true);

        isLoading = false;
    }

    private void Update()
    {
        
        // ���� �� �� ���� �̴ϰ����ΰ��� ���� �޶���
        // checkCount�� Ư�� ������ �Ǹ� ����/������ �Ǻ�
        if (isTwosGame)
        {
            if (checkCount == 2)
            {
                Conform();
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
                Conform_ver3();
            }
        }

    }

    // ������ Ŭ�� �� isClear �迭 ���º����� true,
    // ���� true �� �� clearGroup �� ���
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

    public void Cancel()
    {
        SFX_Mgn.instance.SFX_Source.PlayOneShot(btnClickSFX);
        Time.timeScale = 1;
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
