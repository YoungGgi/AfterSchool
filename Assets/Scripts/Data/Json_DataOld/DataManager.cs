using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class SaveData
{
    public string name;       // ���� ���� �̸�
    //public int ID;            // ��ȭ ID
    //public int sceneNum;      // ����� �� �ѹ�

}

public class DataManager : MonoBehaviour
{
    public static DataManager instance;

    public SaveData saveData = new SaveData();

    public string path;
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

        path = Application.persistentDataPath + "/save";
    }

    private void Start()
    {
        
    }

    public void Save()
    {
        string data = JsonUtility.ToJson(saveData);
        File.WriteAllText(path + nowSlot.ToString(), data);
    }

    public void Load()
    {
        string data = File.ReadAllText(path + nowSlot.ToString());
        saveData = JsonUtility.FromJson<SaveData>(data);
    }

    public void DataClear()
    {
        nowSlot = -1;
        saveData = new SaveData();
    }

}
