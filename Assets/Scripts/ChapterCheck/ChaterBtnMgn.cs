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
    [SerializeField]
    private GameObject cutScene2_Btn;
    [SerializeField]
    private GameObject cutScene3_Btn;


    private void Update()
    {
        if(ChapterCheck.instance.prologue == 1)
        {
            chapter1Obj.gameObject.SetActive(true);
            cutScene1_Btn.SetActive(true);
        }

        if (ChapterCheck.instance.chapter1 == 1)
        {
            chapter2Obj.gameObject.SetActive(true);
            cutScene2_Btn.SetActive(true);
        }

        if (ChapterCheck.instance.chapter2 == 1)
        {
            chapter3Obj.gameObject.SetActive(true);
        }

        if (ChapterCheck.instance.chapter3 == 1)
        {
            cutScene3_Btn.SetActive(true);
        }

    }

}
