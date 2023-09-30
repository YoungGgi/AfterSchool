using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomBtnBatch : MonoBehaviour
{
    // ��ư ��ġ ����Ʈ
    public List<RectTransform> btnRectTrans;

    // ��ư ������Ʈ ����Ʈ
    public List<GameObject> buttons;

    private void Start()
    {
        // ��ư ����Ʈ �ݺ���
        for(int i = 0; i < buttons.Count; i++)
        {
            // ��ư ��ġ ���������� ���� ������
            int random = Random.Range(0, btnRectTrans.Count);

            // �� ��ư���� ��ġ�� ������ ��ġ�� ����, ���� ��ġ�� ������ ����
            buttons[i].transform.localPosition = btnRectTrans[random].transform.localPosition;
            btnRectTrans.RemoveAt(random);
        }

    }

}
