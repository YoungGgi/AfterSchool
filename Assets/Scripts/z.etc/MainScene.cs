using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainScene : MonoBehaviour
{
    [SerializeField]
    private Button loadBtn;                              // �̾��ϱ� ��ư
    [SerializeField]
    private Button chapBtn;                              // é�� ���� ��ư
    [SerializeField]
    private TextMeshProUGUI chapterTitle;                // é�� Ÿ��Ʋ (Ÿ��Ʋ �ϼ� �� �̹����� ����)
    [SerializeField]
    private string prologueTitle;                        // ���ѷα� Ÿ��Ʋ ������ ����
    [SerializeField]
    private string chapter1Title;                        // 1é�� Ÿ��Ʋ ������ ����
    [SerializeField]
    private string chapter2Title;                        // 2é�� Ÿ��Ʋ ������ ����
    [SerializeField]
    private string chapter3Title;                        // 3é�� Ÿ��Ʋ ������ ����

    public int mainBGM_Index;                            // ����ȭ�鿡�� �����ų BGM �ε���

    private void Start()
    {
        // SaveLoadMgn �� ����� �ε����� 0�� ���(���� ���� ���� ��) �ε� ��ư, é�� ���� ��ư �Է� X
        loadBtn.enabled = SaveLoadMgn.instance.loadNum != 0;

        chapBtn.enabled = SaveLoadMgn.instance.loadNum != 0;

        /*
         �Ʒ��� �İ� ����
        if (SaveLoadMgn.instance.loadNum == 0)
        {
            loadBtn.enabled = false;
        }
        else
        {
            loadBtn.enabled = true;
        }
        */

        // ���� ���� �� BGM ���
        BGM_Mgn.instance.BGM_Change(mainBGM_Index);

    }

    private void Update()
    {
        int indexnum = SaveLoadMgn.instance.loadNum;

        if (indexnum >= 1 && indexnum <= 13)
        {
            chapterTitle.text = prologueTitle;
        }
        else if(indexnum >= 14 && indexnum <= 39)
        {
            chapterTitle.text = chapter1Title;
        }
        else if(indexnum >= 40 && indexnum <= 52)
        {
            chapterTitle.text = chapter2Title;
        }
        else if(indexnum >= 53 && indexnum <= 76)
        {
            chapterTitle.text = chapter3Title;
        }

        
    }

}
