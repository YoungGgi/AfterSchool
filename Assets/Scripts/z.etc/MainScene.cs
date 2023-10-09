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
        else if(indexnum >= 40 && indexnum <= 52)
        {
            chapterTitle.text = chapter2Title;
        }

        
    }

}
