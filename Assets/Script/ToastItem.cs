using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//绑定在toastWindow上，是一个静态全局的脚本，用户数据由UserMeesagebuttonItem脚本而来


public class ToastItem : MonoBehaviour
{
    public Text nickname;
    public Text rank;
    [SerializeField] private GameObject toastWindows;
    void Start()
    {
        toastWindows.SetActive(false);
    }
    public void Exit(string userNickName,string trophy)
    { 
        toastWindows.SetActive(true);
        nickname.text = userNickName;
        rank.text = trophy;
    }
    public void CloseToastItem()
    {
        toastWindows.SetActive(false);
    }
    
}
