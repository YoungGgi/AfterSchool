using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerName : MonoBehaviour
{
    public static PlayerName instance;

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

    public string player;

    private void Start()
    {
        LoadName();
    }

    public void SaveName(string name)
    {
        PlayerPrefs.SetString("Player", name);
        PlayerPrefs.Save();

        player = PlayerPrefs.GetString("Player");
    }

    public void LoadName()
    {
        if (!PlayerPrefs.HasKey("Player"))
            return;

        string name = PlayerPrefs.GetString("Player");
        player = name;
    }
}
