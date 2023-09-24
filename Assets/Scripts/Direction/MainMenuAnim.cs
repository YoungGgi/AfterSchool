using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuAnim : MonoBehaviour
{
    public Transform mainMenu;                // 메인 메뉴 / 팝업
    public CanvasGroup backGround;            // 뒷배경 CanvasGroup

    public void OnEnable()
    {
        // 해당 오브젝트가 활성화될 시 뒷배경의 알파값을 1로 변경 후
        backGround.alpha = 0;
        backGround.LeanAlpha(1, 0.5f);

        // LeanMoveLocalY() 로 메인 메뉴의 y축을 변경시킴, 그 이후 0.1초 딜레이
        mainMenu.localPosition = new Vector2(0, -Screen.height);
        mainMenu.LeanMoveLocalY(0, 0.1f).setEaseOutExpo().delay = 0.1f;

    }

    public void CloseMenu()
    {
        // 메인 메뉴를 닫을 시 뒷배경의 알파값을 0으로 변경,
        backGround.LeanAlpha(0, 0.5f);
        // LeanMoveLocalY() 로 메인 메뉴의 y축을 변경시킴, 그 이후 MenuOff 함수 호출
        mainMenu.LeanMoveLocalY(-Screen.height, 0.1f).setEaseInExpo().setOnComplete(MenuOff);
    }

    // 메인 메뉴를 비활성화
    private void MenuOff()
    {
        gameObject.SetActive(false);
    }

}
