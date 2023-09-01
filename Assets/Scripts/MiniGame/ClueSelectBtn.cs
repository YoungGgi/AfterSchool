using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ClueSelectBtn : MonoBehaviour
{
    [SerializeField]
    private Button clueButton;                  // 단서 버튼
    [SerializeField]
    private TextMeshProUGUI clueText;           // 버튼에 있는 단서 제목
    [SerializeField]
    private GameObject explainBox;                 // 단서 설명할 대화상자
    [SerializeField]
    private TextMeshProUGUI explainText;          // 단서 설명 대화상자 텍스트

    public ClueObject clue;                     // 단서

    public MiniGameMgn miniManager;

    private void Start()
    {
        clueText.text = clue.clueName;
    }

    public void ClueSelect()
    {
        clueButton.enabled = false;
        miniManager.checkCount++;
        explainBox.gameObject.SetActive(true);
        explainText.text = clue.clueExplain;
    }

    public void ClueSelect_Clear()
    {
        clueButton.enabled = false;
        miniManager.checkCount++;
        miniManager.isClear[0] = true;
        explainBox.gameObject.SetActive(true);
        explainText.text = clue.clueExplain;
    }

    public void ClueSelect_Clear2()
    {
        clueButton.enabled = false;
        miniManager.checkCount++;
        miniManager.isClear[1] = true;
        explainBox.gameObject.SetActive(true);
        explainText.text = clue.clueExplain;
    }

}
