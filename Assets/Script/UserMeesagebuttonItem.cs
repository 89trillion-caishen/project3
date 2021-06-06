using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//绑定在排行榜userButton组建上，用于现实用户信息
public class UserMeesagebuttonItem : MonoBehaviour
{
    private string nickname;
    private string userTrophy;
    //public GameObject toast;
    [SerializeField] private Text usernameText;
    [SerializeField] private Text userTrophyText;
    [SerializeField] private Text RankingNumberText;
    [SerializeField] private Image RankingNumberImage;
    [SerializeField] private Sprite Sprite1;
    [SerializeField] private Sprite Sprite2;
    [SerializeField] private Sprite Sprite3;
    //初始化个人信息，并把个人信息存到变量中
    public void Init(string nickName,string trophy)
    {
        nickname = nickName;
        userTrophy = trophy;
        usernameText.text = nickName;
        userTrophyText.text = trophy;
    }
    //展示弹窗
    public void ShowToastMessageClick()
    {
          
        //ToastItem t = GameObject.Find("toastWindow").GetComponent<ToastItem>();
       // t.Exit(nickname, userTrophy);
        //GameObject.Find("toastWindows").GetComponent<脚本名>().函数名()
        //ToastItem.Exit(nickname,userTrophy):
        Debug.Log(userTrophy);
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
        if (i == 1)
        {
            RankingNumberImage.sprite = Sprite1;
        }

        if (i == 2)
        {
            RankingNumberImage.sprite = Sprite2;
        }

        if (i == 3)
        {
            RankingNumberImage.sprite = Sprite3;
        }
    }

}
