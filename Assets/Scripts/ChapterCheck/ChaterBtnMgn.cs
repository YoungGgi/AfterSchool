using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaterBtnMgn : MonoBehaviour
{
    [SerializeField]
    private GameObject chapter1Obj;

    private void Update()
    {
        if(ChapterCheck.instance.isPrologueComplete == true)
        {
            chapter1Obj.gameObject.SetActive(true);
        }
    }

}
