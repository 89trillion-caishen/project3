using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static System.Convert;

public class RankDinLog : MonoBehaviour
{
    private bool _isCreatePrefab=false;
    public static int countDownint;
    [SerializeField] private Transform contentTransform;
    [SerializeField] private GameObject backGround;
    [SerializeField] private Text countDown;
    [SerializeField] public GameObject userItem;

    //创建用户实体
    public void CreateUserItem()
    {
        if (_isCreatePrefab)
        {
            return;
        }
        _isCreatePrefab = true;
        for (int i = 0; i < analyzeJsonData.UserMessageList.Count; i++)
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
            U.Init(i,analyzeJsonData.UserMessageList[i]._nickName,
                analyzeJsonData.UserMessageList[i]._trophy.ToString());
        }
    }
    
    //关闭排行榜
    public void CloseBackGround()
    {
        backGround.SetActive(false);
    }
    public void OpenBackGround()
    {
        backGround.SetActive(true);
        //生产排名预置件
        CreateUserItem();
    }
    
    void Start()
    {
        updateCountDowntime();
        backGround.SetActive(false);
    }

    public int count = 0;
    void Update()
    {
        count++;
        if (count == 250)
        {
            count = 0;
            updateCountDowntime();
        }
    }
    
    //倒计时函数
    public void updateCountDowntime()
    {
        countDownint--;
        int _day = (int)countDownint / 86400;
        int _hour = (int) countDownint / 3600 / 60;
        int _minute = (int)countDownint % 3600 / 60;
        int _second = (int)countDownint % 3600 % 60;
        countDown.text = string.Format("活动倒计时:{0}天{1}小时{2}分{3}秒", _day, _hour, _minute, _second);
    }
}
