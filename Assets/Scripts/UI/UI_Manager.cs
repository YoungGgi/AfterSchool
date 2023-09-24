using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Manager : MonoBehaviour
{
    
    [Header("���� �κ�")]
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

    [Header("�̴� ����")]
    [SerializeField]
    private GameObject thinkGoNext;

    [Header("��ư ȿ����")]
    [SerializeField]
    private AudioClip btnClickSFX;
    [SerializeField]
    private AudioClip btnSelectSFX;
    
    public Scene NowScene;
    public int SceneNum;

    public int saveSceneNum;

    private void Update()
    {
        NowScene = SceneManager.GetActiveScene(); // �� �����Ӹ��� ���� �� Ȯ���ϱ�
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

    */

    public void GameExit()
    {
        Application.Quit();
    }
    #endregion

    #region Dialogue Logic
    
    public void AutoOn()
    {
        StroyDataMgn.instance.IsAutoLive = true;
    }

    public void AutoOff()
    {
        StroyDataMgn.instance.IsAutoLive = false;
    }

    public void TwoSpeedOn()
    {
        StroyDataMgn.instance.IsTwoSpeed = true;
    }

    public void TwoSpeedOff()
    {
        StroyDataMgn.instance.IsTwoSpeed = false;
    }

    public void SettingOn()
    {
        StroyDataMgn.instance.IsSettingOn = true;
    }

    public void SettingOff()
    {
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

        SceneManager.LoadScene(SaveLoadMgn.instance.loadNum);
    }
    #endregion

   public void SFX_On()
   {
        SFX_Mgn.instance.SFX_Source.PlayOneShot(btnClickSFX);
   }

    public void SelectSFX()
    {
        SFX_Mgn.instance.SFX_Source.PlayOneShot(btnSelectSFX);
    }

}
