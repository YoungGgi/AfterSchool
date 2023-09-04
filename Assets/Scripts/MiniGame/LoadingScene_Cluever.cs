using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingScene_Cluever : MonoBehaviour
{
    public GameObject loadingTextGroup;

    public bool isLoading;


    void OnEnable()
    {
        isLoading = true;
        StartCoroutine(LoadingAnim());

    }

    IEnumerator LoadingAnim()
    {
        yield return new WaitForSeconds(1.5f);

        loadingTextGroup.gameObject.SetActive(false);

        isLoading = false;

    }


}
