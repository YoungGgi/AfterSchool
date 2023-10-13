using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChapterPopUp : MonoBehaviour
{
    [SerializeField] private GameObject chapter1OpenPopup;

    [SerializeField] private GameObject chapter2OpenPopup;


    void Start()
    {
        if(ChapterCheck.instance.Prologue == 1 && !ChapterCheck.instance.isPrologueConfirm)
        {
            chapter1OpenPopup.gameObject.SetActive(true);
        }

        if(ChapterCheck.instance.Chapter1 == 1 && !ChapterCheck.instance.isChapter1Confirm)
        {
            CheckPrologue();
            chapter2OpenPopup.gameObject.SetActive(true);
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

}
