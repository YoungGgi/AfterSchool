using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Manager : MonoBehaviour
{
    
    [Header("메인 로비")]
    [SerializeField]
    private GameObject popUpObj;                       // 팝업창
    [SerializeField]
    private GameObject nameQuestionPop;                // 이름 설정 팝업 여부(임시)
    [SerializeField]
    private GameObject nameSelectObj;                  // 이름 설정 팝업
    [SerializeField]
    private GameObject gameOptionObj;                  // 메인 로비 기능 목록(임시)
    [SerializeField]
    private GameObject chapterSelectObj;               // 챕터 선택 목록

    [Header("미니 게임")]
    [SerializeField]
    private GameObject thinkGoNext;

    
    public Scene NowScene;
    public int SceneNum;

    public int saveSceneNum;

    private void Update()
    {
        NowScene = SceneManager.GetActiveScene(); // 매 프레임마다 현재 씬 확인하기
        SceneNum = NowScene.buildIndex;
    }


    #region Button Click Next Scene
    public void GoMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    
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
    }
    #endregion

    #region Dialogue Logic
    
    public void AutoOn()
    {
        StroyDataMgn.instance.isAutoLive = true;
    }

    public void AutoOff()
    {
        StroyDataMgn.instance.isAutoLive = false;
    }

    public void TwoSpeedOn()
    {
        StroyDataMgn.instance.isTwoSpeed = true;
    }

    public void TwoSpeedOff()
    {
        StroyDataMgn.instance.isTwoSpeed = false;
    }

    public void SettingOn()
    {
        StroyDataMgn.instance.isSettingOn = true;
    }

    public void SettingOff()
    {
        StroyDataMgn.instance.isSettingOn = false;
    }

    #endregion

    

    #region ThinkGame
    public void GoToDialogueScene()
    {
        SceneManager.LoadScene(SceneNum + 1);
    }

    #endregion

    #region SceneLoading
    public void LoadScene()
    {
        StartCoroutine(SceneLoading());
    }

    IEnumerator SceneLoading()
    {
        yield return null;

        SceneManager.LoadScene(SaveLoadMgn.instance.loadNum);
    }
    #endregion

   

}
