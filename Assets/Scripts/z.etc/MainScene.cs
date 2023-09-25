using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainScene : MonoBehaviour
{
    [SerializeField]
    private Button loadBtn;
    [SerializeField]
    private Button chapBtn;
    [SerializeField]
    private TextMeshProUGUI chapterTitle;
    [SerializeField]
    private string prologueTitle;
    [SerializeField]
    private string chapter1Title;
    [SerializeField]
    private string chapter2Title;
    [SerializeField]
    private string chapter3Title;

    public int mainBGM_Index;

    private void Start()
    {
        loadBtn.enabled = SaveLoadMgn.instance.loadNum != 0;

        chapBtn.enabled = SaveLoadMgn.instance.loadNum != 0;

        /*
         아래의 식과 같음
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

    }

    private void Update()
    {
        switch(SaveLoadMgn.instance.loadNum)
        {
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
                chapterTitle.text = chapter1Title;
                break;
        }
    }

}
