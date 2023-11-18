using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollBar : MonoBehaviour
{
    public RectTransform scroll;

    private void OnEnable() 
    {
        float x = scroll.anchoredPosition.x;
        scroll.anchoredPosition = new Vector3(x, 0, 0);        
    }

}
