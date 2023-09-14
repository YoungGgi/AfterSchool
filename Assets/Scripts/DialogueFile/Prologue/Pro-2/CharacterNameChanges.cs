using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterNameChanges : Dialogue_Test01
{

    [Header("Character")]
    public Image hujungImgs;                   // 효정 스프라이트
    public Image youngjinImgs;                 // 용진 스프라이트
    public Image jisuImgs;                     // 지수 스프라이트
    public Image minSeckImgs;                  // 민석 스프라이트
    public Transform centers;                  // 캐릭터 위치(용진)
    public Transform lefts;
    public Transform rights;
    public Transform out_pos_s;
    public RectTransform center1s;             // 캐릭터 위치(효정, 지수, 민석?)
    public RectTransform left1s;
    public RectTransform right1s;

    private void Start()
    {
        hujungImg = hujungImgs;
        youngjinImg = youngjinImgs;
        jisuImg = jisuImgs;
        minSeckImg = minSeckImgs;

        center = centers;
        left = lefts;
        right = rights;
        out_pos = out_pos_s;
        center1 = center1s;
        left1 = left1s;
        right1 = right1s;
    }

    protected override void CharacterName(Dialogue_Base.Info info)
    {
        base.CharacterName(info);

        switch (info.charName)
        {
            case Name.Blank:
                nameTxt.text = "";
                nameTxt.color = Color.white;
                dialogueTxt.color = Color.white;
                hujungImg.color = youngjinImg.color = jisuImg.color = minSeckImg.color = Color.gray;
                break;
            case Name.Player:
                nameTxt.text = PlayerName.instance.player;
                nameTxt.color = Color.white;
                dialogueTxt.color = Color.white;
                hujungImg.color = youngjinImg.color = jisuImg.color = minSeckImg.color = Color.gray;
                break;
            case Name.Hujung:
                nameTxt.text = "정효정";
                hujungImg.color = new Color(255, 255, 255);
                nameTxt.color = Color.white;
                dialogueTxt.color = Color.white;
                youngjinImg.color = jisuImg.color = minSeckImg.color = Color.gray;
                break;
            case Name.YoungJin:
                nameTxt.text = "이용진";
                youngjinImg.color = new Color(255, 255, 255);
                nameTxt.color = Color.white;
                dialogueTxt.color = Color.white;
                hujungImg.color = jisuImg.color = minSeckImg.color = Color.gray;
                break;
            case Name.Jisu:
                nameTxt.text = "은지수";
                jisuImg.color = new Color(255, 255, 255);
                nameTxt.color = Color.white;
                dialogueTxt.color = Color.white;
                hujungImg.color = youngjinImg.color = minSeckImg.color = Color.gray;
                break;
            case Name.MinSeok:
                nameTxt.text = "염민석";
                minSeckImg.color = new Color(255, 255, 255);
                nameTxt.color = Color.white;
                dialogueTxt.color = Color.white;
                hujungImg.color = youngjinImg.color = jisuImg.color = Color.gray;
                break;
            case Name.Who:
                nameTxt.text = "???";
                nameTxt.color = Color.white;
                dialogueTxt.color = Color.white;
                hujungImg.color = youngjinImg.color = jisuImg.color = minSeckImg.color = Color.gray;
                break;
            case Name.HujungYoung:
                nameTxt.text = "효정&용진";
                nameTxt.color = Color.white;
                dialogueTxt.color = Color.white;
                hujungImg.color = youngjinImg.color = new Color(255, 255, 255);
                break;
            case Name.Who_Jisu:
                nameTxt.text = "???";
                jisuImg.color = new Color(255, 255, 255);
                nameTxt.color = Color.white;
                dialogueTxt.color = Color.white;
                hujungImg.color = youngjinImg.color = minSeckImg.color = Color.gray;
                break;
            case Name.Who_Min:
                nameTxt.text = "???";
                minSeckImg.color = new Color(255, 255, 255);
                nameTxt.color = Color.white;
                dialogueTxt.color = Color.white;
                hujungImg.color = youngjinImg.color = jisuImg.color = Color.gray;
                break;
            case Name.PlayerHujung:
                nameTxt.text = PlayerName.instance.player + "&" + "효정";
                hujungImg.color = new Color(255, 255, 255);
                nameTxt.color = Color.white;
                dialogueTxt.color = Color.white;
                youngjinImg.color = jisuImg.color = minSeckImg.color = Color.gray;
                break;
            case Name.HujungJisu:
                nameTxt.text = "효정&지수";
                nameTxt.color = Color.white;
                dialogueTxt.color = Color.white;
                hujungImg.color = jisuImg.color = new Color(255, 255, 255);
                youngjinImg.color = Color.gray;
                break;
            case Name.PlayerYoungJin:
                nameTxt.text = PlayerName.instance.player + "&" + "용진";
                youngjinImg.color = new Color(255, 255, 255);
                nameTxt.color = Color.white;
                dialogueTxt.color = Color.white;
                hujungImg.color = jisuImg.color = minSeckImg.color = Color.gray;
                break;
            case Name.All:
                nameTxt.text = "일동";
                nameTxt.color = Color.white;
                dialogueTxt.color = Color.white;
                break;
            case Name.Teacher:
                nameTxt.text = "선생님";
                nameTxt.color = Color.white;
                dialogueTxt.color = Color.white;
                hujungImg.color = youngjinImg.color = jisuImg.color = minSeckImg.color = Color.gray;
                break;
            case Name.YoungJinJisu:
                nameTxt.text = "용진&지수";
                youngjinImg.color = jisuImg.color = new Color(255, 255, 255);
                nameTxt.color = Color.white;
                dialogueTxt.color = Color.white;
                hujungImg.color = minSeckImg.color = Color.gray;
                break;
            case Name.Student01:
                nameTxt.text = "학생1";
                hujungImg.color = youngjinImg.color = jisuImg.color = minSeckImg.color = Color.gray;
                break;
            case Name.Student02:
                nameTxt.text = "학생2";
                hujungImg.color = youngjinImg.color = jisuImg.color = minSeckImg.color = Color.gray;
                break;
            case Name.Student03:
                nameTxt.text = "학생3";
                hujungImg.color = youngjinImg.color = jisuImg.color = minSeckImg.color = Color.gray;
                break;
            case Name.Bear:
                nameTxt.text = "기지개를 펴는 곰탱이";
                nameTxt.color = Color.gray;
                dialogueTxt.color = Color.yellow;
                hujungImg.color = youngjinImg.color = jisuImg.color = minSeckImg.color = Color.gray;
                break;
            case Name.Rabbit:
                nameTxt.text = "노래를 부르는 토끼";
                nameTxt.color = Color.gray;
                dialogueTxt.color = Color.yellow;
                hujungImg.color = youngjinImg.color = jisuImg.color = minSeckImg.color = Color.gray;
                break;
        }
    }

    protected override void CharacterEmotion(Dialogue_Base.Info info)
    {
        base.CharacterEmotion(info);

        #region HujungEmotion
        switch (info.h_sprite)
        {
            case H_Sprite.Idle:
                hujungImg.sprite = hujung_Sprite.characterSprite[0];
                hujungImg_CloseUp.sprite = hujung_Sprite.characterSprite[0];
                break;
            case H_Sprite.Angry:
                hujungImg.sprite = hujung_Sprite.characterSprite[1];
                hujungImg_CloseUp.sprite = hujung_Sprite.characterSprite[1];
                break;
        }
        #endregion

        #region YoungjinEmotion
        switch (info.y_sprite)
        {
            case Y_Sprite.Idle:
                youngjinImg.sprite = youngjing_Sprite.characterSprite[0];
                break;
            case Y_Sprite.Idle01:
                youngjinImg.sprite = youngjing_Sprite.characterSprite[1];
                break;
            case Y_Sprite.Angry:
                youngjinImg.sprite = youngjing_Sprite.characterSprite[2];
                break;
            case Y_Sprite.Smile:
                youngjinImg.sprite = youngjing_Sprite.characterSprite[3];
                break;
            case Y_Sprite.Smile01:
                youngjinImg.sprite = youngjing_Sprite.characterSprite[4];
                break;
            case Y_Sprite.Surprise:
                youngjinImg.sprite = youngjing_Sprite.characterSprite[5];
                break;
        }
        #endregion

        #region JisuEmotion
        switch (info.j_sprite)
        {
            case J_Sprite.Idle:
                jisuImg.sprite = jisu_Sprite.characterSprite[0];
                break;
            case J_Sprite.Angry:
                jisuImg.sprite = jisu_Sprite.characterSprite[1];
                break;
            case J_Sprite.Smile:
                jisuImg.sprite = jisu_Sprite.characterSprite[2];
                break;
            case J_Sprite.Surprise:
                jisuImg.sprite = jisu_Sprite.characterSprite[3];
                break;
        }
        #endregion

        #region MinSeokEmotion
        switch (info.m_sprite)
        {
            case M_Sprite.Idle:
                minSeckImg.sprite = minSeok_Sprite.characterSprite[0];
                break;
            case M_Sprite.Angry:
                youngjinImg.sprite = minSeok_Sprite.characterSprite[1];
                break;
            case M_Sprite.Smile:
                youngjinImg.sprite = minSeok_Sprite.characterSprite[2];
                break;
            case M_Sprite.Surprise:
                youngjinImg.sprite = minSeok_Sprite.characterSprite[3];
                break;
        }
        #endregion
    }

    protected override void CharacterDirection(Dialogue_Base.Info info)
    {
        base.CharacterDirection(info);

        #region CharacterDirection

        #region HujungImgDirection

        switch (info.h_Direction)
        {
            case H_Direction.Center:
                hujungImg.transform.localPosition = center1.transform.localPosition;
                break;
            case H_Direction.Right:
                hujungImg.transform.localPosition = right1.transform.localPosition;
                break;
            case H_Direction.Left:
                hujungImg.transform.localPosition = left1.transform.localPosition;
                break;
            case H_Direction.Out:
                hujungImg.transform.position = out_pos.transform.position;
                break;
        }

        #endregion

        #region YoungjinImgDirection

        switch (info.y_Direction)
        {
            case Y_Direction.Center:
                youngjinImg.transform.position = center.transform.position;
                break;
            case Y_Direction.Right:
                youngjinImg.transform.position = right.transform.position;
                break;
            case Y_Direction.Left:
                youngjinImg.transform.position = left.transform.position;
                break;
            case Y_Direction.Out:
                youngjinImg.transform.position = out_pos.transform.position;
                break;

        }
        #endregion

        #region JisuImgDirection

        switch (info.j_Direction)
        {
            case J_Direction.Center:
                jisuImg.transform.localPosition = center1.transform.localPosition;
                break;
            case J_Direction.Right:
                jisuImg.transform.localPosition = right1.transform.localPosition;
                break;
            case J_Direction.Left:
                jisuImg.transform.localPosition = left1.transform.localPosition;
                break;
            case J_Direction.Out:
                jisuImg.transform.localPosition = out_pos.transform.localPosition;
                break;
        }
        #endregion

        #region MinSeokImgDirection

        switch (info.m_Direction)
        {
            case M_Direction.Center:
                minSeckImg.transform.localPosition = center1.transform.localPosition;
                break;
            case M_Direction.Right:
                minSeckImg.transform.localPosition = right1.transform.localPosition;
                break;
            case M_Direction.Left:
                minSeckImg.transform.localPosition = left1.transform.localPosition;
                break;
            case M_Direction.Out:
                minSeckImg.transform.localPosition = out_pos.transform.localPosition;
                break;
        }
        #endregion

        #endregion
    }
}
