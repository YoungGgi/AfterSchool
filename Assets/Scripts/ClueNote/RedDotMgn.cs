using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RedDotMgn : MonoBehaviour
{
    public Image redDot;
    public Image redDot_Tablet;

    

    public A_Dialogue dialogue;

    private void Update()
    {
        if(dialogue.isClueUpdate)
        {
            redDot.gameObject.SetActive(true);
            redDot_Tablet.gameObject.SetActive(true);

        }
    }

    public void RedDotOff()
    {
        redDot_Tablet.gameObject.SetActive(false);
        redDot.gameObject.SetActive(false);
        dialogue.isClueUpdate = false;
    }

}
