using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//绑定在排行榜userButton组建上，用于现实用户信息
public class UserMeesagebuttonItem : MonoBehaviour
{
    private int i;
    [SerializeField] private Text userNameText;
    [SerializeField] private Text userTrophyText;
    [SerializeField] private Text userIdText;
    [SerializeField] private Text rankingNumberText;
    [SerializeField] private Image rankingNumberImage;
    [SerializeField] private Image rankingTageImage;
    [SerializeField] private Sprite[] rankSprite=new Sprite[3]; 
    [SerializeField] private Sprite[] arenaBadge = new Sprite[14];
    
    //初始化个人信息，并把个人信息存到变量中
    public void Init(int x)
    {
        i = x;
        if (i < 3)
        {
            rankingNumberImage.GetComponent<Image>().SetNativeSize();
        }
        int trophy=int.Parse(AnalyzeJsonData.UserMessageList[i].trophy.ToString());
        rankingTageImage.sprite = arenaBadge[trophy/1000+1];
        userNameText.text = AnalyzeJsonData.UserMessageList[i].userName;
        userTrophyText.text = AnalyzeJsonData.UserMessageList[i].trophy.ToString();
        userIdText.text = AnalyzeJsonData.UserMessageList[i].userId;
    }
    
    //动态获取段位图片
    private void Awake()
    {
        for (int i = 0; i < rankSprite.Length; i++)
        {
            rankSprite[i] = Resources.Load<Sprite>("rank_"+(i+1).ToString());
            Debug.Log(rankSprite[i]);
        }
        for (int i = 0; i < arenaBadge.Length; i++)
        {
            arenaBadge[i] = Resources.Load<Sprite>("arenaBadge_"+(i+1).ToString()); 
        }
    }
    
    //调用单例模式的函数展示弹窗
    public void ShowToastMessageClick()
    {
        ToastItem.Instance.Exit(i);
    }
    
    //展示玩家名次
    public void EditRankingNumberText(int i)
    {
        rankingNumberImage.gameObject.SetActive(false);
        rankingNumberText.text = i.ToString();
    }
    
    //展示玩家名次
    public void EditRankingNumberImage(int i)
    {
        rankingNumberText.gameObject.SetActive(false);
        rankingNumberImage.sprite = rankSprite[i-1];
    }
}
