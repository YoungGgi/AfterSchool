using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneBtn : MonoBehaviour
{
    [SerializeField]
    private GameObject cutScene;

    public void CutSceneOpen()
    {
        SceneUp();
    }

    public void SceneUp()
    {
        cutScene.SetActive(true);
    }

    public void SceneOut()
    {
        //cutScene.LeanAlpha(0, 0.1f);
    }

}
