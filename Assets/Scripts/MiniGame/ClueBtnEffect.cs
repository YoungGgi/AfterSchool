using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClueBtnEffect : MonoBehaviour
{
    [SerializeField]
    private GameObject clueBtnObj;

    private void Start()
    {
        StartCoroutine(ActiveEffect());
    }

    IEnumerator ActiveEffect()
    {
        yield return new WaitForSeconds(9f);

        clueBtnObj.gameObject.SetActive(true);
    }

}
