using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChapterPopUp : MonoBehaviour
{
    [SerializeField] private GameObject chapter1_Open_Popup;

    [SerializeField] private int prologueCheck;


    void Start()
    {
        if(ChapterCheck.instance.isPrologue == 1 && prologueCheck == 0)
        {
            chapter1_Open_Popup.gameObject.SetActive(true);
        }
    }

    public void CheckPrologue()
    {
        prologueCheck = 1;
    }

}
