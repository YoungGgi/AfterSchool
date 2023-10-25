using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OrderMiniGameMgn : MonoBehaviour
{
    [SerializeField]
    private GameObject failGroup;              // 추리실패 오브젝트
    [SerializeField]
    private GameObject clearGroup;             // 추리성공 오브젝트


    public List<int> isClear;
    public GameObject[] clueBtns;
    public GameObject[] clueBtns_Press;         

    public int checkCount;

    public GameObject dialogueGroup;
    public GameObject dialogue;
    public GameObject miniGameGroup;

    public AudioClip btnClickSFX;                 

    public GameObject loadingTextGroup;           // 로딩 화면 오브젝트 (자동 저장)
    bool isOrderLoading;                          
    public GameObject postProcessing;             // 후러치 효과 오브젝트
    public GameObject mainMenuGroup;

    // 현재 씬 인덱스
    public Scene NowScene;
    public int SceneNum;

    // isOrderLoading 캡슐화
    public bool IsOrderLoading { get => isOrderLoading; set => isOrderLoading = value; }

    private void OnEnable()
    {
        postProcessing.SetActive(false);
        miniGameGroup.gameObject.SetActive(false);
        isOrderLoading = true;
        StartCoroutine(LoadingAnim());

        NowScene = SceneManager.GetActiveScene(); // 현재 씬 인덱스 정보를 자동 저장
        SceneNum = NowScene.buildIndex;
        SaveLoadMgn.instance.SaveData(SceneNum);
    }

    IEnumerator LoadingAnim()
    {
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

    // 단서 선택을 할 때마다 isClear 배열의 인덱스 값 true 반환
    // 모든 isClear 인덱스가 true 반환 시 정답
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
