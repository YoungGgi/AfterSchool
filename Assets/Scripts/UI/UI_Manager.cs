using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Manager : MonoBehaviour
{
    
    [Header("메인메뉴")]
    [SerializeField]
    private GameObject popUpObj;                       // �˾�â
    [SerializeField]
    private GameObject nameQuestionPop;                // �̸� ���� �˾� ����(�ӽ�)
    [SerializeField]
    private GameObject nameSelectObj;                  // �̸� ���� �˾�
    [SerializeField]
    private GameObject gameOptionObj;                  // ���� �κ� ��� ���(�ӽ�)
    [SerializeField]
    private GameObject chapterSelectObj;               // é�� ���� ���
    [SerializeField]
    private GameObject mainFadeMgn;

    [Header("추리 게임")]
    [SerializeField]
    private GameObject thinkGoNext;

    [Header("버튼 클릭 효과음")]
    [SerializeField]
    private AudioClip btnClickSFX;
    [SerializeField]
    private AudioClip btnSelectSFX;
    
    public Scene NowScene;
    public int SceneNum;

    public int saveSceneNum;

    private void Update()
    {
        NowScene = SceneManager.GetActiveScene(); 
        SceneNum = NowScene.buildIndex;
    }


    #region Button Click Next Scene
    public void GoMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    
    public void GameStart()
    {
        StartCoroutine(Scene1Loading());
    }

    IEnumerator Scene1Loading()
    {
        mainFadeMgn.SetActive(true);
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

    
    public void StartChapter2()
    {
        SceneManager.LoadScene(40);
    }

    
    public void StartChapter3()
    {
        SceneManager.LoadScene(53);
    }

    public void StartEpilogue()
    {
        SceneManager.LoadScene(77);
    }

    public void StartEndingCredit()
    {
        SceneManager.LoadScene(78);
    }
    
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
            case 9:
                BGM_Mgn.instance.BGM_Change(8);
                break;
            case 11:
                BGM_Mgn.instance.BGM_Change(6);
                break;
            case 35:
            case 36:
            case 37:
            case 38:
            case 62:
            case 63:
            case 64:
            case 65:
            case 66:
            case 71:
            case 72:
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
