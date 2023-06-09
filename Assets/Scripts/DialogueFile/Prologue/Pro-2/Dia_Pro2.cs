using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dia_Pro2 : MonoBehaviour
{
    public PrologueBase2 dialogue;
    public Prologue2 prologue2;

    public bool isAuto;
    public float dealyCool;

    public GameObject autoText;

    private void Start()
    {
        prologue2.EnqueuDialogue(dialogue);
    }

    private void Update()
    {
        if (UI_Manager.instance.isAuto == true && prologue2.isTextComplete == true)
        {
            autoText.gameObject.SetActive(true);
            StartCoroutine(NextDelay());
            prologue2.DequeueDialogue();
        }

    }


    IEnumerator NextDelay()
    {
        yield return new WaitForSeconds(dealyCool);
    }


    public void Next()
    {
        prologue2.DequeueDialogue();
    }


}
