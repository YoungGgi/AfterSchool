using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveLoadMgn : MonoBehaviour
{
    public static SaveLoadMgn instance;

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

    public int loadNum;
    public Scene NowScene;
    public int SceneNum;

    private void Start()
    {
        LoadData();
    }

    public void SaveData(int sceneNum)
    {
        PlayerPrefs.SetInt("nowScene", sceneNum);
        PlayerPrefs.Save();

        int num = PlayerPrefs.GetInt("nowScene");
        loadNum = num;

    }

    public void LoadData()
    {
        if (!PlayerPrefs.HasKey("nowScene"))
            return;
        
        int num = PlayerPrefs.GetInt("nowScene");
        loadNum = num;

    }

}
