using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerNameSelect : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public GameObject nameSelectPopUP;

    public UI_Manager ui;


    public void TextOn()
    {
        string name = nameText.text;

        PlayerName.instance.SaveName(name);
        nameSelectPopUP.gameObject.SetActive(false);
        ui.GameStart();
    }

}
