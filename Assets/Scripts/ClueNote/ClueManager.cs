using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClueManager : MonoBehaviour
{
    public ClueObject[] clues;

    public TextMeshProUGUI[] clueBtnName;
    public TextMeshProUGUI clueNameTxt;
    public TextMeshProUGUI clueExplainTxt;

    private void Start()
    {
        for(int i = 0; i < clues.Length; i++)
        {
            if(clues[i] != null)
            {
                clueBtnName[i].text = clues[i].clueBtnName;
            }
            else
            {
                clueBtnName[i].text = "단서 없음";
            }
            
        }
    }

    public void ClueOn(int i)
    {
        if(clues[i] != null)
        {
            clueNameTxt.text = clues[i].clueName;
            clueExplainTxt.text = clues[i].clueExplain;
        }
        else
        {
            clueNameTxt.text = "단서 없음";
            clueExplainTxt.text = "획득하지 못한 단서입니다.";
        }
       
    }
}
