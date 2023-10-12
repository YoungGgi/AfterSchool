using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChapterData : MonoBehaviour
{
    public static ChapterData instance;

    private void Awake()
    {
        #region SingleTone
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
        #endregion


    }

    public int isPrologue;
    public int isChapter1;
    public int isChapter2;
    public int isChapter3;

    public void PrologeClear(int num)
    {
        PlayerPrefs.SetInt("PrologueClear", num);
        PlayerPrefs.Save();

        int pro = PlayerPrefs.GetInt("PrologueClear", num);
        pro = isPrologue;
    } 
    



}
