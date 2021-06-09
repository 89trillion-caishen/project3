using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//绑定在toastWindow上，是一个单例模式，用户数据由UserMeesagebuttonItem脚本而来


public class ToastItem : MonoBehaviour
{
    public static ToastItem Instance { get; set; }
    [SerializeField] private Text userName;
    [SerializeField] private Text userRank;
    [SerializeField] private GameObject toastWindows;

    [SerializeField] private Image toastBackGroundImage;
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        toastBackGroundImage.GetComponent<Image>().raycastTarget = false;
        toastWindows.SetActive(false);
    }
    
    //激活弹窗，显示用户信息
    public void Exit(int i)
    {
        toastWindows.SetActive(true);
        toastBackGroundImage.GetComponent<Image>().raycastTarget = true;
        userName.text = AnalyzeJsonData.UserMessageList[i].userId;
        userRank.text =  AnalyzeJsonData.UserMessageList[i].trophy.ToString();
    }
    
    //关闭弹窗
    public void CloseToastItem()
    {
        toastBackGroundImage.GetComponent<Image>().raycastTarget = false;
        toastWindows.SetActive(false);
    }
    
}
