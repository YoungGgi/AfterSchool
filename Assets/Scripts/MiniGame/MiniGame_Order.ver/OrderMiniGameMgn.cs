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
    public GameObject[] clueBtns;
    public GameObject[] clueBtns_Press;         // 선택된 버튼 목록

    public int checkCount;

    public GameObject dialogueGroup;
    public GameObject dialogue;
    public GameObject miniGameGroup;

    public AudioClip btnClickSFX;                 // 버튼 클릭 효과음

    public GameObject loadingTextGroup;                // 게임 시작 전 로딩 화면(자동 저장)
    bool isOrderLoading;                               // 로딩 여부 확인 논리변수(아래의 캡슐화 참조)
    public GameObject postProcessing;                  // 후처리 효과 오브젝트

    public Scene NowScene;
    public int SceneNum;

    public bool IsOrderLoading { get => isOrderLoading; set => isOrderLoading = value; }

    private void OnEnable()
    {
        postProcessing.SetActive(false);
        miniGameGroup.gameObject.SetActive(false);
        isOrderLoading = true;
        StartCoroutine(LoadingAnim());

        NowScene = SceneManager.GetActiveScene(); // 매 프레임마다 현재 씬 확인하기
        SceneNum = NowScene.buildIndex;
        SaveLoadMgn.instance.SaveData(SceneNum);
    }

    IEnumerator LoadingAnim()
    {
        // 약 1.5초 후 로딩 화면 비활성화, 오브젝트들 모두 활성화
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
    }

    // 정답을 클릭 시 isClear 배열 상태변수가 true,
    // 전부 true 일 시 clearGroup 을 출력
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

        // 선택된 버튼 목록 수 만큼 선택된 버튼 비활성화
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
