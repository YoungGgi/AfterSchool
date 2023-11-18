using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MiniGameMgn : MonoBehaviour
{
    [SerializeField]
    private GameObject failGroup;              // 실패 오브젝트 그룹
    [SerializeField]
    private GameObject clearGroup;             // 성공 오브젝트 그룹


    public bool[] isClear;                      // 정답 판별 논리 변수 목록
    public GameObject[] clueBtns;               // 선택지 목록
    public GameObject[] clueBtns_Press;         // 선택지 입력 목록

    public int checkCount;                      // 선택지 선택 카운트

    // 게임 종료후 대화 진행을 위한 대화 / 추리게임 전체 UI 오브젝트
    public GameObject dialogueGroup;                  
    public GameObject dialogue;                    
    public GameObject miniGameGroup;            

    public GameObject loadingTextGroup;          // 자동저장 화면(로딩)
    bool isLoading;                              // 로딩 여부 확인 논리 변수

    // 현재 씬 카운트 확인
    public Scene NowScene;
    public int SceneNum;

    public bool isSingleGame;                 // 정답이 1개일 경우 논리 변수
    public bool isTwosGame;                   // 정답이 2개일 경우 논리 변수
    public bool isThirdGame;                  // 정답이 3개일 경우 논리 변수

    public AudioClip clearSFX;                // 성공 효과음
    public AudioClip failSFX;                 // 실패 효과음
    public AudioClip btnClickSFX;             // 버튼 클릭 효과음

    public GameObject postProcessing;         // 후처리 효과 오브젝트
    public GameObject startBGM_Obj;           // BGM 시작 오브젝트
    public GameObject mainMenuGroup;          // 추리 게임 메인 메뉴

    public GameObject effectGroup;

    // 로딩 논리 변수 캡슐화
    public bool IsLoading { get => isLoading; set => isLoading = value; }

    void OnEnable()
    {
        postProcessing.SetActive(false);
        miniGameGroup.gameObject.SetActive(false);
        isLoading = true;
        StartCoroutine(LoadingAnim());
        //effectGroup.SetActive(false);

        // 현재 씬 넘버를 자동저장(SaveLoadMgn)에 저장
        NowScene = SceneManager.GetActiveScene();
        SceneNum = NowScene.buildIndex;
        SaveLoadMgn.instance.SaveData(SceneNum);
    }

    IEnumerator LoadingAnim()
    {
        yield return new WaitForSeconds(1.5f);

        loadingTextGroup.gameObject.SetActive(false);
        postProcessing.SetActive(true);
        miniGameGroup.gameObject.SetActive(true);

        isLoading = false;
    }

    private void Update()
    {
        // 선택지를 클릭하면 checkCount 증가
        // checkCount가 일정 개수 도달 시 정답 판별

        // 정답이 2개일 경우(isTwoGame)
        if (isTwosGame)
        {
            if (checkCount == 2)
            {
                Conform();
            }

        }
        // 정답이 1개일 경우(isSingleGame)
        else if (isSingleGame)
        {
            if (checkCount == 1)
            {
                Conform_ver2();
            }
        }
        // 정답이 3개일 경우(isThirdGame)
        else if (isThirdGame)
        {
            if (checkCount == 3)
            {
                Conform_ver3();
            }
        }

        if(Input.GetKeyUp(KeyCode.Escape))
        {
            mainMenuGroup.SetActive(true);
        }

    }

    // 정답 선택지를 고를 시 isClear 리스트의 인덱스 true 판정
    // 모두 true 판정일 시 clearGroup 활성화

    public void Conform()
    {
        if (isClear[0] && isClear[1])
        {
            //effectGroup.SetActive(true);
            clearGroup.gameObject.SetActive(true);
        }
        else
        {
            //effectGroup.SetActive(false);
            failGroup.gameObject.SetActive(true);
        }
    }

    public void Conform_ver2()
    {
        if (isClear[0])
        {
            //effectGroup.SetActive(true);
            clearGroup.gameObject.SetActive(true);
        }
        else
        {
            //effectGroup.SetActive(false);
            failGroup.gameObject.SetActive(true);
        }
    }

    public void Conform_ver3()
    {
        if (isClear[0] && isClear[1] && isClear[2])
        {
            //effectGroup.SetActive(true);
            clearGroup.gameObject.SetActive(true);
        }
        else
        {
            //effectGroup.SetActive(false);
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
            clueBtns[j].SetActive(true);
        }

        
        for(int f = 0; f < clueBtns_Press.Length; f++)
        {
            clueBtns_Press[f].SetActive(false);
        }

        
        failGroup.gameObject.SetActive(false);

    }

    // �̴ϰ��� �Ϸ� �� ��ȭ ����
    public void GoDialgoue()
    {
        miniGameGroup.gameObject.SetActive(false);
        dialogueGroup.gameObject.SetActive(true);
        dialogue.gameObject.SetActive(true);
    }

}
