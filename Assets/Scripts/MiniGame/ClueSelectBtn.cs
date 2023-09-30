using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class ClueSelectBtn : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    private GameObject clueButton;                  // �ܼ� ��ư
    [SerializeField]
    private GameObject clueButton_Pressed;      // ���õ� �ܼ� ��ư
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
        // �ܼ� �̸��� ������ �ش� ������ �Ҵ�
        clueText.text = clue.clueName;
        explainText.text = clue.clueExplain;
    }

    // ���콺 �����Ͱ� �ش� ������Ʈ ���� ���� ��
    public void OnPointerEnter(PointerEventData eventData)
    {
        questionBox.gameObject.SetActive(false);
        explainBox.gameObject.SetActive(true);
    }

    // ���콺 �����Ͱ� �ش� ������Ʈ ���� ���� ��
    public void OnPointerExit(PointerEventData eventData)
    {
        questionBox.gameObject.SetActive(true);
        explainBox.gameObject.SetActive(false);
    }

    // �ܼ� ����(���� ��ư Ŭ����)
    public void ClueSelect()
    {
        // ȿ���� ���
        SFX_Mgn.instance.SFX_Source.PlayOneShot(btnClickSFX);

        // ���õ� ������ ������Ʈ�� Ȱ��ȭ�� �� miniManager�� checkCount�� 1 ����
        clueButton_Pressed.SetActive(true);
        explainBox.gameObject.SetActive(false);
        miniManager.checkCount++;

        // ���� Ŭ���� ���� ���� �ش� ������Ʈ ��Ȱ��ȭ
        clueButton.SetActive(false);
    }

    // �ܼ� ����(����1 Ŭ�� ��)
    public void ClueSelect_Clear()
    {
        // ȿ���� ���, miniManager�� isClear ����Ʈ Ȱ��ȭ
        SFX_Mgn.instance.SFX_Source.PlayOneShot(btnClickSFX);
        miniManager.isClear[0] = true;

        // ���õ� ������ ������Ʈ�� Ȱ��ȭ�� �� miniManager�� checkCount�� 1 ����
        clueButton_Pressed.SetActive(true);
        explainBox.gameObject.SetActive(false);
        miniManager.checkCount++;

        // ���� Ŭ���� ���� ���� �ش� ������Ʈ ��Ȱ��ȭ
        clueButton.SetActive(false);
    }

    // �ܼ� ����(����2 Ŭ�� ��)
    public void ClueSelect_Clear2()
    {
        // ȿ���� ���, miniManager�� isClear ����Ʈ Ȱ��ȭ
        SFX_Mgn.instance.SFX_Source.PlayOneShot(btnClickSFX);
        miniManager.isClear[1] = true;

        // ���õ� ������ ������Ʈ�� Ȱ��ȭ�� �� miniManager�� checkCount�� 1 ����
        clueButton_Pressed.SetActive(true);
        explainBox.gameObject.SetActive(false);
        miniManager.checkCount++;

        // ���� Ŭ���� ���� ���� �ش� ������Ʈ ��Ȱ��ȭ
        clueButton.SetActive(false);
    }

    
}
