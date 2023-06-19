using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Dialogue : MonoBehaviour
{

    public Dialogue_Base dialogue;
    public A_Dialogue a_Dialogue;

    public bool isAuto;
    public float dealyCool;

    public GameObject autoText;

    void Start()
    {
        a_Dialogue.EnqueuDialogue(dialogue);
    }

    void Update()
    {
        if(UI_Manager.instance.isAuto == true && a_Dialogue.isTextComplete == true)
        {
            autoText.gameObject.SetActive(true);
            StartCoroutine(NextDelay());
            a_Dialogue.DequeueDialogue();
        }

        if((Input.GetButtonUp("Jump")) || (Input.GetKeyUp(KeyCode.Return)))
        {
            a_Dialogue.DequeueDialogue();
        }

    }

    IEnumerator NextDelay()
    {
        yield return new WaitForSeconds(dealyCool);
    }


    public void Next()
    {
        a_Dialogue.DequeueDialogue();
    }
    

}
