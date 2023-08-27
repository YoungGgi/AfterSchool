using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainScene : MonoBehaviour
{
    [SerializeField]
    private Button loadBtn;
    
    private void Start()
    {
        loadBtn.enabled = SaveLoadMgn.instance.loadNum != 0;

        /*
         아래의 식과 같음
        if (SaveLoadMgn.instance.loadNum == 0)
        {
            loadBtn.enabled = false;
        }
        else
        {
            loadBtn.enabled = true;
        }
        */
    }
}
