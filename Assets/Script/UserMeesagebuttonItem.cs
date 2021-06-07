using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//绑定在排行榜userButton组建上，用于现实用户信息
public class UserMeesagebuttonItem : MonoBehaviour
{
    private string _nickname;
    private string _userTrophy;

    private int i;
    //public GameObject toast;
    [SerializeField] private Text usernameText;
    [SerializeField] private Text userTrophyText;
    [SerializeField] private Text RankingNumberText;
    [SerializeField] private Image RankingNumberImage;
    [SerializeField] private Sprite[] _sprite=new Sprite[3];
    
    //初始化个人信息，并把个人信息存到变量中
    public void Init(int x,string nickName,string trophy)
    {
        i = x;
        _nickname = nickName;
        _userTrophy = trophy;
        usernameText.text = nickName;
        userTrophyText.text = trophy;
    }
    
    
    //调用单例模式的函数展示弹窗
    public void ShowToastMessageClick()
    {
        ToastItem.Instance.Exit(_nickname,_userTrophy);
        Debug.Log(_userTrophy);
    }
    
    //展示玩家名次
    public void EditRankingNumberText(int i)
    {
        RankingNumberImage.gameObject.SetActive(false);
        RankingNumberText.text = i.ToString();
    }
    
    //展示玩家名次
    public void EditRankingNumberImage(int i)
    {
        RankingNumberText.gameObject.SetActive(false);
        RankingNumberImage.sprite = _sprite[i-1];
    }
}
