using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestIndex : MonoBehaviour
{

    public int index;
    public A_Dialogue a_Dialogue;

    void Start()
    {
        a_Dialogue.dialogueIndex = index;
    }

}
