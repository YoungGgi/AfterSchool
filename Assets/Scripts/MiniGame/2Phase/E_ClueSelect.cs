using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class E_ClueSelect : MonoBehaviour
{
    [SerializeField]
    private Button clueButton;                  // 단서 버튼
    [SerializeField]
    private TextMeshProUGUI clueText;           // 버튼에 있는 단서 제목
    [SerializeField]
    private GameObject explainBox;                 // 단서 툴팁

    public ClueObject clue;                     // 단서

    public E_MiniGame e_MiniGame;

    private void Start()
    {
        clueText.text = clue.clueName;
    }

    public void ClueSelect()
    {
        clueButton.enabled = false;
        e_MiniGame.checkCount++;
    }

    public void ClueSelect_Clear()
    {
        clueButton.enabled = false;
        e_MiniGame.checkCount++;
        e_MiniGame.isClear[0] = true;
    }

    public void ClueSelect_Clear2()
    {
        clueButton.enabled = false;
        e_MiniGame.checkCount++;
        e_MiniGame.isClear[1] = true;
    }

}
