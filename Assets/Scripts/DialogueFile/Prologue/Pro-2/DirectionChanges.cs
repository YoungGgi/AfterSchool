using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionChanges : Dialogue_Test01
{
    [Header("Direction")]
    public Animator fadeManagers;               // 페이드 인 / 아웃 전용 효과

    public GameObject titleObjs;                // 게임 타이틀 오브젝트
    public GameObject subTitleObjs;

    [Header("Add Clue")]                       // 대화 진행 중 추가될 단서목록
    public ClueManager clues;
    public ClueObject clueObj0s;
    public ClueObject clueObj1s;
    public ClueObject clueObj2s;
    public ClueObject clueObj3s;

    private void Start()
    {
        fadeManager = fadeManagers;
        titleObj = titleObjs;
        subTitleObj = subTitleObjs;

        clue = clues;
        clueObj0 = clueObj0s;
        clueObj1 = clueObj1s;
        clueObj2 = clueObj2s;
        clueObj3 = clueObj3s;
    }

    protected override void BackGroundDirection(Dialogue_Base.Info info)
    {
        base.BackGroundDirection(info);

        #region Direction
        if (info.direction == Direction.FadeIn)
        {
            fadeManager.Play("FadeIn");
        }

        if (info.direction == Direction.FadeOut)
        {
            fadeManager.Play("FadeOut");
        }

        if (info.UI_Off)
        {
            dialoguePanelText.gameObject.SetActive(false);
            dialogueSetting.gameObject.SetActive(false);
        }
        else
        {
            dialoguePanelText.gameObject.SetActive(true);
            dialogueSetting.gameObject.SetActive(true);
        }

        if (info.Title_On)
        {
            titleObj.gameObject.SetActive(true);
        }
        else
        {
            titleObj.gameObject.SetActive(false);
        }

        if (info.Title_Two)
        {
            subTitleObj.gameObject.SetActive(true);
        }
        else
        {
            subTitleObj.gameObject.SetActive(false);
        }

        #endregion

        #region Inven
        if (info.isFirstClue)
        {
            clue.clues.Add(clueObj0);
            clue.clueAddCount++;
            isClueUpdate = true;
        }

        if (info.isSecondClue)
        {
            clue.clues.Add(clueObj1);
            clue.clueAddCount++;
            isClueUpdate = true;
        }

        if (info.isThirdClue)
        {
            clue.clues.Add(clueObj2);
            clue.clueAddCount++;
            isClueUpdate = true;
        }

        if (info.isForthClue)
        {
            clue.clues.Add(clueObj3);
            clue.clueAddCount++;
            isClueUpdate = true;
        }

        #endregion
    }
}
