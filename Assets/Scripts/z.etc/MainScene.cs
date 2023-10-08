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

        /*
        // SaveLoadMgn �� ����� �� �ε����� ���� é�� Ÿ��Ʋ �ؽ�Ʈ ���
        switch(SaveLoadMgn.instance.loadNum)
        {
            indexnum >= 1 || indexnum <= 13

        case 1:
            case 2:
            case 3:
            case 4:
            case 5:
            case 6:
            case 7:
            case 8:
            case 9:
            case 10:
            case 11:
            case 12:
            case 13:
                chapterTitle.text = prologueTitle;
                break;
            case 14:
            case 15:
            case 16:
            case 17:
            case 18:
            case 19:
            case 20:
            case 21:
            case 22:
            case 23:
            case 24:
            case 25:
            case 26:
            case 27:
            case 28:
            case 29:
            case 30:
            case 31:
            case 32:
            case 33:
            case 34:
            case 35:
            case 36:
            case 37:
            case 38:
            case 39:
                chapterTitle.text = chapter1Title;
                break;
        }
        */
    }

}
