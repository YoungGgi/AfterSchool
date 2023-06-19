using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneDirection : MonoBehaviour
{
    [Header("Direction")]
    public Animator fadeManager;                // 페이드 인 / 아웃 전용 효과
    public GameObject invenClue1;
    public GameObject invenClue2;
    public GameObject invenClue3;
    public GameObject invenClue4;

    public GameObject titleObj;

    public void GetDirection(Dialogue_Base.Info info)
    {
        #region SceneDirection
        if (info.direction == Direction.FadeIn)
        {
            fadeManager.Play("FadeIn");
        }

        if (info.direction == Direction.FadeOut)
        {
            fadeManager.Play("FadeOut");
        }

        if (info.Title_On)
        {
            titleObj.gameObject.SetActive(true);
        }
        else
        {
            titleObj.gameObject.SetActive(false);
        }
        #endregion

        #region AddInven
        if (info.isFirstClue)
        {
            invenClue1.gameObject.SetActive(true);
        }
        else
        {
            invenClue1.gameObject.SetActive(false);
        }

        if (info.isSecondClue)
        {
            invenClue2.gameObject.SetActive(true);
        }
        else
        {
            invenClue2.gameObject.SetActive(false);
        }

        if (info.isThirdClue)
        {
            invenClue3.gameObject.SetActive(true);
        }
        else
        {
            invenClue3.gameObject.SetActive(false);
        }

        if (info.isForthClue)
        {
            invenClue4.gameObject.SetActive(true);
        }
        else
        {
            invenClue4.gameObject.SetActive(false);
        }


        #endregion
    }

}
