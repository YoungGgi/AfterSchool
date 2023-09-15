using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BaseTest_01 : MonoBehaviour
{
    public Dialogue_Base dialogue;
    public Dialogue_Test01 dialogue_Test01;

    public bool isAuto;
    public float dealyCool;

    public GameObject autoText;

    public GameObject loadingTextGroup;

    //bool isLoading;

    public GameObject auto_Btn;
    public GameObject auto_true_Btn;

    public GameObject speed2_Btn;
    public GameObject speed2_true_Btn;

    public Scene NowScene;
    public int SceneNum;

    void OnEnable()
    {
        //dialogue_Test01.EnqueuDialogue(dialogue);
        //isLoading = true;
        StartCoroutine(LoadingAnim());

        NowScene = SceneManager.GetActiveScene();
        SceneNum = NowScene.buildIndex;
        //SaveLoadMgn.instance.SaveData(SceneNum);
        /*
        if (StroyDataMgn.instance.IsAutoLive)
        {
            autoText.gameObject.SetActive(true);

            auto_Btn.gameObject.SetActive(false);
            auto_true_Btn.gameObject.SetActive(true);
        }

        if (StroyDataMgn.instance.IsTwoSpeed)
        {
            speed2_Btn.gameObject.SetActive(false);
            speed2_true_Btn.gameObject.SetActive(true);
        }
        */
    }

    IEnumerator LoadingAnim()
    {
        yield return new WaitForSeconds(1.5f);

        loadingTextGroup.gameObject.SetActive(false);

        dialogue_Test01.EnqueuDialogue(dialogue);

        //isLoading = false;

    }

    /*
    void Update()
    {
        if (isLoading || StroyDataMgn.instance.IsSettingOn)
            return;
        else
        {
            if (StroyDataMgn.instance.IsAutoLive && dialogue_Test01.isTextComplete == true)
            {
                autoText.gameObject.SetActive(true);
                StartCoroutine(NextDelay());
                dialogue_Test01.DequeueDialogue();
            }

            if (StroyDataMgn.instance.IsAutoLive == false)
            {
                autoText.gameObject.SetActive(false);
            }

            if ((Input.GetKeyUp(KeyCode.Space)) || (Input.GetKeyUp(KeyCode.Return)))
            {
                StartCoroutine(NextDelay());
                dialogue_Test01.DequeueDialogue();
            }

            if (StroyDataMgn.instance.IsAutoStory && dialogue_Test01.isTextComplete == true)
            {
                StartCoroutine(NextDelay());
                dialogue_Test01.DequeueDialogue();
            }

        }
    }
    */
    IEnumerator NextDelay()
    {
        yield return new WaitForSeconds(dealyCool);
    }


    public void Next() => dialogue_Test01.DequeueDialogue();

}
