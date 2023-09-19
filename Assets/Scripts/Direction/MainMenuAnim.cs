using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuAnim : MonoBehaviour
{
    public GameObject mainMenu;

    private void Start()
    {
        transform.localScale = Vector2.zero;
    }

    private void OnEnable()
    {
        transform.LeanScale(Vector2.one, 0.3f);
    }

    public void ExitMainMenu()
    {
        transform.LeanScale(Vector2.zero, 0.3f);
        StartCoroutine(ExitDelay());
    }

    IEnumerator ExitDelay()
    {
        yield return new WaitForSeconds(0.6f);
        mainMenu.gameObject.SetActive(false);
    }

}
