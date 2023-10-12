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
    }

    public int isPrologue;
    public int isChapter1;
    public int isChapter2;
    public int isChapter3;

    public void PrologeClear(int num)
    {
        PlayerPrefs.SetInt("PrologueClear", num);
        PlayerPrefs.Save();

        int pro = PlayerPrefs.GetInt("PrologueClear");
        isPrologue = pro;
    }

    public void LoadPrologueClear()
    {
        if (!PlayerPrefs.HasKey("PrologueClear"))
            return;
        
        int pro = PlayerPrefs.GetInt("PrologueClear");
        isPrologue = pro;

    }

}
