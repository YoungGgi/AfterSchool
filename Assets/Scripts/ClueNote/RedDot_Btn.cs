using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RedDot_Btn : MonoBehaviour
{
    public int ID;
    public Image redDot;

    public ClueManager clue;

    private void Update()
    {
        
    }

    public void RedDotRemove()
    {
        redDot.gameObject.SetActive(false);
    }

}
