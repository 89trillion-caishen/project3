using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static System.Convert;

public class RankDiaLog : MonoBehaviour
{
    private bool isCreatePrefab=false;

    [SerializeField] private Transform contentTransform;
    [SerializeField] public GameObject userItem;
    
    //顶部第一名信息展示
    [SerializeField] public Text no1UserId;
    [SerializeField] public Text no1NameText;
    [SerializeField] public Text no1TrophySumText;
    /// <summary>
    /// 调用初始化第一名信息在顶部
    /// 创建用户实体
    /// </summary>
    public void CreateUserItem()
    {
        InitNo1Information();
        if (isCreatePrefab)
        {
            return;
        }
        isCreatePrefab = true;
        for (int i = 0; i < AnalyzeJsonData.UserMessageList.Count; i++)
        {
            GameObject newGameObject = Instantiate(userItem, contentTransform);
            UserMeesagebuttonItem U=newGameObject.GetComponent<UserMeesagebuttonItem>();
            if (i >= 3)
            {
                U.EditRankingNumberText(i + 1);
            }
            else
            {
                U.EditRankingNumberImage(i + 1);
            }
            U.Init(AnalyzeJsonData.UserMessageList[i],i);
        }
    }
    
    
    //初始化第一名信息
    public void InitNo1Information()
    {
        no1UserId.text = AnalyzeJsonData.UserMessageList[0].userId;
        no1NameText.text = AnalyzeJsonData.UserMessageList[0].userName;
        no1TrophySumText.text = AnalyzeJsonData.UserMessageList[0].trophy.ToString();
    }


    //关闭排行榜
    public void CloseBackGround()
    {
        transform.gameObject.SetActive(false);
    }
    
    /// <summary>
    ///  生产排名预置件
    /// 激活排名榜
    /// </summary>
    /// <returns></returns>
    public void OpenBackGround()
    {
        transform.gameObject.SetActive(true);
        CreateUserItem();
    }
    
    void Start()
    {
        transform.gameObject.SetActive(false);
    }
}
