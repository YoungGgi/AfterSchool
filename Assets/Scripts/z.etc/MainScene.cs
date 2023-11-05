using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainScene : MonoBehaviour
{
    [SerializeField]
    private Button loadBtn;                              // 이어하기 버튼
    [SerializeField]
    private Button chapBtn;                              // 챕터선택 버튼
    [SerializeField]
    private TextMeshProUGUI chapterTitle;                // 챕터 타이틀 텍스트
    [SerializeField]
    private string prologueTitle;                        // 프롤로그 타이틀
    [SerializeField]
    private string chapter1Title;                        // 1챕터 타이틀
    [SerializeField]
    private string chapter2Title;                        // 2챕터 타이틀
    [SerializeField]
    private string chapter3Title;                        // 3챕터 타이틀
    [SerializeField]
    private string epilogueTitle;                        // 에필로그 타이틀

    public int mainBGM_Index;                            // BGM 인덱스

    private void Start()
    {
        
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

        
        BGM_Mgn.instance.BGM_Change(mainBGM_Index);

        if(PlayerPrefs.HasKey("PrologueClear") && SaveLoadMgn.instance.loadNum == 13)
        {
            SaveLoadMgn.instance.SaveData(14);
        }

        if (PlayerPrefs.HasKey("Chapter1Clear") && SaveLoadMgn.instance.loadNum == 39)
        {
            SaveLoadMgn.instance.SaveData(40);
        }

        if (PlayerPrefs.HasKey("Chapter2Clear") && SaveLoadMgn.instance.loadNum == 52)
        {
            SaveLoadMgn.instance.SaveData(53);
        }

        /*
        if (PlayerPrefs.HasKey("Chapter3Clear") && SaveLoadMgn.instance.loadNum == 76)
        {
            SaveLoadMgn.instance.SaveData(77);
        }
        */

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
        else if(indexnum == 77)
        {
            chapterTitle.text = epilogueTitle;
        }

        
    }

}
