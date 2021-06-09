using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    public static int countDownSecond=835503;
    public Text countDownText;

    void Start()
    {
        CountDownTime(); 
    }

    public void CountDownTime()
    {
        int _day = (int) countDownSecond / 86400;
        int _hour = (int) countDownSecond / 3600 / 60;
        int _minute = (int) countDownSecond % 3600 / 60;
        int _second = (int) countDownSecond % 3600 % 60;
        countDownText.text = string.Format("赛季倒计时:{0}天{1}小时{2}分{3}秒", _day, _hour, _minute, _second);
        countDownSecond--;
        Invoke("CountDownTime", 1);
    }
}
