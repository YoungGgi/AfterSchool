using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuAnim : MonoBehaviour
{
    public Transform mainMenu;                // 메인메뉴
    public CanvasGroup backGround;            // 메인 CanvasGroup

    

    public void OnEnable()
    {
        // �ش� ������Ʈ�� Ȱ��ȭ�� �� �޹���� ���İ��� 1�� ���� ��
        backGround.alpha = 0;
        backGround.LeanAlpha(1, 0.5f);

        // LeanMoveLocalY() �� ���� �޴��� y���� �����Ŵ, �� ���� 0.1�� ������
        mainMenu.localPosition = new Vector2(0, -Screen.height);
        mainMenu.LeanMoveLocalY(0, 0.1f).setEaseOutExpo().delay = 0.1f;

    }

    public void CloseMenu()
    {
        // ���� �޴��� ���� �� �޹���� ���İ��� 0���� ����,
        backGround.LeanAlpha(0, 0.5f);
        // LeanMoveLocalY() �� ���� �޴��� y���� �����Ŵ, �� ���� MenuOff �Լ� ȣ��
        mainMenu.LeanMoveLocalY(-Screen.height, 0.1f).setEaseInExpo().setOnComplete(MenuOff);
    }

    // ���� �޴��� ��Ȱ��ȭ
    private void MenuOff()
    {
        gameObject.SetActive(false);
    }

}
