using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChapterPopUp : MonoBehaviour
{
    [SerializeField] private GameObject chapter1OpenPopup;

    [SerializeField] private GameObject chapter2OpenPopup;

    [SerializeField] private GameObject chapter3OpenPopup;


    void Start()
    {
        if(ChapterCheck.instance.Prologue == 1 && !ChapterCheck.instance.isPrologueConfirm)
        {
            SaveLoadMgn.instance.SaveData(14);
            chapter1OpenPopup.gameObject.SetActive(true);
        }

        if(ChapterCheck.instance.Chapter1 == 1 && !ChapterCheck.instance.isChapter1Confirm)
        {
            CheckPrologue();
            SaveLoadMgn.instance.SaveData(40);
            chapter2OpenPopup.gameObject.SetActive(true);
        }

        if(ChapterCheck.instance.Chapter2 == 1 && !ChapterCheck.instance.isChapter2Confirm)
        {
            CheckPrologue();
            CheckChapter1();
            SaveLoadMgn.instance.SaveData(53);
            chapter3OpenPopup.gameObject.SetActive(true);
        }

    }

    public void CheckPrologue()
    {
        ChapterCheck.instance.isPrologueConfirm = true;
    }

    public void CheckChapter1()
    {
        ChapterCheck.instance.isChapter1Confirm = true;
    }

    public void CheckChapter2()
    {
        ChapterCheck.instance.isChapter2Confirm = true;
    }

}
