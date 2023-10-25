using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChapterCheck : MonoBehaviour
{
    #region Singleton
    public static ChapterCheck instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    #endregion

    void Start()
    {
        LoadPrologueClear();
        LoadChapter1Clear();
        LoadChapter2Clear();
        LoadChapter3Clear();
    }

    public int prologue;
    public int chapter1;
    public int chapter2;
    public int chapter3;
    public int epilogue;

    public bool isPrologueConfirm;
    public bool isChapter1Confirm;
    public bool isChapter2Confirm;
    public bool isChapter3Confirm;
    public bool isEpilogueConfirm;

    #region Prologue
    public void PrologeClear(int num)
    {
        PlayerPrefs.SetInt("PrologueClear", num);
        PlayerPrefs.Save();

        int pro = PlayerPrefs.GetInt("PrologueClear");
        prologue = pro;
    }

    public void LoadPrologueClear()
    {
        if (!PlayerPrefs.HasKey("PrologueClear"))
            return;
        
        int pro = PlayerPrefs.GetInt("PrologueClear");
        prologue = pro;

    }

    public void PrologueCheck()
    {
        PlayerPrefs.SetInt("PrologueCheck", 1);
    }

    #endregion

    #region  Chapter1
    public void Chapter1Clear(int num)
    {
        PlayerPrefs.SetInt("Chapter1Clear", num);
        PlayerPrefs.Save();

        int cha1 = PlayerPrefs.GetInt("Chapter1Clear");
        chapter1 = cha1;
        
    }

    public void LoadChapter1Clear()
    {
        if(!PlayerPrefs.HasKey("Chapter1Clear"))
           return;

        int cha1 = PlayerPrefs.GetInt("Chapter1Clear");
        chapter1 = cha1;
    }

    public void Chapter1Check()
    {
        PlayerPrefs.SetInt("Chapter1Check", 1);
    }

    #endregion

    #region Chapter2
    public void Chapter2Clear(int num)
    {
        PlayerPrefs.SetInt("Chapter2Clear", num);
        PlayerPrefs.Save();

        int cha2 = PlayerPrefs.GetInt("Chapter2Clear");
        chapter2 = cha2;
    }

    public void LoadChapter2Clear()
    {
        if(!PlayerPrefs.HasKey("Chapter2Clear"))
           return;

        int cha2 = PlayerPrefs.GetInt("Chapter2Clear");
        chapter2 = cha2;
    }

    public void Chapter2Check()
    {
        PlayerPrefs.SetInt("Chapter2Check", 1);
    }

    #endregion

    #region  Chapter3
    public void Chapter3Clear(int num)
    {
        PlayerPrefs.SetInt("Chapter3Clear", num);
        PlayerPrefs.Save();

        int cha3 = PlayerPrefs.GetInt("Chapter3Clear");
        chapter3 = cha3;
    }

    public void LoadChapter3Clear()
    {
        if (!PlayerPrefs.HasKey("Chapter3Clear"))
            return;

        int cha3 = PlayerPrefs.GetInt("Chapter3Clear");
        chapter3 = cha3;
    }

    public void Chapter3Check()
    {
        PlayerPrefs.SetInt("Chapter3Check", 1);
    }
    #endregion

    #region Epilogue
    public void EpilogueClear(int num)
    {
        PlayerPrefs.SetInt("EpilogueClear", num);
        PlayerPrefs.Save();

        int epil = PlayerPrefs.GetInt("EpilogueClear");
        epilogue = epil;
    }

    public void LoadEpilogueClear()
    {
        if (!PlayerPrefs.HasKey("EpilogueClear"))
            return;

        int epil = PlayerPrefs.GetInt("EpilogueClear");
        epilogue = epil;
    }

    public void EpilogueCheck()
    {
        PlayerPrefs.SetInt("EpilogueCheck", 1);
    }

#endregion
}
