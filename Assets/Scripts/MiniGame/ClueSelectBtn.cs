using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class ClueSelectBtn : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
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

    public AudioClip btnClickSFX;             // ��ư Ŭ�� ȿ����

    public ClueObject clue;                     // �ܼ�

    public MiniGameMgn miniManager;

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

    // �ܼ� ����(���� ��ư Ŭ����)
    public void ClueSelect()
    {
        SFX_Mgn.instance.SFX_Source.PlayOneShot(btnClickSFX);
        clueButton.enabled = false;
        explainBox.gameObject.SetActive(false);
        miniManager.checkCount++;
    }

    // �ܼ� ����(����1 Ŭ�� ��)
    public void ClueSelect_Clear()
    {
        SFX_Mgn.instance.SFX_Source.PlayOneShot(btnClickSFX);
        miniManager.isClear[0] = true;
        clueButton.enabled = false;
        explainBox.gameObject.SetActive(false);
        miniManager.checkCount++;
    }

    // �ܼ� ����(����2 Ŭ�� ��)
    public void ClueSelect_Clear2()
    {
        SFX_Mgn.instance.SFX_Source.PlayOneShot(btnClickSFX);
        miniManager.isClear[1] = true;
        clueButton.enabled = false;
        explainBox.gameObject.SetActive(false);
        miniManager.checkCount++;
    }

    
}
