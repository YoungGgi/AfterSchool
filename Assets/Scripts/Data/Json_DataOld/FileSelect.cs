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

    bool[] saveFile = new bool[4];          // 저장 슬롯 수대로 변경 예정

    private void Start()
    {
        // 슬롯별로 데이터가 존재하는지 판단
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
                slotText[i].text = "비어있음";
            }
        }
        DataManager.instance.DataClear();

    }

    public void Slot(int number)    // 저장 슬롯 클릭 함수, 불러오기 시스템에 넣으면 될 듯. (세이브는?)
    {
        DataManager.instance.nowSlot = number;

        if(saveFile[number])   // 저장된 데이터가 있을때 (저장된)씬으로 이동
        {
            DataManager.instance.Load();
            GoHome();
        }
        
    }
    public void Save()          // 세이브 함수, 저장은 되는 거 같은데 텍스트를 바로 저장하게 할 수 있을까?
    {
        DataManager.instance.Save();
    }

    public void GoHome()          // 씬 이동 (씬 넘버를 따로 저장해서 그 씬으로 이동할 수 있을까?)
    {
        if(!saveFile[DataManager.instance.nowSlot])
        {
            DataManager.instance.Save();
        }

    }
}
