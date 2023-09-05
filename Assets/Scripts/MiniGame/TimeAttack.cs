using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeAttack : MonoBehaviour
{
    public float time;

    public int min;
    public int sec;

    [SerializeField]
    private TextMeshProUGUI time_Txt;
    [SerializeField]
    private GameObject timeOverObj;

    private void OnEnable()
    {
        Update();

    }
    private void OnDisable()
    {
        StopCoroutine(TimeStart());

    }

    private void Update()
    {
        StartCoroutine(TimeStart());

    }

    IEnumerator TimeStart()
    {
        float waitTime = 0.5f;
        yield return new WaitForSeconds(waitTime);

        if (time > 0f)
        {
            time -= Time.deltaTime;
            min = (int)time / 60;
            sec = (int)time % 60;
            time_Txt.text = min.ToString("00") + ":" + sec.ToString("00");
        }
        else if(time < 0f)
        {
            timeOverObj.gameObject.SetActive(true);
        }


        if (time < 11f)
            time_Txt.color = new Color(255, 0, 0);

    }

}
