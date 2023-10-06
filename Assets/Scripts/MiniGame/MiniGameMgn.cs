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


    public bool[] isClear;                      // 클리어 논리변수 목록
    public GameObject[] clueBtns;                   // 버튼 목록
    public GameObject[] clueBtns_Press;         // 선택된 버튼 목록

    public int checkCount;                      // 버튼 누를 때마다 카운트되는 변수

    // 대화 후 게임 진행 or 게임 진행 후 대화 시 적용되는 변수
    public GameObject dialogueGroup;                             // 대화 관련 UI 오브젝트들
    public GameObject dialogue;                                  // 대화 매니저
    public GameObject miniGameGroup;                             // 미니게임 관련 UI 오브젝트들

    public GameObject loadingTextGroup;               // 게임 시작 전 로딩 화면(자동 저장)
    bool isLoading;                                   // 로딩 여부 확인 논리변수(아래의 캡슐화 참조)

    // 현재 씬 인덱스 확인하는 변수들
    public Scene NowScene;
    public int SceneNum;

    public bool isSingleGame;                 // 답을 하나만 고르는 미니게임일 때의 상태변수
    public bool isTwosGame;                   // 답을 두 개 고르는 미니게임일 때의 상태변수
    public bool isThirdGame;                  // 답을 세 개 고르는 미니게임일 때의 상태변수

    public AudioClip clearSFX;                // 성공 효과음
    public AudioClip failSFX;                 // 실패 효과음
    public AudioClip btnClickSFX;             // 버튼 클릭 효과음

    public GameObject postProcessing;         // 후처리 효과 오브젝트
    public GameObject startBGM_Obj;           // BGM 시작 오브젝트

    // 로딩 논리함수 프로퍼티
    public bool IsLoading { get => isLoading; set => isLoading = value; }

    void OnEnable()
    {
        // 해당 오브젝트 활성화 시 오브젝트들 비활성화, 로딩 화면 출력
        //startBGM_Obj.SetActive(false);
        postProcessing.SetActive(false);
        miniGameGroup.gameObject.SetActive(false);
        isLoading = true;
        StartCoroutine(LoadingAnim());

        // 현재 씬 인덱스를 SvaeLoadMgn 에 저장
        NowScene = SceneManager.GetActiveScene();
        SceneNum = NowScene.buildIndex;
        SaveLoadMgn.instance.SaveData(SceneNum);
    }

    IEnumerator LoadingAnim()
    {
        // 약 1.5초 후 로딩 화면 비활성화, 오브젝트들 모두 활성화
        yield return new WaitForSeconds(1.5f);

        loadingTextGroup.gameObject.SetActive(false);

        //startBGM_Obj.SetActive(true);
        postProcessing.SetActive(true);
        miniGameGroup.gameObject.SetActive(true);

        isLoading = false;
    }

    private void Update()
    {
        // 답을 몇 개 고르는 미니게임인가에 따라 달라짐
        // checkCount가 특정 개수가 되면 정답/오답을 판별

        // 현재 미니게임의 정답이 2개일 때
        if (isTwosGame)
        {
            if (checkCount == 2)
            {
                Conform();
            }

        }
        // 현재 미니게임의 정답이 1개일 때
        else if (isSingleGame)
        {
            if (checkCount == 1)
            {
                Conform_ver2();
            }
        }
        // 현재 미니게임의 정답이 3개일 때
        else if (isThirdGame)
        {
            if (checkCount == 3)
            {
                Conform_ver3();
            }
        }

    }

    // 정답을 클릭 시 isClear 배열 상태변수가 true,
    // 전부 true 일 시 clearGroup 을 출력

    // 정답이 2개인 미니게임일 시 정답 판별 함수
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

    // 정답이 1개인 미니게임일 시 정답 판별 함수
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

    // 정답이 3개인 미니게임일 시 정답 판별 함수
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

    // 오답 시 실행되는 취소 함수
    public void Cancel()
    {
        // 버튼 클릭 효과음 재생 후 timeScale을 1로, cheackCoung 0으로 초기화
        SFX_Mgn.instance.SFX_Source.PlayOneShot(btnClickSFX);
        Time.timeScale = 1;
        checkCount = 0;

        // 클리어 논리 변수 목록을 현재 목록 수 만큼 false 로 초기화
        for(int i = 0; i < isClear.Length; i++)
        {
            isClear[i] = false;
        }

        // 버튼 목록의 오브젝트들을 현재 버튼 목록 수만큼 활성화
        for(int j = 0; j < clueBtns.Length; j++)
        {
            clueBtns[j].SetActive(true);
        }

        // 선택된 버튼 목록 수 만큼 선택된 버튼 비활성화
        for(int f = 0; f < clueBtns_Press.Length; f++)
        {
            clueBtns_Press[f].SetActive(false);
        }

        // 추리 실패 화면 비활성화
        failGroup.gameObject.SetActive(false);

    }

    // 시간 초과 시 현재 게임화면으로 다시 로드
    public void TimeOver()
    {
        StartCoroutine(GoGameScene());
    }

    // 시간 초과 시 현재 게임화면으로 다시 로드할 때 딜레이 후 로드
    IEnumerator GoGameScene()
    {
        yield return new WaitForSeconds(0.7f);

        SceneManager.LoadScene(SceneNum);
    }

    // 미니게임 완료 후 대화 진행
    public void GoDialgoue()
    {
        miniGameGroup.gameObject.SetActive(false);
        dialogueGroup.gameObject.SetActive(true);
        dialogue.gameObject.SetActive(true);
    }

}
