using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//绑定在toastWindow上，是一个单例模式，用户数据由UserMeesagebuttonItem脚本而来


public class ToastItem : MonoBehaviour
{
    public static ToastItem Instance { get; set; }
    public Text nickname;
    public Text rank;
    [SerializeField] private GameObject toastWindows;
    
    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        toastWindows.SetActive(false);
    }
    
    //激活弹窗，显示用户信息
    public void Exit(string userNickName,string trophy)
    { 
        toastWindows.SetActive(true);
        nickname.text = userNickName;
        rank.text = trophy;
    }
    
    //关闭弹窗
    public void CloseToastItem()
    {
        toastWindows.SetActive(false);
    }
    
}
