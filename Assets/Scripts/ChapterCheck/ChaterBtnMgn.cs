using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaterBtnMgn : MonoBehaviour
{
    [SerializeField]
    private GameObject chapter1Obj;
    [SerializeField]
    private GameObject chapter2Obj;
    [SerializeField]
    private GameObject chapter3Obj;

    [SerializeField]
    private GameObject cutScene1_Btn;


    private void Update()
    {
        if(ChapterCheck.instance.Prologue == 1)
        {
            chapter1Obj.gameObject.SetActive(true);
            cutScene1_Btn.SetActive(true);
        }

        if (ChapterCheck.instance.Chapter1 == 1)
        {
            chapter2Obj.gameObject.SetActive(true);
        }

        if (ChapterCheck.instance.Chapter2 == 1)
        {
            chapter3Obj.gameObject.SetActive(true);
        }

    }

}
