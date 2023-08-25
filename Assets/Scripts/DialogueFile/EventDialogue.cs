using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventDialogue : MonoBehaviour
{
    public Dialogue_Base dialogue;
    public Dialogue_Event dialogue_Event;

    public bool isAuto;
    public float dealyCool;

    public GameObject autoText;

    public GameObject loadingTextGroup;

    bool isLoading;

    public Scene NowScene;
    public int SceneNum;

    void Start()
    {
        //dialogue_Event.EnqueuDialogue(dialogue);
        isLoading = true;
        StartCoroutine(LoadingAnim());

        NowScene = SceneManager.GetActiveScene();
        SceneNum = NowScene.buildIndex;
        //SaveLoadMgn.instance.SaveData(SceneNum);

        /*
        if (StroyDataMgn.instance.isAutoLive)
        {
            autoText.gameObject.SetActive(true);
        }
        */
    }

    IEnumerator LoadingAnim()
    {
        yield return new WaitForSeconds(1.5f);

        loadingTextGroup.gameObject.SetActive(false);

        dialogue_Event.EnqueuDialogue(dialogue);

        isLoading = false;

    }


    void Update()
    {
        if (isLoading)
            return;
        else
        {
            /*
            if (StroyDataMgn.instance.isAutoLive == true && dialogue_Event.isTextComplete == true)
            {
                autoText.gameObject.SetActive(true);
                StartCoroutine(NextDelay());
                dialogue_Event.DequeueDialogue();
            }

            if (StroyDataMgn.instance.isAutoLive == false)
            {
                autoText.gameObject.SetActive(false);
            }
            */
            if ((Input.GetKeyUp(KeyCode.Space)) || (Input.GetKeyUp(KeyCode.Return)))
            {
                StartCoroutine(NextDelay());
                dialogue_Event.DequeueDialogue();
            }
        }
    }

    IEnumerator NextDelay()
    {
        yield return new WaitForSeconds(dealyCool);
    }


    public void Next()
    {
        dialogue_Event.DequeueDialogue();
    }

}
