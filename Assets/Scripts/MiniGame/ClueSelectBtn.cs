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
    private GameObject clueButton_Pressed;          // 단서 비활성화 버튼
    [SerializeField]
    private TextMeshProUGUI clueText;               // 단서 텍스트
    [SerializeField]
    private GameObject explainBox;                  // 단서 설명 텍스트 오브젝트
    [SerializeField]
    private GameObject questionBox;                 // 추리게임 문제 오브젝트
    [SerializeField]
    private TextMeshProUGUI explainText;            // 단서 설명 텍스트

    public AudioClip btnClickSFX;                   // 버튼 클릭 효과음

    public ClueObject clue;                         // 단서

    public MiniGameMgn miniManager;

    private void Start()
    {
        clueText.text = clue.clueName;
        explainText.text = clue.clueExplain;
    }

    // 마우스 커서가 버튼 위에 있을시
    public void OnPointerEnter(PointerEventData eventData)
    {
        questionBox.gameObject.SetActive(false);
        explainBox.gameObject.SetActive(true);
    }

    // 마우스 커서가 버튼 위에 있지 않을 시
    public void OnPointerExit(PointerEventData eventData)
    {
        questionBox.gameObject.SetActive(true);
        explainBox.gameObject.SetActive(false);
    }

    // 단서 선택 (오답일 때)
    public void ClueSelect()
    {
        SFX_Mgn.instance.SFX_Source.PlayOneShot(btnClickSFX);

        clueButton_Pressed.SetActive(true);
        explainBox.gameObject.SetActive(false);
        miniManager.checkCount++;

        clueButton.SetActive(false);
    }

    // 단서 선택 (정답일 때)
    public void ClueSelect_Clear()
    {
        SFX_Mgn.instance.SFX_Source.PlayOneShot(btnClickSFX);
        miniManager.isClear[0] = true;

        clueButton_Pressed.SetActive(true);
        explainBox.gameObject.SetActive(false);
        miniManager.checkCount++;

        clueButton.SetActive(false);
    }

    // 단서 선택 (정답일 때 - 복수 정답1)
    public void ClueSelect_Clear2()
    {
        SFX_Mgn.instance.SFX_Source.PlayOneShot(btnClickSFX);
        miniManager.isClear[1] = true;

        clueButton_Pressed.SetActive(true);
        explainBox.gameObject.SetActive(false);
        miniManager.checkCount++;

        clueButton.SetActive(false);
    }

    // 단서 선택 (정답일 때 - 복수 정답2)
    public void ClueSelect_Clear3()
    {
        SFX_Mgn.instance.SFX_Source.PlayOneShot(btnClickSFX);
        miniManager.isClear[2] = true;

        clueButton_Pressed.SetActive(true);
        explainBox.gameObject.SetActive(false);
        miniManager.checkCount++;

        clueButton.SetActive(false);
    }
}
