using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RankUIManeger : MonoBehaviour
{
    //打开排行榜按钮
    public Button openButton;

    //打开排行榜点击事件
    public void OpenRankViewClick()
    {
        transform.gameObject.SetActive(true);
        openButton.gameObject.SetActive(false);
        InitNo1Message();
    }
    //关闭排行榜点击事件
    public void CloseRankViewClick()
    {
        transform.gameObject.SetActive(false);
        openButton.gameObject.SetActive(true);
    }
    //顶部第一名信息展示
    [SerializeField] public Text no1UserId;
    [SerializeField] public Text no1NameText;
    [SerializeField] public Text no1TrophySumText;
   
    //初始化第一名信息
    public void InitNo1Message()
    {
        no1UserId.text= AnalyzeJsonData.UserMessageList[0].userId;
        no1NameText.text= AnalyzeJsonData.UserMessageList[0].userName;
        no1TrophySumText.text= AnalyzeJsonData.UserMessageList[0].trophy.ToString();
    }

    private void Start()
    {
        transform.gameObject.SetActive(false);
    }
}
