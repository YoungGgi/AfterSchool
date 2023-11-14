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

        if (nameTexts.Length > 0)
        {
            button.SetActive(false);
        }
        else
        {
            button.SetActive(true);
        }

        if(nameTexts == " " || nameTexts == "  " || nameTexts == "   " || nameTexts == "    " || nameTexts == "     ")
        {
            button.SetActive(true);
        }
    }

    public void TextOn()
    {
        
        string name = nameTexts;
        PlayerName.instance.SaveName(name);
        nameSelectPopUP.gameObject.SetActive(false);
        ui.GameStart();
        

    }

}
