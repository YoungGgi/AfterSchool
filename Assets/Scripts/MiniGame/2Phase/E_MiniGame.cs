using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class E_MiniGame : MonoBehaviour
{
    [SerializeField]
    private GameObject conformGroup;            // 단서 선택 확인 그룹
    [SerializeField]
    private GameObject failGroup;              // 단서 오답 그룹
    [SerializeField]
    private GameObject clearGroup0;             // 단서 정답 그룹
    [SerializeField]
    private GameObject clearGroup1;
    [SerializeField]
    private GameObject clearGroup2;

    // 게임 완료 후 진행될 대사들
    public GameObject dialogue_1;
    public GameObject dialogue_2;
    public GameObject dialogue_3;

    public GameObject gameScene;               // 미니게임 관련 UI들
    public GameObject dialogueScene;

    public bool[] isClear;
    public Button[] clueBtns;

    public int checkCount;

    private void Update()
    {
        if (checkCount == 1)
        {
            conformGroup.gameObject.SetActive(true);
        }

    }

    public void NextDialogue1()
    {
        isClear[0] = false;
        checkCount = 0;

        for(int i = 0; i < clueBtns.Length; i++)
        {
            clueBtns[i].enabled = true;
        }

        gameScene.gameObject.SetActive(false);
        dialogueScene.gameObject.SetActive(true);
        dialogue_1.gameObject.SetActive(true);
    }

    public void NextDialogue2()
    {
        isClear[0] = false;
        checkCount = 0;

        for (int i = 0; i < clueBtns.Length; i++)
        {
            clueBtns[i].enabled = true;
        }

        gameScene.gameObject.SetActive(false);
        dialogueScene.gameObject.SetActive(true);
        dialogue_2.gameObject.SetActive(true);
    }

    public void NextDialogue3()
    {
        isClear[0] = false;
        checkCount = 0;

        for (int i = 0; i < clueBtns.Length; i++)
        {
            clueBtns[i].enabled = true;
        }

        gameScene.gameObject.SetActive(false);
        dialogueScene.gameObject.SetActive(true);
        dialogue_3.gameObject.SetActive(true);
    }

    public void Conform()
    {
        if (isClear[0] || isClear[1])
        {
            clearGroup0.gameObject.SetActive(true);
        }
        else
        {
            failGroup.gameObject.SetActive(true);
        }
    }

    public void Cancel()
    {
        checkCount = 0;

        isClear[0] = false;
        //isClear[1] = false;

        for (int j = 0; j < clueBtns.Length; j++)
        {
            clueBtns[j].enabled = true;
        }

        conformGroup.gameObject.SetActive(false);

    }

}
