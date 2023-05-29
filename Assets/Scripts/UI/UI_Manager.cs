using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Manager : MonoBehaviour
{
    #region Singleton
    public static UI_Manager instance;
    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("fix this " + gameObject.name);
        }
        else
            instance = this;
    }
    #endregion

    [SerializeField]
    private GameObject backLogScrollView;              // 백로그 스크롤뷰

   [SerializeField]
    private GameObject pausePopup;                     // 설정(타블렛) 버튼
    

    public bool isAuto;                                // 오토 텍스트 기능

    [SerializeField]
    private GameObject popUpObj;                       // 팝업창
    [SerializeField]
    private GameObject gameOptionObj;                  // 메인 로비 기능 목록(임시)
    [SerializeField]
    private GameObject chapterSelectObj;               // 챕터 선택 목록

    public GameObject savePanel;

    public GameObject gameManager;


    #region Button Click Next Scene
    public void GameStart()
    {
        SceneManager.LoadScene(1);
    }

    public void StartPrologue()
    {
        SceneManager.LoadScene(1);
    }

    /*
    public void StartChapter1()
    {

    }


    public void StartChapter2()
    {

    }

    public void StartChapter3()
    {

    }

    public void StartChapter4()
    {

    }

    */

    public void GameExit()
    {
        Application.Quit();
        UnityEditor.EditorApplication.ExitPlaymode();
    }

    #endregion

    #region Dialogue Logic
    public void BackLogOn()
    {
        backLogScrollView.gameObject.SetActive(true); 
    }

    public void BackLogOff()
    {
        backLogScrollView.gameObject.SetActive(false);
    }

    public void Pause()
    {
        pausePopup.gameObject.SetActive(true);
    }

    public void PauseOut()
    {
        pausePopup.gameObject.SetActive(false);
    }

    public void AutoOn()
    {
        isAuto = true;
    }

    public void AutoOff()
    {
        isAuto = false;
    }
    #endregion

    #region GameOption
    public void ChapterListOn()
    {
        gameOptionObj.gameObject.SetActive(false);
        chapterSelectObj.gameObject.SetActive(true);
    }

    public void ChapterListOff()
    {
        chapterSelectObj.gameObject.SetActive(false);
        gameOptionObj.gameObject.SetActive(true);
    }

    public void popUpOn()
    {
        popUpObj.gameObject.SetActive(true);
    }

    public void popUpOff()
    {
        popUpObj.gameObject.SetActive(false);
    }


    #endregion

    public void Save()
    {
        savePanel.gameObject.SetActive(true);
    }

    public void SaveOff()
    {
        savePanel.gameObject.SetActive(false);
    }

}
