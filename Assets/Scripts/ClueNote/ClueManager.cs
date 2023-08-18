using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ClueManager : MonoBehaviour
{
    //public ClueObject[] clues;
    public List<ClueObject> clues;

    public TextMeshProUGUI[] clueBtnName;
    public TextMeshProUGUI clueNameTxt;
    public TextMeshProUGUI clueExplainTxt;

    public Button[] clueButtons;

    public Image[] redDot_ClueBtn;
    bool isCheck;

    public RedDotMgn redDotMgn;

    private void Update()
    {
        for(int j = 0; j < clueButtons.Length; j++)
        {
            clueButtons[j].enabled = false;
            
            for (int i = 0; i < clues.Count; i++)
            {

                if (clues[i] != null)
                {
                    redDot_ClueBtn[i].gameObject.SetActive(true);
                    clueBtnName[i].text = clues[i].clueBtnName;
                    clueButtons[i].enabled = true;

                }
                else
                {
                    clueBtnName[i].text = "단서 없음";
                }

                if(isCheck)
                {
                    redDot_ClueBtn[i].gameObject.SetActive(false);
                    isCheck = false;
                }

            }

        }
    }

    /*
    private void LateUpdate()
    {
        for(int j = 0; j < redDot_ClueBtn.Length; j++)
        {
            for(int i = 0; i < clues.Count; i++)
            {
                if(clues[i] != null)
                {

                }
            }
        }
    }
    */

    public void ClueOn(int i)
    {
        if(clues[i] != null)
        {
            isCheck = true;
            clueNameTxt.text = clues[i].clueName;
            clueExplainTxt.text = clues[i].clueExplain;
        }
        
        if(!clues.Contains(clues[i]))
        {
            clueNameTxt.text = "단서 없음";
            clueExplainTxt.text = "획득하지 못한 단서입니다.";
        }
        
    }

}
