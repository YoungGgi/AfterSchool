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

        if (!PlayerPrefs.HasKey("EpilogueClear"))
        {
            ChapterCheck.instance.EpilogueClear(1);
            SceneManager.LoadScene(0);
        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }


}
