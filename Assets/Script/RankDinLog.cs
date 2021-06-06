using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static System.Convert;

public class RankDinLog : MonoBehaviour
{
    public static int countDownint;
    [SerializeField] private GameObject BottomButton;
    [SerializeField] private Transform ContentTransform;
    [SerializeField] private GameObject backGround;
    [SerializeField] private Text countDown;
    [SerializeField] private GameObject openRankingView;
    [SerializeField] public GameObject userItem;
    private bool isOpenRankingView;
    
    //创建用户实体
    public void CreateUserItem()
    {
        for (int i = 0; i < analyzeJsonData.UserMessageList.Count; i++)
        {
            GameObject newGameObject = Instantiate(userItem, ContentTransform);
            UserMeesagebuttonItem U=newGameObject.GetComponent<UserMeesagebuttonItem>();
            if (i >= 3)
            {
                U.EditRankingNumberText(i + 1);
            }
            else
            {
                U.EditRankingNumberImage(i + 1);
            }

            U.Init(analyzeJsonData.UserMessageList[i].nickName,
                analyzeJsonData.UserMessageList[i].trophy.ToString());
        }
    }

    public void closeBackGround()
    {
        backGround.SetActive(false);
    }
    public void openBackGround()
    {
        backGround.SetActive(true);
        //生产排名预置件
        CreateUserItem();
    }
    
    void Start()
    {
        updateCountDowntime();
        //isOpenRankingView = true;
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
