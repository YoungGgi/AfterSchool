using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomBtnBatch : MonoBehaviour
{
    // 버튼 위치 리스트
    public List<RectTransform> btnRectTrans;

    // 버튼 오브젝트 리스트
    public List<GameObject> buttons;

    private void Start()
    {
        // 버튼 리스트 반복문
        for(int i = 0; i < buttons.Count; i++)
        {
            // 버튼 위치 수량까지의 랜덤 값으로
            int random = Random.Range(0, btnRectTrans.Count);

            // 각 버튼들의 위치를 랜덤한 위치로 변경, 이후 배치된 랜덤값 제거
            buttons[i].transform.localPosition = btnRectTrans[random].transform.localPosition;
            btnRectTrans.RemoveAt(random);
        }

    }

}
