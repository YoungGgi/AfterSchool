using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;

public class Test_Dialogue : MonoBehaviour
{

    public Dialogue_Base dialogue;                    // 대화 데이터(ScriptableObject)
    public A_Dialogue a_Dialogue;                     // 대화 스크립트

    public bool isAuto;                               // 오토 상태 논리 함수
    public float dealyCool;                           // 대화 진행 딜레이

    public GameObject autoText;                       // 오토 오브젝트
    public GameObject mainGroup;                      // 대화 메인 메뉴

    public GameObject loadingTextGroup;               // 로딩 화면(자동 저장)

    bool isLoading;                                   // 로딩 논리 함수(아래의 캡슐화 참조)

    public GameObject auto_Btn;                       // 오토 버튼
    public GameObject auto_true_Btn;                  // 오토 활성화 버튼

    public GameObject speed2_Btn;                     // 2배속 버튼
    public GameObject speed2_true_Btn;                // 2배속 활성화 버튼

    public Button nextBtn;

    public Scene NowScene;                            // 현재 씬 넘버
    public int SceneNum;                              

    void OnEnable()
    {
        // 로딩 출력
        isLoading = true;
        StartCoroutine(LoadingAnim());

        // 현재 씬 인덱스 넘버를 자동저장(SaveLoadMgn)
        NowScene = SceneManager.GetActiveScene();
        SceneNum = NowScene.buildIndex;
        SaveLoadMgn.instance.SaveData(SceneNum);

        // 현재 오토 상태일 경우 오토 오브젝트, 버튼 활성화
        if (StroyDataMgn.instance.IsAutoLive)
        {
            autoText.gameObject.SetActive(true);

            auto_true_Btn.gameObject.SetActive(false);
            auto_Btn.gameObject.SetActive(true);
        }

        // 현재 2배속 상태일 경우 2배속 버튼 활성화
        if (StroyDataMgn.instance.IsTwoSpeed)
        {
            speed2_true_Btn.gameObject.SetActive(false);
            speed2_Btn.gameObject.SetActive(true);
        }

    }

    // 로딩 화면(자동 저장) 출력 함수
    IEnumerator LoadingAnim()
    {
        yield return new WaitForSeconds(1.5f);

        loadingTextGroup.gameObject.SetActive(false);

        a_Dialogue.EnqueuDialogue(dialogue);

        isLoading = false;

    }


    void Update()
    {
        // 로딩중 or 대화중 메인메뉴 클릭시 return
        if (isLoading || StroyDataMgn.instance.IsSettingOn)
            return;
        

        if(!StroyDataMgn.instance.IsSettingOn)
        {
            // 오토 상태이고 현재 대화 인덱스 모두 출력시 오토 오브젝트 활성화,
            if (StroyDataMgn.instance.IsAutoLive && a_Dialogue.isTextComplete == true)
            {
                autoText.gameObject.SetActive(true);
                // 딜레이 후 다음 인덱스 출력
                StartCoroutine(NextDelay());
                a_Dialogue.DequeueDialogue();
            }

            // 오토 상태가 아닐경우 오토 오브젝트 비활성화
            if (StroyDataMgn.instance.IsAutoLive == false)
            {
                autoText.gameObject.SetActive(false);
            }

            if (Input.GetKeyUp(KeyCode.Escape))
            {
                nextBtn.enabled = false;
                mainGroup.SetActive(true);
                StroyDataMgn.instance.IsSettingOn = true;
            }

            // Space or Enter 키 입력시 대화 진행
            if (Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.Return))
            {
                StartCoroutine(NextDelay());
                Next();
            }

            // 대화 전용 오토 상태이고 대화 인덱스 모두 출력시 다음 인덱스 출력
            if (StroyDataMgn.instance.IsAutoStory && a_Dialogue.isTextComplete == true)
            {
                StartCoroutine(NextDelay());
                a_Dialogue.DequeueDialogue();
            }
        }
    }

    IEnumerator NextDelay()
    {
        yield return new WaitForSeconds(dealyCool);
    }

    // 화면 클릭시 다음 대화 인덱스 출력(DeQueue)
    public void Next() => a_Dialogue.DequeueDialogue();

    public void DialgoueBtnActivate() => nextBtn.enabled = true;


}
