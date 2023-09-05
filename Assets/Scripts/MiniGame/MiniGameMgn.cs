using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MiniGameMgn : MonoBehaviour
{
    [SerializeField]
    private GameObject conformGroup;            // �ܼ� ���� Ȯ�� �׷�
    [SerializeField]
    private GameObject failGroup;              // �ܼ� ���� �׷�
    [SerializeField]
    private GameObject clearGroup;             // �ܼ� ���� �׷�


    public bool[] isClear;
    public Button[] clueBtns;

    public int checkCount;

    public GameObject dialogueGroup;
    public GameObject dialogue;
    public GameObject miniGameGroup;

    public Scene NowScene;
    public int SceneNum;

    private void Update()
    {
        NowScene = SceneManager.GetActiveScene(); // �� �����Ӹ��� ���� �� Ȯ���ϱ�
        SceneNum = NowScene.buildIndex;

        if (checkCount == 2)
        {
            conformGroup.gameObject.SetActive(true);
        }

    }

    public void Conform()
    {
        if (isClear[0] && isClear[1])
        {
            clearGroup.gameObject.SetActive(true);
        }
        else
        {
            failGroup.gameObject.SetActive(true);
        }
    }

    public void Conform_2ver()
    {
        if (isClear[0])
        {
            clearGroup.gameObject.SetActive(true);
        }
        else
        {
            failGroup.gameObject.SetActive(true);
        }
    }

    public void Cancel()
    {
        checkCount = 0;

        for(int i = 0; i < isClear.Length; i++)
        {
            isClear[i] = false;
        }


        for(int j = 0; j < clueBtns.Length; j++)
        {
            clueBtns[j].enabled = true;
        }

        conformGroup.gameObject.SetActive(false);
        failGroup.gameObject.SetActive(false);

    }

    public void TimeOver()
    {
        StartCoroutine(GoGameScene());
    }

    IEnumerator GoGameScene()
    {
        yield return new WaitForSeconds(0.7f);

        SceneManager.LoadScene(SceneNum);
    }

    public void GoDialgoue()
    {
        miniGameGroup.gameObject.SetActive(false);
        dialogueGroup.gameObject.SetActive(true);
        dialogue.gameObject.SetActive(true);
    }

}
