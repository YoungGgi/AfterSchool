using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EscapeUp : MonoBehaviour
{
    [SerializeField]
    private GameObject escapeObject;
    [SerializeField]
    private GameObject unEscapeObject;
    [SerializeField]
    private bool isMainSetting;

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (!isMainSetting)
            {
                SetOut();
            }
            else
            {
                escapeObject.gameObject.SetActive(false);
                StroyDataMgn.instance.IsSettingOn = false;
            }

        }
    }

    public void SetOut()
    {
        escapeObject.gameObject.SetActive(false);
        unEscapeObject.gameObject.SetActive(true);
    }


}
