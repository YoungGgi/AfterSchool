using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OrderMiniGameMgn : MonoBehaviour
{
    [SerializeField]
    private GameObject failGroup;              // 단서 오답 그룹
    [SerializeField]
    private GameObject clearGroup;             // 단서 정답 그룹


    public List<int> isClear;
    public Button[] clueBtns;

    public int checkCount;

    public GameObject dialogueGroup;
    public GameObject dialogue;
    public GameObject miniGameGroup;

    public Scene NowScene;
    public int SceneNum;

    private void Update()
    {
        NowScene = SceneManager.GetActiveScene(); // 매 프레임마다 현재 씬 확인하기
        SceneNum = NowScene.buildIndex;

        if(checkCount == 4)
        {
            Conform();
        }
    }

    // 정답을 클릭 시 isClear 배열 상태변수가 true,
    // 전부 true 일 시 clearGroup 을 출력
    public void Conform()
    {
        if (isClear[0] == 1 && isClear[1] == 2 && isClear[2] == 3 && isClear[3] == 4)
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

        isClear.Clear();

        for (int j = 0; j < clueBtns.Length; j++)
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
