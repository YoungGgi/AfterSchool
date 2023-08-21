using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ClueSelectBtn : MonoBehaviour
{
    [SerializeField]
    private Button clueButton;                  // �ܼ� ��ư
    [SerializeField]
    private TextMeshProUGUI clueText;           // ��ư�� �ִ� �ܼ� ����
    [SerializeField]
    private GameObject toolTip;                 // �ܼ� ����

    public ClueObject clue;                     // �ܼ�

    public MiniGameMgn miniManager;

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

}
