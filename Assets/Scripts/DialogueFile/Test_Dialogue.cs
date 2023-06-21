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

    public Scene NowScene;
    public int SceneNum;
    void Start()
    {
        a_Dialogue.EnqueuDialogue(dialogue);

        NowScene = SceneManager.GetActiveScene();
        SceneNum = NowScene.buildIndex;
        SaveLoadMgn.instance.SaveData(SceneNum);
    }

    void Update()
    {
        

        if (UI_Manager.instance.isAuto == true && a_Dialogue.isTextComplete == true)
        {
            autoText.gameObject.SetActive(true);
            StartCoroutine(NextDelay());
            a_Dialogue.DequeueDialogue();
        }

        if((Input.GetKeyUp(KeyCode.Space)) || (Input.GetKeyUp(KeyCode.Return)))
        {
            a_Dialogue.DequeueDialogue();
        }

    }

    IEnumerator NextDelay()
    {
        yield return new WaitForSeconds(dealyCool);
    }


    public void Next()
    {
        a_Dialogue.DequeueDialogue();
    }
    

}
