using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MiniGameMgn : MonoBehaviour
{
    [SerializeField]
    private GameObject failGroup;              // 단서 오답 그룹
    [SerializeField]
    private GameObject clearGroup;             // 단서 정답 그룹


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

    public bool isSingleGame;                 // 답을 하나만 고르는 미니게임일 때의 상태변수
    public bool isTwosGame;                   // 답을 두 개 고르는 미니게임일 때의 상태변수
    public bool isThirdGame;                  // 답을 세 개 고르는 미니게임일 때의 상태변수

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
        NowScene = SceneManager.GetActiveScene(); // 매 프레임마다 현재 씬 확인하기
        SceneNum = NowScene.buildIndex;

        // 답을 몇 개 고르는 미니게임인가에 따라 달라짐
        // checkCount가 특정 개수가 되면 정답/오답을 판별
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

    // 정답을 클릭 시 isClear 배열 상태변수가 true,
    // 전부 true 일 시 clearGroup 을 출력
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
