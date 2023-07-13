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

    
    public Scene NowScene;
    public int SceneNum;

    public int saveSceneNum;

    private void Start()
    {
        // StroyDataMgn�� isAutoLive�� true�� �� �� ��ȭ�� ���� ��ư Ȱ��ȭ�� ���·� �α�

        // 2��ӵ� ��������
       
    }

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

    public void namePopUpOn()
    {
        nameQuestionPop.gameObject.SetActive(true);
    }

    public void namePopUpOff()
    {
        nameQuestionPop.gameObject.SetActive(false);
    }

    public void nameSelectOn()
    {
        nameQuestionPop.gameObject.SetActive(false);
        nameSelectObj.gameObject.SetActive(true);
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
