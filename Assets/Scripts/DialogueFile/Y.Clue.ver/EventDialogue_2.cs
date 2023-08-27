using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventDialogue_2 : MonoBehaviour
{
    public Dialogue_Base dialogue;
    public Dialogue_Event dialogue_Event;

    public bool isAuto;
    public float dealyCool;

    public GameObject autoText;

    
    public Scene NowScene;
    public int SceneNum;

    void OnEnable()
    {
        //dialogue_Event.EnqueuDialogue(dialogue);

        NowScene = SceneManager.GetActiveScene();
        SceneNum = NowScene.buildIndex;
        //SaveLoadMgn.instance.SaveData(SceneNum);

        dialogue_Event.EnqueuDialogue(dialogue);

        /*
        if (StroyDataMgn.instance.isAutoLive)
        {
            autoText.gameObject.SetActive(true);
        }
        */
    }



    void Update()
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

    IEnumerator NextDelay()
    {
        yield return new WaitForSeconds(dealyCool);
    }


    public void Next()
    {
        dialogue_Event.DequeueDialogue();
    }

}
