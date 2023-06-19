using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteCharacter : MonoBehaviour
{
    [Header("Character")]
    public Image hujungImg;                   // 효정 캐릭터 스프라이트
    public Image youngjinImg;                 // 용진 캐릭터 스프라이트
    public Transform center;
    public Transform left;
    public Transform right;

    public void SpriteStart(Dialogue_Base.Info info)
    {
        #region HujungImgDirection
        if (info.h_Direction == H_Direction.Center)
        {
            hujungImg.transform.position = center.transform.position;
        }

        if (info.h_Direction == H_Direction.Right)
        {
            hujungImg.transform.position = right.transform.position;
        }

        if (info.h_Direction == H_Direction.Left)
        {
            hujungImg.transform.position = left.transform.position;
        }
        #endregion

        #region YoungjinImgDirection

        if (info.y_Direction == Y_Direction.Center)
        {
            youngjinImg.transform.position = center.transform.position;
        }

        if (info.y_Direction == Y_Direction.Right)
        {
            youngjinImg.transform.position = right.transform.position;
        }

        if (info.y_Direction == Y_Direction.Left)
        {
            youngjinImg.transform.position = left.transform.position;
        }

        #endregion

    }

}
