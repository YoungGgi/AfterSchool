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
    private Button chapBtn;                              // 챕터 선택 버튼
    [SerializeField]
    private TextMeshProUGUI chapterTitle;                // 챕터 타이틀 (타이틀 완성 시 이미지로 변경)
    [SerializeField]
    private string prologueTitle;                        // 프롤로그 타이틀 문자형 변수
    [SerializeField]
    private string chapter1Title;                        // 1챕터 타이틀 문자형 변수
    [SerializeField]
    private string chapter2Title;                        // 2챕터 타이틀 문자형 변수
    [SerializeField]
    private string chapter3Title;                        // 3챕터 타이틀 문자형 변수

    public int mainBGM_Index;                            // 메인화면에서 재생시킬 BGM 인덱스

    private void Start()
    {
        // SaveLoadMgn 에 저장된 인덱스가 0인 경우(게임 최초 실행 시) 로딩 버튼, 챕터 선택 버튼 입력 X
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

        // 게임 시작 시 BGM 재생
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
        // SaveLoadMgn 에 저장된 씬 인덱스에 따라 챕터 타이틀 텍스트 출력
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
