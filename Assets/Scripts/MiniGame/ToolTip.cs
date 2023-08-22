using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ToolTip : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI explain;

    float halfWidth;
    RectTransform rt;

    public void ToolTipOn(string clueEx)
    {
        explain.text = clueEx;
    }

    private void Start()
    {
        halfWidth = GetComponentInParent<CanvasScaler>().referenceResolution.x * 0.5f;
        rt = GetComponent<RectTransform>();
    }

    private void Update()
    {
        transform.position = Input.mousePosition;
        
        if(rt.anchoredPosition.x + rt.sizeDelta.x > halfWidth)
        {
            rt.pivot = new Vector2(1, 1);
        }
        else
        {
            rt.pivot = new Vector2(0, 1);
        }
        
    }

}
