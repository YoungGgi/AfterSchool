using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RedDotMgn : MonoBehaviour
{
    public Image redDot;
    public Image redDot_Tablet;

    public Image[] redDot_Btn;
    public TextMeshProUGUI[] clueText;

    public bool[] isCheck = new bool[5];

    public A_Dialogue dialogue;

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
                if(clueText[i].text != "???" && dialogue.isClueUpdate)
                {
                    redDot_Btn[i].gameObject.SetActive(true);
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
        redDot.gameObject.SetActive(false);
        RedDotOff();
        isCheck[i] = true;

    }

}
