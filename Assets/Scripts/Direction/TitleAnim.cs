using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TitleAnim : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    private Image titleObject;
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        titleObject.color = Color.gray;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        titleObject.color = Color.white;
    }
}
