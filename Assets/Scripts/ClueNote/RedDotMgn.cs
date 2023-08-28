using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RedDotMgn : MonoBehaviour
{
    public Image redDot;
    public Image redDot_Tablet;

    public GameObject[] redDot_Btn;
    public TextMeshProUGUI[] clueText;

    

    public int setActiveFalseCount;

    public A_Dialogue dialogue;
    public ClueManager clue;

    private void Start()
    {
        for (int i = 0; i < clueText.Length; i++)
        {
            for (int j = 0; j < redDot_Btn.Length; j++)
            {
                if (clueText[i].text != "???" && !ClueCheckMgn.instance.isCheck[i])
                {
                    redDot.gameObject.SetActive(true);
                    redDot_Tablet.gameObject.SetActive(true);
                    redDot_Btn[i].gameObject.SetActive(true);
                    break;
                }
            }
        }
    }


    private void Update()
    {
        if(dialogue.isClueUpdate)
        {
            redDot.gameObject.SetActive(true);
            redDot_Tablet.gameObject.SetActive(true);

        }

        for(int i = 0; i < clueText.Length; i++)
        {
            for(int j = 0; j < redDot_Btn.Length; j++)
            {
                if(clueText[i].text != "???" && dialogue.isClueUpdate && !ClueCheckMgn.instance.isCheck[i])
                {
                    redDot_Btn[i].gameObject.SetActive(true);
                    break;
                }
            }
        }

    }

    public void RedDotOff()
    {
        redDot_Tablet.gameObject.SetActive(false);
        redDot.gameObject.SetActive(false);
        dialogue.isClueUpdate = false;
    }

    public void RedDotRemove(int i)
    {
        redDot_Btn[i].gameObject.SetActive(false);
        ClueCheckMgn.instance.isCheck[i] = true;

        if(setActiveFalseCount == clue.clueAddCount)
        {
            RedDotOff();
        }
        else
        {
            setActiveFalseCount++;

            if (setActiveFalseCount == clue.clueAddCount)
            {
                RedDotOff();
            }
        }

    }

}
