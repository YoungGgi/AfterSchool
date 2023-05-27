using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.IO;

public class FileSelect : MonoBehaviour
{
    [SerializeField]
    private GameObject creatPanel;
    [SerializeField]
    private TextMeshProUGUI[] slotText;
    [SerializeField]
    private TextMeshProUGUI fileName;


    public void Slot(int number)
    {
        DataManager.instance.nowSlot = number;

        Create();       // 저장된 데이터가 없을때 Create() 호출
        // 저장된 데이터가 있을때 현재씬으로 이동
        DataManager.instance.Load();
        GoHome();  // 임시
    }

    public void Create()
    {
        creatPanel.gameObject.SetActive(true);
    }

    public void GoHome()
    {
        SceneManager.LoadScene(0);
    }
}
