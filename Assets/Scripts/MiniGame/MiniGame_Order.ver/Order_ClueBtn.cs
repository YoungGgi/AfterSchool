using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Order_ClueBtn : MonoBehaviour
{
    [SerializeField]
    private GameObject clueButton;                  // 단서 버튼
    [SerializeField]
    private TextMeshProUGUI clueText;           // 버튼에 있는 단서 제목
    [SerializeField]
    private GameObject clueButton_Pressed;      // 선택된 단서 버튼
    /*
    [SerializeField]
    private GameObject explainBox;                 // 단서 설명할 대화상자
    [SerializeField]
    private GameObject questionBox;
    [SerializeField]
    private TextMeshProUGUI explainText;          // 단서 설명 대화상자 텍스트
    */
    public int ID;

    public ClueObject clue;                     // 단서

    public OrderMiniGameMgn orderMiniGameMgn;

    private void Start()
    {
        clueText.text = clue.clueName;
        //explainText.text = clue.clueExplain;
    }

    // 단서 선택
    public void ClueSelect()
    {
        orderMiniGameMgn.isClear.Add(ID);
        clueButton_Pressed.SetActive(true);
       //explainBox.gameObject.SetActive(false);

        orderMiniGameMgn.checkCount++;
        clueButton.gameObject.SetActive(false);
    }


}
