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

    [Header("버튼 효과음")]
    [SerializeField]
    private AudioClip btnClickSFX;
    [SerializeField]
    private AudioClip btnSelectSFX;
    
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
        //SFX_Mgn.instance.SFX_Source.PlayOneShot(btnSelectSFX);
        StartCoroutine(Scene1Loading());
    }

    IEnumerator Scene1Loading()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(1);
    }

    public void StartPrologue()
    {
        SceneManager.LoadScene(1);
    }

    
    public void StartChapter1()
    {
        SceneManager.LoadScene(14);
    }

    /*
    public void StartChapter2()
    {

    }

    public void StartChapter3()
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
        SFX_Mgn.instance.ButtonClick_Play();
        StroyDataMgn.instance.IsAutoLive = true;
    }

    public void AutoOff()
    {
        SFX_Mgn.instance.ButtonClick_Play();
        StroyDataMgn.instance.IsAutoLive = false;
    }

    public void TwoSpeedOn()
    {
        SFX_Mgn.instance.ButtonClick_Play();
        StroyDataMgn.instance.IsTwoSpeed = true;
    }

    public void TwoSpeedOff()
    {
        SFX_Mgn.instance.ButtonClick_Play();
        StroyDataMgn.instance.IsTwoSpeed = false;
    }

    public void SettingOn()
    {
        SFX_Mgn.instance.ButtonClick_Play();
        StroyDataMgn.instance.IsSettingOn = true;
    }

    public void SettingOff()
    {
        SFX_Mgn.instance.ButtonClick_Play();
        StroyDataMgn.instance.IsSettingOn = false;
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

        switch(SaveLoadMgn.instance.loadNum)
        {
            case 8:
                BGM_Mgn.instance.BGM_Change(5);
                break;
            case 9:
                BGM_Mgn.instance.BGM_Change(8);
                break;
            case 11:
                BGM_Mgn.instance.BGM_Change(6);
                break;
        }

        SceneManager.LoadScene(SaveLoadMgn.instance.loadNum);
    }
    #endregion

   public void SFX_On()
   {
        SFX_Mgn.instance.SFX_Source.PlayOneShot(btnClickSFX);
   }

}
