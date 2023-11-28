using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingCredit : MonoBehaviour
{
    [SerializeField]
    private GameObject ending;

    [SerializeField]
    private GameObject gameLogo;


    private void Update() 
    {
        
        StartCoroutine(TimeDelay());
        

    }

    IEnumerator TimeDelay()
    {
        yield return new WaitForSeconds(43);

        
        ChapterCheck.instance.EpilogueClear(1);
        SceneManager.LoadScene(0);
    }


}
