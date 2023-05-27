using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class SaveData
{
    public string name;
}

public class DataManager : MonoBehaviour
{
    public static DataManager instance;

    public SaveData saveData = new SaveData();

    string path;
    string fileName = "save";
    public int nowSlot;

    private void Awake()
    {
        #region SingleTone
        if (instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
        #endregion

        path = Application.persistentDataPath + '/';
    }

    private void Start()
    {
        
    }

    public void Save()
    {
        string data = JsonUtility.ToJson(saveData);
        File.WriteAllText(path + fileName + nowSlot.ToString(), data);
    }

    public void Load()
    {
        string data = File.ReadAllText(path + fileName + nowSlot.ToString());
        saveData = JsonUtility.FromJson<SaveData>(data);
    }

}
