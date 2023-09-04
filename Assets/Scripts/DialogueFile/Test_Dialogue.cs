using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class Test_Dialogue : MonoBehaviour
{

    public Dialogue_Base dialogue;
    public A_Dialogue a_Dialogue;

    public bool isAuto;
    public float dealyCool;

    public GameObject autoText;

    public GameObject loadingTextGroup;

    bool isLoading;

    public GameObject auto_Btn;
    public GameObject auto_true_Btn;

    public GameObject speed2_Btn;
    public GameObject speed2_true_Btn;

    public Scene NowScene;
    public int SceneNum;

    void OnEnable()
    {
        //a_Dialogue.EnqueuDialogue(dialogue);
        isLoading = true;
        StartCoroutine(LoadingAnim());

        NowScene = SceneManager.GetActiveScene();
        SceneNum = NowScene.buildIndex;
        SaveLoadMgn.instance.SaveData(SceneNum);

        if (StroyDataMgn.instance.isAutoLive)
        {
            autoText.gameObject.SetActive(true);

            auto_Btn.gameObject.SetActive(false);
            auto_true_Btn.gameObject.SetActive(true);
        }

        if (StroyDataMgn.instance.isTwoSpeed)
        {
            speed2_Btn.gameObject.SetActive(false);
            speed2_true_Btn.gameObject.SetActive(true);
        }

    }

    IEnumerator LoadingAnim()
    {
        yield return new WaitForSeconds(1.5f);

        loadingTextGroup.gameObject.SetActive(false);

        a_Dialogue.EnqueuDialogue(dialogue);

        isLoading = false;

    }


    void Update()
    {
        if (isLoading || StroyDataMgn.instance.isSettingOn)
            return;
        else
        {
            if (StroyDataMgn.instance.isAutoLive && a_Dialogue.isTextComplete == true)
            {
                autoText.gameObject.SetActive(true);
                StartCoroutine(NextDelay());
                a_Dialogue.DequeueDialogue();
            }

            if(StroyDataMgn.instance.isAutoLive == false)
            {
                autoText.gameObject.SetActive(false);
            }

            if ((Input.GetKeyUp(KeyCode.Space)) || (Input.GetKeyUp(KeyCode.Return)))
            {
                StartCoroutine(NextDelay());
                a_Dialogue.DequeueDialogue();
            }

            if(StroyDataMgn.instance.isAutoStory && a_Dialogue.isTextComplete == true)
            {
                StartCoroutine(NextDelay());
                a_Dialogue.DequeueDialogue();
            }

        }
    }

    IEnumerator NextDelay()
    {
        yield return new WaitForSeconds(dealyCool);
    }


    public void Next() => a_Dialogue.DequeueDialogue();


}
