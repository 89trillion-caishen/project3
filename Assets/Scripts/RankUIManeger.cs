using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RankUIManeger : MonoBehaviour
{
    //打开排行榜按钮的panel
    [SerializeField] public Image openButtonpanel; 
    //顶部第一名信息展示
    [SerializeField] public Text no1UserId;
    [SerializeField] public Text no1NameText;
    [SerializeField] public Text no1TrophySumText;
    /// <summary>
    /// 打开排行榜点击事件
    /// </summary>
    public void OpenRankViewClick()
    {
        transform.gameObject.SetActive(true);
        openButtonpanel.gameObject.SetActive(false);
        InitNo1Message();
    }
    /// <summary>
    /// 关闭排行榜点击事件
    /// </summary>
    public void CloseRankViewClick()
    {
        openButtonpanel.gameObject.SetActive(true);
    }
    /// <summary>
    /// 初始化第一名信息
    /// </summary>
    public void InitNo1Message()
    {
        no1UserId.text= AnalyzeJsonData.UserMessageList[0].userId;
        no1NameText.text= AnalyzeJsonData.UserMessageList[0].userName;
        no1TrophySumText.text= AnalyzeJsonData.UserMessageList[0].trophy.ToString();
    }
    /// <summary>
    /// 初始化激活状态
    /// </summary>
    private void Start()
    {
        transform.gameObject.SetActive(false);
    }
}
