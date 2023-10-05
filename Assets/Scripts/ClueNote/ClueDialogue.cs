using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClueDialogue : MonoBehaviour
{
    public Dialogue_Base dialogue;                    // 진행할 대화 데이터(ScriptableObject)
    public A_Dialogue a_Dialogue;                     // 대화 진행 클래스

    public bool isAuto;                               // 오토 기능 상태 변수
    public float dealyCool;                           // 다음 대화 텍스트로 넘어갈 시 딜레이

    public GameObject autoText;                       // 오토 기능 활성화 시 출력될 오토 오브젝트

    public GameObject black;
    public GameObject loadingTextGroup;               // 씬 시작 시 출력될 빈 화면 오브젝트

    bool isLoading;                                   // 로딩 상태 변수

    public GameObject auto_Btn;                       // 오토 버튼
    public GameObject auto_true_Btn;                  // 오토 비활성화 버튼

    public GameObject speed2_Btn;                     // 2배속 버튼
    public GameObject speed2_true_Btn;                // 2배속 비활성화 버튼

    public GameObject dialogueObj;

    // 해당 오브젝트 활성화 시 호출되는 함수
    void OnEnable()
    {
        // 로딩 상태를 true로 반환 후 LoadingAnim 코루틴 실행
        isLoading = true;
        StartCoroutine(LoadingAnim());
        
        // 씬 시작 시 오토 기능이 활성화되어 있다면 오토 오브젝트, 버튼 활성화
        if (StroyDataMgn.instance.IsAutoLive)
        {
            autoText.gameObject.SetActive(true);

            auto_Btn.gameObject.SetActive(false);
            auto_true_Btn.gameObject.SetActive(true);
        }

        // 씬 시작 시 2배속 기능이 활성화되어 있다면 2배속 오브젝트, 버튼 활성화
        if (StroyDataMgn.instance.IsTwoSpeed)
        {
            speed2_Btn.gameObject.SetActive(false);
            speed2_true_Btn.gameObject.SetActive(true);
        }

    }

    IEnumerator LoadingAnim()
    {
        // 약 1.5초 딜레이 후 자동 저장 로딩 화면 비활성화, 대화 시작(EnQueue), 로딩 상태 변수 false 반환
        yield return new WaitForSeconds(0.5f);
        Debug.Log("Start");
        dialogueObj.gameObject.SetActive(true);

        black.SetActive(false);
        loadingTextGroup.SetActive(false);

        a_Dialogue.EnqueuDialogue(dialogue);

        isLoading = false;

    }

    void Update()
    {
        // 로딩 중일 시 return
        if (isLoading || StroyDataMgn.instance.IsSettingOn)
            return;
        else
        {
            // StroyDataMgn 의 오토 기능이 true 되어 있고, 현재 대화 텍스트 전부 출력 시
            if (StroyDataMgn.instance.IsAutoLive && a_Dialogue.isTextComplete == true)
            {
                // 오토 오브젝트 활성화
                autoText.gameObject.SetActive(true);
                // 약간의 딜레이 후 다음 텍스트 출력.
                StartCoroutine(NextDelay());
                a_Dialogue.DequeueDialogue();
            }

            // StroyDataMgn의 오토 기능이 false 일 시 오토 오브젝트 비활성화
            if (StroyDataMgn.instance.IsAutoLive == false)
            {
                autoText.gameObject.SetActive(false);
            }

            // 스페이스 키 혹은 Enter 입력 시
            if ((Input.GetKeyUp(KeyCode.Space)) || (Input.GetKeyUp(KeyCode.Return)))
            {
                // 약간의 딜레이 후 다음 텍스트 출력
                StartCoroutine(NextDelay());
                a_Dialogue.DequeueDialogue();
            }

            // StroyDataMgn의 연출용 오토 기능이 true 이고, 현재 대화 텍스트가 모두 출력 시
            if (StroyDataMgn.instance.IsAutoStory && a_Dialogue.isTextComplete == true)
            {
                // 약간의 딜레이 후 다음 텍스트 출력
                StartCoroutine(NextDelay());
                a_Dialogue.DequeueDialogue();
            }

        }
    }

    // 다음 대화 텍스트 진행 시 딜레이
    IEnumerator NextDelay()
    {
        yield return new WaitForSeconds(dealyCool);
    }

    // 대화 화면의 버튼 클릭 시 다음 대화 텍스트 진행(DeQueue)
    public void Next() => a_Dialogue.DequeueDialogue();

}
