using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Dialogue : MonoBehaviour
{

    public Dialogue_Base dialogue;

    public bool isAuto;
    public float dealyCool;

    void Start()
    {
        A_Dialogue.instance.EnqueuDialogue(dialogue);
    }

    void Update()
    {
        /*
        if (Input.GetMouseButtonDown(0))
        {
            A_Dialogue.instance.DequeueDialogue();
        }
        */
       
        if(UI_Manager.instance.isAuto == true && A_Dialogue.instance.isTextComplete == true)
        {
            StartCoroutine(NextDelay());
            A_Dialogue.instance.DequeueDialogue();
        }

    }

    IEnumerator NextDelay()
    {
        yield return new WaitForSeconds(dealyCool);
    }


    public void Next()
    {
        A_Dialogue.instance.DequeueDialogue();
    }
    

}
