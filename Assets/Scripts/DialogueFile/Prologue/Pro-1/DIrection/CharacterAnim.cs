using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnim : MonoBehaviour
{
    [Header("Animation")]
    public Animator Hujung;                    // ȿ�� ���� �ִϸ�����
    public Animator YoungJin;                  // ���� ���� �ִϸ�����
    public Animator Jisu;                      // ���� ���� �ִϸ�����
    public Animator MinSeok;                   // �μ� ���� �ִϸ�����


    public void Animation(Dialogue_Base.Info info)
    {

        #region HujungAnim
        // ȿ�� �ִϸ��̼� ���
        if (info.h_Anim == H_Anim.H_Appear)
        {
            Hujung.Play("H_Appear");
        }

        if (info.h_Anim == H_Anim.H_DisAppear)
        {
            Hujung.Play("H_DisAppear");
        }

        if (info.h_Anim == H_Anim.Start)
        {
            Hujung.Play("H_Start");
        }

        if (info.h_Anim == H_Anim.Bangbang)
        {
            Hujung.Play("H_Bangbang");
        }
        #endregion

        #region YoungJinAnim
        if (info.y_Anim == Y_Anim.Y_Appear)
        {
            YoungJin.Play("Y_Appear");
        }

        if (info.y_Anim == Y_Anim.Y_DisAppear)
        {
            YoungJin.Play("Y_DisAppear");
        }

        if (info.y_Anim == Y_Anim.Start)
        {
            YoungJin.Play("Y_Start");
        }

        if (info.y_Anim == Y_Anim.Y_Bangbang)
        {
            YoungJin.Play("Y_Bangbang");
        }
        #endregion

        #region JisuAnim
        if (info.j_Anim == J_Anim.J_Appear)
        {
            Jisu.Play("J_Appear");
        }

        if (info.j_Anim == J_Anim.J_DisAppear)
        {
            Jisu.Play("J_DisAppear");
        }

        if (info.j_Anim == J_Anim.J_DisAppear)
        {
            Jisu.Play("J_Start");
        }

        #endregion

        #region MinSeokAnim
        // �μ� �ִϸ��̼� ���
        if (info.m_Anim == M_Anim.M_Appear)
        {
            MinSeok.Play("M_Appear");
        }

        if (info.m_Anim == M_Anim.M_DisAppear)
        {
            MinSeok.Play("M_DisAppear");
        }

        if (info.m_Anim == M_Anim.Start)
        {
            MinSeok.Play("M_Start");
        }
        #endregion

    }
}
