using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterNameMgn : MonoBehaviour
{
    public A_Dialogue dialogue;

    [Header("캐릭터 이미지")]
    public Image hujungImg;                   // 효정 스프라이트
    public Image youngjinImg;                 // 용진 스프라이트
    public Image jisuImg;                     // 지수 스프라이트
    public Image minSeckImg;                  // 민석 스프라이트

    [Header("캐릭터 감정표현")]             // 각 캐릭터 표정 스프라이트
    public CharacterSprite hujung_Sprite;
    public CharacterSprite youngjing_Sprite;
    public CharacterSprite jisu_Sprite;
    public CharacterSprite minSeok_Sprite;

    Vector3 center = new Vector3(0, -396, 0);
    Vector3 right = new Vector3(500, -396, 0);
    Vector3 left = new Vector3(-500, -396, 0);

    Vector3 center_h = new Vector3(0, -474, 0);
    Vector3 right_h = new Vector3(500, -474, 0);
    Vector3 left_h = new Vector3(-500, -474, 0);

    Vector3 center_j = new Vector3(0, -481, 0);
    Vector3 right_j = new Vector3(500, -481, 0);
    Vector3 left_j = new Vector3(-500, -481, 0);

    Vector3 outpos = new Vector3(-1000, 0, 0);

    
    public void NameChangeDirection(int id)
    {
        switch(id)
        {
            case 0:
                dialogue.nameTxt.text = "";
                NameColor_Normal();
                hujungImg.color = youngjinImg.color = jisuImg.color = minSeckImg.color = Color.gray;
                break;
            case 1:
                NameColor_Normal();
                hujungImg.color = youngjinImg.color = jisuImg.color = minSeckImg.color = Color.gray;
                break;
            case 2:
                dialogue.nameTxt.text = "정효정";
                NameColor_Normal();
                hujungImg.color = new Color(255, 255, 255);
                youngjinImg.color = jisuImg.color = minSeckImg.color = Color.gray;
                break;
            case 3:
                dialogue.nameTxt.text = "이용진";
                NameColor_Normal();
                youngjinImg.color = new Color(255, 255, 255);
                hujungImg.color = jisuImg.color = minSeckImg.color = Color.gray;
                break;
            case 4:
                dialogue.nameTxt.text = "은지수";
                NameColor_Normal();
                jisuImg.color = new Color(255, 255, 255);
                youngjinImg.color = hujungImg.color = minSeckImg.color = Color.gray;
                break;
            case 5:
                dialogue.nameTxt.text = "염민석";
                NameColor_Normal();
                minSeckImg.color = new Color(255, 255, 255);
                youngjinImg.color = jisuImg.color = hujungImg.color = Color.gray;
                break;
            case 6:
                dialogue.nameTxt.text = "???";
                NameColor_Normal();
                hujungImg.color = youngjinImg.color = jisuImg.color = minSeckImg.color = Color.gray;
                break;
            case 7:
                dialogue.nameTxt.text = "효정&용진";
                NameColor_Normal();
                hujungImg.color = new Color(255, 255, 255);
                hujungImg.color = youngjinImg.color = new Color(255, 255, 255);
                break;
            case 8:
                dialogue.nameTxt.text = "???";
                jisuImg.color = new Color(255, 255, 255);
                NameColor_Normal();
                hujungImg.color = youngjinImg.color = minSeckImg.color = Color.gray;
                break;
            case 9:
                dialogue.nameTxt.text = "???";
                minSeckImg.color = new Color(255, 255, 255);
                NameColor_Normal();
                hujungImg.color = youngjinImg.color = jisuImg.color = Color.gray;
                break;
            case 10:
                hujungImg.color = new Color(255, 255, 255);
                NameColor_Normal();
                jisuImg.color = youngjinImg.color = minSeckImg.color = Color.gray;
                break;
            case 11:
                dialogue.nameTxt.text = "효정&지수";
                hujungImg.color = new Color(255, 255, 255);
                jisuImg.color = new Color(255, 255, 255);
                NameColor_Normal();
                youngjinImg.color = minSeckImg.color = Color.gray;
                break;
            case 12:
                youngjinImg.color = new Color(255, 255, 255);
                NameColor_Normal();
                jisuImg.color = hujungImg.color = minSeckImg.color = Color.gray;
                break;
            case 13:
                dialogue.nameTxt.text = "일동";
                hujungImg.color = youngjinImg.color = jisuImg.color = minSeckImg.color = new Color(255, 255, 255);
                break;
            case 14:
                dialogue.nameTxt.text = "선생님";
                NameColor_Normal();
                hujungImg.color = youngjinImg.color = jisuImg.color = minSeckImg.color = Color.gray;
                break;
            case 15:
                dialogue.nameTxt.text = "용진&지수";
                youngjinImg.color = jisuImg.color = new Color(255, 255, 255);
                NameColor_Normal();
                hujungImg.color = minSeckImg.color = Color.gray;
                break;
            case 16:
                dialogue.nameTxt.text = "학생1";
                NameColor_Normal();
                hujungImg.color = youngjinImg.color = jisuImg.color = minSeckImg.color = Color.gray;
                break;
            case 17:
                dialogue.nameTxt.text = "학생2";
                NameColor_Normal();
                hujungImg.color = youngjinImg.color = jisuImg.color = minSeckImg.color = Color.gray;
                break;
            case 18:
                dialogue.nameTxt.text = "학생3";
                NameColor_Normal();
                hujungImg.color = youngjinImg.color = jisuImg.color = minSeckImg.color = Color.gray;
                break;
            case 19:
                dialogue.nameTxt.text = "기지개를 펴는 곰탱이";
                NameColor_Color();
                hujungImg.color = youngjinImg.color = jisuImg.color = minSeckImg.color = Color.gray;
                break;
            case 20:
                dialogue.nameTxt.text = "노래를 부르는 토끼";
                NameColor_Color();
                hujungImg.color = youngjinImg.color = jisuImg.color = minSeckImg.color = Color.gray;
                break;
            case 21:
                dialogue.nameTxt.text = "???";
                NameColor_Normal();
                hujungImg.color = new Color(255, 255, 255);
                break;
        }
    }

    public void NameColor_Normal()
    {
        dialogue.nameTxt.color = Color.white;
        dialogue.dialogueTxt.color = Color.white;
    }

    public void NameColor_Color()
    {
        dialogue.nameTxt.color = Color.gray;
        dialogue.dialogueTxt.color = Color.yellow;

    }

    public void HujungSpriteDirection(int id)
    {
        switch(id)
        {
            case 0:
                hujungImg.sprite = hujung_Sprite.characterSprite[0];
                dialogue.hujungImg_CloseUp.sprite = hujung_Sprite.characterSprite[0];
                break;
            case 1:
                hujungImg.sprite = hujung_Sprite.characterSprite[1];
                dialogue.hujungImg_CloseUp.sprite = hujung_Sprite.characterSprite[1];
                break;
            case 2:
                hujungImg.sprite = hujung_Sprite.characterSprite[2];
                dialogue.hujungImg_CloseUp.sprite = hujung_Sprite.characterSprite[2];
                break;
            case 3:
                hujungImg.sprite = hujung_Sprite.characterSprite[3];
                dialogue.hujungImg_CloseUp.sprite = hujung_Sprite.characterSprite[3];
                break;
        }
    }

    public void HujungPosition(int id)
    {
        switch(id)
        {
            case 0:
                hujungImg.transform.localPosition = center_h;
                break;
            case 1:
                hujungImg.transform.localPosition = right_h;
                break;
            case 2:
                hujungImg.transform.localPosition = left_h;
                break;
            case 3:
                hujungImg.transform.localPosition = outpos;
                break;
        }
    }

    public void YoungJinSpriteDirection(int id)
    {
        switch (id)
        {
            case 0:
                youngjinImg.sprite = youngjing_Sprite.characterSprite[0];
                dialogue.youngjunImg_CloseUp.sprite = youngjing_Sprite.characterSprite[0];
                break;
            case 1:
                youngjinImg.sprite = youngjing_Sprite.characterSprite[1];
                dialogue.youngjunImg_CloseUp.sprite = youngjing_Sprite.characterSprite[1];
                break;
            case 2:
                youngjinImg.sprite = youngjing_Sprite.characterSprite[2];
                dialogue.youngjunImg_CloseUp.sprite = youngjing_Sprite.characterSprite[2];
                break;
            case 3:
                youngjinImg.sprite = youngjing_Sprite.characterSprite[3];
                dialogue.youngjunImg_CloseUp.sprite = youngjing_Sprite.characterSprite[3];
                break;
            case 4:
                youngjinImg.sprite = youngjing_Sprite.characterSprite[4];
                dialogue.youngjunImg_CloseUp.sprite = youngjing_Sprite.characterSprite[4];
                break;
            case 5:
                youngjinImg.sprite = youngjing_Sprite.characterSprite[5];
                dialogue.youngjunImg_CloseUp.sprite = youngjing_Sprite.characterSprite[5];
                break;
        }
    }

    public void YoungJinPosition(int id)
    {
        switch (id)
        {
            case 0:
                youngjinImg.transform.localPosition = center;
                break;
            case 1:
                youngjinImg.transform.localPosition = right;
                break;
            case 2:
                youngjinImg.transform.localPosition = left;
                break;
            case 3:
                youngjinImg.transform.localPosition = outpos;
                break;
        }
    }

    public void JisuSpriteDirection(int id)
    {
        switch (id)
        {
            case 0:
                jisuImg.sprite = jisu_Sprite.characterSprite[0];
                dialogue.jisuImg_CloseUp.sprite = jisu_Sprite.characterSprite[0];
                break;
            case 1:
                jisuImg.sprite = jisu_Sprite.characterSprite[1];
                dialogue.jisuImg_CloseUp.sprite = jisu_Sprite.characterSprite[1];
                break;
            case 2:
                jisuImg.sprite = jisu_Sprite.characterSprite[2];
                dialogue.jisuImg_CloseUp.sprite = jisu_Sprite.characterSprite[2];
                break;
            case 3:
                jisuImg.sprite = jisu_Sprite.characterSprite[3];
                dialogue.jisuImg_CloseUp.sprite = jisu_Sprite.characterSprite[3];
                break;
        }
    }

    public void JisuPosition(int id)
    {
        switch (id)
        {
            case 0:
                jisuImg.transform.localPosition = center_j;
                break;
            case 1:
                jisuImg.transform.localPosition = right_j;
                break;
            case 2:
                jisuImg.transform.localPosition = left_j;
                break;
            case 3:
                jisuImg.transform.localPosition = outpos;
                break;
        }
    }

    public void MinSeokSpriteDirection(int id)
    {
        switch (id)
        {
            case 0:
                minSeckImg.sprite = minSeok_Sprite.characterSprite[0];
                dialogue.minseok_CloseUp.sprite = minSeok_Sprite.characterSprite[0];
                break;
            case 1:
                minSeckImg.sprite = minSeok_Sprite.characterSprite[1];
                dialogue.minseok_CloseUp.sprite = minSeok_Sprite.characterSprite[1];
                break;
            case 2:
                minSeckImg.sprite = minSeok_Sprite.characterSprite[2];
                dialogue.minseok_CloseUp.sprite = minSeok_Sprite.characterSprite[2];
                break;
            case 3:
                minSeckImg.sprite = minSeok_Sprite.characterSprite[3];
                dialogue.minseok_CloseUp.sprite = minSeok_Sprite.characterSprite[3];
                break;
        }
    }

    public void MinSeokPosition(int id)
    {
        switch (id)
        {
            case 0:
                minSeckImg.transform.localPosition = center;
                break;
            case 1:
                minSeckImg.transform.localPosition = right;
                break;
            case 2:
                minSeckImg.transform.localPosition = left;
                break;
            case 3:
                minSeckImg.transform.localPosition = outpos;
                break;
        }
    }

}
