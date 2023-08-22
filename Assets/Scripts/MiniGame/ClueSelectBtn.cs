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
    private GameObject tool;                 // 단서 툴팁

    public ClueObject clue;                     // 단서

    public MiniGameMgn miniManager;
    public ToolTip toolTip;

    private void Start()
    {
        clueText.text = clue.clueName;
    }

    public void ClueSelect()
    {
        clueButton.enabled = false;
        miniManager.checkCount++;
    }

    public void ClueSelect_Clear()
    {
        clueButton.enabled = false;
        miniManager.checkCount++;
        miniManager.isClear[0] = true;
    }

    public void ClueSelect_Clear2()
    {
        clueButton.enabled = false;
        miniManager.checkCount++;
        miniManager.isClear[1] = true;
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
