using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Order_ClueBtn : MonoBehaviour
{
    [SerializeField]
    private GameObject clueButton;                  // �ܼ� ��ư
    [SerializeField]
    private TextMeshProUGUI clueText;           // ��ư�� �ִ� �ܼ� ����
    [SerializeField]
    private GameObject clueButton_Pressed;      // ���õ� �ܼ� ��ư
    
    public int ID;

    public ClueObject clue;                     // �ܼ�

    public OrderMiniGameMgn orderMiniGameMgn;

    private void Start()
    {
        clueText.text = clue.clueName;
    }

    // �ܼ� ����
    public void ClueSelect()
    {
        orderMiniGameMgn.isClear.Add(ID);
        clueButton_Pressed.SetActive(true);

        orderMiniGameMgn.checkCount++;
        clueButton.gameObject.SetActive(false);
    }


}
