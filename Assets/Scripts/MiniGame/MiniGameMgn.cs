using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    private void Update()
    {
        if(checkCount == 2)
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

    public void Cancel()
    {
        checkCount = 0;

        isClear[0] = false;
        isClear[1] = false;

        for(int j = 0; j < clueBtns.Length; j++)
        {
            clueBtns[j].enabled = true;
        }

        conformGroup.gameObject.SetActive(false);

    }

}
