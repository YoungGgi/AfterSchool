using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomBtnBatch : MonoBehaviour
{
    public List<RectTransform> btnRectTrans;

    public List<Button> buttons;

    private void Start()
    {
        

        for(int i = 0; i < buttons.Count; i++)
        {
            int random = Random.Range(0, btnRectTrans.Count);

            buttons[i].transform.localPosition = btnRectTrans[random].transform.localPosition;
            btnRectTrans.RemoveAt(random);
        }

    }

}
