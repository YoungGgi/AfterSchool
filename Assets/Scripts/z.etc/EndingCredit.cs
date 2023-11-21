using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Timeline;

public class EndingCredit : MonoBehaviour
{
    [SerializeField]
    private GameObject ending;

    [SerializeField]
    private GameObject gameLogo;

    public TimelineAsset timelineAsset;

    private void Update() 
    {
        
        StartCoroutine(TimeDelay());
        

    }

    IEnumerator TimeDelay()
    {
        yield return new WaitForSeconds(45);

        Debug.Log("End");

        //ChapterCheck.instance.EpilogueClear(1);
        //SceneManager.LoadScene(0);
    }


}
