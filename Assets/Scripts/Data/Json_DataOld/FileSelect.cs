using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.IO;

public class FileSelect : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI[] slotText;

    bool[] saveFile = new bool[4];          // ���� ���� ����� ���� ����

    private void Start()
    {
        // ���Ժ��� �����Ͱ� �����ϴ��� �Ǵ�
        for(int i = 0; i < 4; i++)
        {
            if (File.Exists(DataManager.instance.path + $"{i}"))
            {
                saveFile[i] = true;
                DataManager.instance.nowSlot = i;
                DataManager.instance.Load();
                slotText[i].text = DataManager.instance.saveData.name;
              
            }
            else
            {
                slotText[i].text = "�������";
            }
        }
        DataManager.instance.DataClear();

    }

    public void Slot(int number)    // ���� ���� Ŭ�� �Լ�, �ҷ����� �ý��ۿ� ������ �� ��. (���̺��?)
    {
        DataManager.instance.nowSlot = number;

        if(saveFile[number])   // ����� �����Ͱ� ������ (�����)������ �̵�
        {
            DataManager.instance.Load();
            GoHome();
        }
        
    }
    public void Save()          // ���̺� �Լ�, ������ �Ǵ� �� ������ �ؽ�Ʈ�� �ٷ� �����ϰ� �� �� ������?
    {
        DataManager.instance.Save();
    }

    public void GoHome()          // �� �̵� (�� �ѹ��� ���� �����ؼ� �� ������ �̵��� �� ������?)
    {
        if(!saveFile[DataManager.instance.nowSlot])
        {
            DataManager.instance.Save();
        }

    }
}
