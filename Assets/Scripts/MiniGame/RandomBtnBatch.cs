using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomBtnBatch : MonoBehaviour
{
    // 버튼 위치 정보를 담은 리스트
    public List<RectTransform> btnRectTrans;

    // 단서 버튼들을 담은 리스트
    public List<GameObject> buttons;

    private void Start()
    {
        for(int i = 0; i < buttons.Count; i++)
        {
            // 버튼 위치만큼 랜덤 값 부여
            int random = Random.Range(0, btnRectTrans.Count);

            buttons[i].transform.localPosition = btnRectTrans[random].transform.localPosition;
            btnRectTrans.RemoveAt(random);
        }

    }

}
