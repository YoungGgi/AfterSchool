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

    [Header("��ȭ ���� UI")]
    [SerializeField]
    private GameObject backLogScrollView;              // ��α� ��ũ�Ѻ�
    [SerializeField]
    private GameObject pausePopup;                     // ����(Ÿ��) ��ư
    
    public bool isAuto;                                // ���� �ؽ�Ʈ ���

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

    public GameObject savePanel;

    public GameObject gameManager;


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

    public void Save()
    {
        savePanel.gameObject.SetActive(true);
    }

    public void SaveOff()
    {
        savePanel.gameObject.SetActive(false);
    }

}
