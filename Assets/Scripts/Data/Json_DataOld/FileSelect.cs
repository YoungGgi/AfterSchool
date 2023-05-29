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
    private GameObject creatPanel;
    [SerializeField]
    private TextMeshProUGUI[] slotText;
    [SerializeField]
    private TextMeshProUGUI newFileName;

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

    public void Slot(int number)    // 저장 슬롯 클릭 함수
    {
        DataManager.instance.nowSlot = number;

        if(saveFile[number])   // 저장된 데이터가 있을때 (저장된)씬으로 이동
        {
            DataManager.instance.Load();
            GoHome();  // 임시
        }
        else           // 저장된 데이터가 없을때 Create() 호출
        {
            Create();
        }
        
    }

    public void Create()          // 이름 팝업
    {
        creatPanel.gameObject.SetActive(true);
    }

    public void GoHome()          // 씬 이동 (씬 넘버를 따로 저장해서 그 씬으로 이동할 수 있을까?)
    {
        if(!saveFile[DataManager.instance.nowSlot])
        {
            DataManager.instance.saveData.name = newFileName.text;
            DataManager.instance.Save();
        }
        
        SceneManager.LoadScene(0);
    }
}
