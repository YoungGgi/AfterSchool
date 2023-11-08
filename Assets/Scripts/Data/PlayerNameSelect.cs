using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerNameSelect : MonoBehaviour
{
    public TextMeshProUGUI nameText;

    public GameObject nameSelectPopUP;

    public UI_Manager ui;

    public GameObject button;

    public TMP_InputField inputField;

    string nameTexts = null;

    void Awake()
    {
        inputField = GetComponent<TMP_InputField>();
        nameTexts = inputField.text;
    }
    
    void Update()
    {
        nameTexts = inputField.text;

        if (nameTexts != "")
        {
            button.SetActive(false);
        }
        else
        {
            button.SetActive(true);
        }
    }

    public void TextOn()
    {
        
        /*
        if(nameText.text == "")
        {
            Debug.Log("NoName");
            return;
        }
        */

        string name = nameTexts;
        PlayerName.instance.SaveName(name);
        nameSelectPopUP.gameObject.SetActive(false);
        ui.GameStart();
        

    }

}
