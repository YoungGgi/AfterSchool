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
                clueBtnName[i].text = "�ܼ� ����";
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
            clueNameTxt.text = "�ܼ� ����";
            clueExplainTxt.text = "ȹ������ ���� �ܼ��Դϴ�.";
        }
       
    }
}
