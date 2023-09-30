using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class ClueSelectBtn : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    private GameObject clueButton;                  // 단서 버튼
    [SerializeField]
    private GameObject clueButton_Pressed;      // 선택된 단서 버튼
    [SerializeField]
    private TextMeshProUGUI clueText;           // 버튼에 있는 단서 제목
    [SerializeField]
    private GameObject explainBox;                 // 단서 설명할 대화상자
    [SerializeField]
    private GameObject questionBox;
    [SerializeField]
    private TextMeshProUGUI explainText;          // 단서 설명 대화상자 텍스트

    public AudioClip btnClickSFX;             // 버튼 클릭 효과음

    public ClueObject clue;                     // 단서

    public MiniGameMgn miniManager;

    private void Start()
    {
        // 단서 이름과 설명을 해당 변수로 할당
        clueText.text = clue.clueName;
        explainText.text = clue.clueExplain;
    }

    // 마우스 포인터가 해당 오브젝트 위에 있을 시
    public void OnPointerEnter(PointerEventData eventData)
    {
        questionBox.gameObject.SetActive(false);
        explainBox.gameObject.SetActive(true);
    }

    // 마우스 포인터가 해당 오브젝트 위에 없을 시
    public void OnPointerExit(PointerEventData eventData)
    {
        questionBox.gameObject.SetActive(true);
        explainBox.gameObject.SetActive(false);
    }

    // 단서 선택(오답 버튼 클릭시)
    public void ClueSelect()
    {
        // 효과음 재생
        SFX_Mgn.instance.SFX_Source.PlayOneShot(btnClickSFX);

        // 선택된 상태의 오브젝트를 활성화한 후 miniManager의 checkCount를 1 증가
        clueButton_Pressed.SetActive(true);
        explainBox.gameObject.SetActive(false);
        miniManager.checkCount++;

        // 연속 클릭을 막기 위해 해당 오브젝트 비활성화
        clueButton.SetActive(false);
    }

    // 단서 선택(정답1 클릭 시)
    public void ClueSelect_Clear()
    {
        // 효과음 재생, miniManager의 isClear 리스트 활성화
        SFX_Mgn.instance.SFX_Source.PlayOneShot(btnClickSFX);
        miniManager.isClear[0] = true;

        // 선택된 상태의 오브젝트를 활성화한 후 miniManager의 checkCount를 1 증가
        clueButton_Pressed.SetActive(true);
        explainBox.gameObject.SetActive(false);
        miniManager.checkCount++;

        // 연속 클릭을 막기 위해 해당 오브젝트 비활성화
        clueButton.SetActive(false);
    }

    // 단서 선택(정답2 클릭 시)
    public void ClueSelect_Clear2()
    {
        // 효과음 재생, miniManager의 isClear 리스트 활성화
        SFX_Mgn.instance.SFX_Source.PlayOneShot(btnClickSFX);
        miniManager.isClear[1] = true;

        // 선택된 상태의 오브젝트를 활성화한 후 miniManager의 checkCount를 1 증가
        clueButton_Pressed.SetActive(true);
        explainBox.gameObject.SetActive(false);
        miniManager.checkCount++;

        // 연속 클릭을 막기 위해 해당 오브젝트 비활성화
        clueButton.SetActive(false);
    }

    
}
