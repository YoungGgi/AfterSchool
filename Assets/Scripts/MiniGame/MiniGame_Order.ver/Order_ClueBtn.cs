using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class Order_ClueBtn : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    private Button clueButton;                  // �ܼ� ��ư
    [SerializeField]
    private TextMeshProUGUI clueText;           // ��ư�� �ִ� �ܼ� ����
    [SerializeField]
    private GameObject explainBox;                 // �ܼ� ������ ��ȭ����
    [SerializeField]
    private GameObject questionBox;
    [SerializeField]
    private TextMeshProUGUI explainText;          // �ܼ� ���� ��ȭ���� �ؽ�Ʈ

    public int ID;

    public ClueObject clue;                     // �ܼ�

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

    // �ܼ� ����
    public void ClueSelect()
    {
        orderMiniGameMgn.isClear.Add(ID);
        clueButton.enabled = false;
        explainBox.gameObject.SetActive(false);
        orderMiniGameMgn.checkCount++;
    }


}
