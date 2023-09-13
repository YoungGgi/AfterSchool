using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class Order_ClueBtn : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
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

    public int ID;

    public ClueObject clue;                     // 단서

    public OrderMiniGameMgn orderMiniGameMgn;

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

    // 단서 선택
    public void ClueSelect()
    {
        orderMiniGameMgn.isClear.Add(ID);
        clueButton.enabled = false;
        explainBox.gameObject.SetActive(false);
        orderMiniGameMgn.checkCount++;
    }


}
