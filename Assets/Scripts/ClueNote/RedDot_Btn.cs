using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RedDot_Btn : MonoBehaviour
{
    public int ID;
    public Image redDot;
    public TextMeshProUGUI clueText;

    public A_Dialogue dialogue;
    public RedDotMgn redDotMgn;

    private void Update()
    {
        if(clueText.text != "???" && dialogue.isClueUpdate && !redDotMgn.isCheck[ID])
        {
            redDot.gameObject.SetActive(true);
        }
        else
        {
            redDot.gameObject.SetActive(false);
        }
    }

    public void RedDotRemove(int i)
    {
        redDot.gameObject.SetActive(false);
        redDotMgn.RedDotOff();
        redDotMgn.isCheck[i] = true;

    }

}
