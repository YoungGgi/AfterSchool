using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Order_ClueBtn : MonoBehaviour
{
    [SerializeField]
    private GameObject clueButton;              // 단서 버튼
    [SerializeField]
    private TextMeshProUGUI clueText;           // 단서 텍스트
    [SerializeField]
    private GameObject clueButton_Pressed;      // 단서 비활성화 버튼
    
    public int ID;

    public AudioClip btnClickSFX;               // 버튼 클릭 효과음

    public ClueObject clue;                     // 단서

    public OrderMiniGameMgn orderMiniGameMgn;

    private void Start()
    {
        clueText.text = clue.clueName;
    }

    // 단서 선택
    public void ClueSelect()
    {
        SFX_Mgn.instance.SFX_Source.PlayOneShot(btnClickSFX);
        
        orderMiniGameMgn.isClear.Add(ID);
        clueButton_Pressed.SetActive(true);

        orderMiniGameMgn.checkCount++;
        clueButton.gameObject.SetActive(false);
    }


}
