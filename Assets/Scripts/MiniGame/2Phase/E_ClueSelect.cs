using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class E_ClueSelect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    private Button clueButton;                  // �ܼ� ��ư
    [SerializeField]
    private TextMeshProUGUI clueText;           // ��ư�� �ִ� �ܼ� ����
    [SerializeField]
    private GameObject tool;                 // �ܼ� ����

    public ClueObject clue;                     // �ܼ�

    public E_MiniGame e_MiniGame;
    public ToolTip toolTip;

    private void Start()
    {
        clueText.text = clue.clueName;
    }

    public void ClueSelect()
    {
        clueButton.enabled = false;
        e_MiniGame.checkCount++;
    }

    public void ClueSelect_Clear()
    {
        clueButton.enabled = false;
        e_MiniGame.checkCount++;
        e_MiniGame.isClear[0] = true;
    }

    public void ClueSelect_Clear2()
    {
        clueButton.enabled = false;
        e_MiniGame.checkCount++;
        e_MiniGame.isClear[1] = true;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        tool.gameObject.SetActive(true);
        toolTip.ToolTipOn(clue.clueExplain);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tool.gameObject.SetActive(false);
    }
}
