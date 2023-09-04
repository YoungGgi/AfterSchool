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
    private GameObject explainBox;                 // �ܼ� ������ ��ȭ����
    [SerializeField]
    private TextMeshProUGUI explainText;          // �ܼ� ���� ��ȭ���� �ؽ�Ʈ

    public ClueObject clue;                     // �ܼ�

    public MiniGameMgn miniManager;

    private void Start()
    {
        clueText.text = clue.clueName;
        explainText.text = clue.clueExplain;
    }

    // ��ư Ŭ���� �ش� �ܼ� ����â ���
    public void OnExplainBox()
    {
        
        explainBox.gameObject.SetActive(true);
        
    }

    // �ܼ� ����(���� ��ư Ŭ����)
    public void ClueSelect()
    {
        clueButton.enabled = false;
        explainBox.gameObject.SetActive(false);
        miniManager.checkCount++;
    }

    // �ܼ� ���(���� ��ư Ŭ����)
    public void ClueCancel()
    {
        explainBox.gameObject.SetActive(false);
    }

    // �ܼ� ����(����1 Ŭ�� ��)
    public void ClueSelect_Clear()
    {
        miniManager.isClear[0] = true;
        clueButton.enabled = false;
        explainBox.gameObject.SetActive(false);
        miniManager.checkCount++;
    }

    // �ܼ� ���(���� 1 Ŭ�� ��)
    public void ClueCancel_1()
    {
        miniManager.isClear[0] = false;
        explainBox.gameObject.SetActive(false);
    }

    // �ܼ� ����(����2 Ŭ�� ��)
    public void ClueSelect_Clear2()
    {
       
        miniManager.isClear[1] = true;
        clueButton.enabled = false;
        explainBox.gameObject.SetActive(false);
        miniManager.checkCount++;
    }

    // �ܼ� ���(����2 Ŭ�� ��)
    public void ClueCancel_2()
    {
        miniManager.isClear[1] = false;
        explainBox.gameObject.SetActive(false);
    }

}
