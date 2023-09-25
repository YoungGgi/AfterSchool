using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class ClueSelectBtn : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    private Button clueButton;                  // 단서 버튼
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
        clueText.text = clue.clueName;
        explainText.text = clue.clueExplain;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        questionBox.gameObject.SetActive(false);
        explainBox.gameObject.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        questionBox.gameObject.SetActive(true);
        explainBox.gameObject.SetActive(false);
    }

    // 단서 선택(오답 버튼 클릭시)
    public void ClueSelect()
    {
        SFX_Mgn.instance.SFX_Source.PlayOneShot(btnClickSFX);
        clueButton.enabled = false;
        explainBox.gameObject.SetActive(false);
        miniManager.checkCount++;
    }

    // 단서 선택(정답1 클릭 시)
    public void ClueSelect_Clear()
    {
        SFX_Mgn.instance.SFX_Source.PlayOneShot(btnClickSFX);
        miniManager.isClear[0] = true;
        clueButton.enabled = false;
        explainBox.gameObject.SetActive(false);
        miniManager.checkCount++;
    }

    // 단서 선택(정답2 클릭 시)
    public void ClueSelect_Clear2()
    {
        SFX_Mgn.instance.SFX_Source.PlayOneShot(btnClickSFX);
        miniManager.isClear[1] = true;
        clueButton.enabled = false;
        explainBox.gameObject.SetActive(false);
        miniManager.checkCount++;
    }

    
}
