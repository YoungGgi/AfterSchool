using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniGameMgn : MonoBehaviour
{
    [SerializeField]
    private GameObject conformGroup;            // 단서 선택 확인 그룹
    [SerializeField]
    private GameObject failGroup;              // 단서 오답 그룹
    [SerializeField]
    private GameObject clearGroup;             // 단서 정답 그룹


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
