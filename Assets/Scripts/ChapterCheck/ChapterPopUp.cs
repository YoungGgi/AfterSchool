using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChapterPopUp : MonoBehaviour
{
    [SerializeField] 
    private GameObject chapter1OpenPopup;

    [SerializeField] 
    private GameObject chapter2OpenPopup;

    [SerializeField] 
    private GameObject chapter3OpenPopup;


    void Start()
    {
        if(ChapterCheck.instance.Prologue == 1 && !PlayerPrefs.HasKey("PrologueCheck"))
        {
            chapter1OpenPopup.gameObject.SetActive(true);
        }

        if(ChapterCheck.instance.Chapter1 == 1 && !PlayerPrefs.HasKey("Chapter1Check"))
        {
            chapter2OpenPopup.gameObject.SetActive(true);
        }

        if(ChapterCheck.instance.Chapter2 == 1 && !PlayerPrefs.HasKey("Chapter2Check"))
        {
            chapter3OpenPopup.gameObject.SetActive(true);
        }

    }

    public void CheckPrologue()
    {
        ChapterCheck.instance.PrologueCheck();
    }

    public void CheckChapter1()
    {
        ChapterCheck.instance.Chapter1Check();
    }

    public void CheckChapter2()
    {
        ChapterCheck.instance.Chapter2Check();
    }

}
