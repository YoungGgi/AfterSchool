using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ClueSelectBtn : MonoBehaviour
{
    [SerializeField]
    private Button clueButton;                  // 단서 버튼
    [SerializeField]
    private TextMeshProUGUI clueText;           // 버튼에 있는 단서 제목
    [SerializeField]
    private GameObject explainBox;                 // 단서 설명할 대화상자
    [SerializeField]
    private TextMeshProUGUI explainText;          // 단서 설명 대화상자 텍스트

    public ClueObject clue;                     // 단서

    public MiniGameMgn miniManager;

    private void Start()
    {
        clueText.text = clue.clueName;
        explainText.text = clue.clueExplain;
    }

    // 버튼 클릭시 해당 단서 설명창 출력
    public void OnExplainBox()
    {
        
        explainBox.gameObject.SetActive(true);
        
    }

    // 단서 선택(오답 버튼 클릭시)
    public void ClueSelect()
    {
        clueButton.enabled = false;
        explainBox.gameObject.SetActive(false);
        miniManager.checkCount++;
    }

    // 단서 취소(오답 버튼 클릭시)
    public void ClueCancel()
    {
        explainBox.gameObject.SetActive(false);
    }

    // 단서 선택(정답1 클릭 시)
    public void ClueSelect_Clear()
    {
        miniManager.isClear[0] = true;
        clueButton.enabled = false;
        explainBox.gameObject.SetActive(false);
        miniManager.checkCount++;
    }

    // 단서 취소(정답 1 클릭 시)
    public void ClueCancel_1()
    {
        miniManager.isClear[0] = false;
        explainBox.gameObject.SetActive(false);
    }

    // 단서 선택(정답2 클릭 시)
    public void ClueSelect_Clear2()
    {
       
        miniManager.isClear[1] = true;
        clueButton.enabled = false;
        explainBox.gameObject.SetActive(false);
        miniManager.checkCount++;
    }

    // 단서 취소(정답2 클릭 시)
    public void ClueCancel_2()
    {
        miniManager.isClear[1] = false;
        explainBox.gameObject.SetActive(false);
    }

}
