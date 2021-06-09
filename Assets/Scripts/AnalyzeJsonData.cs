using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using SimpleJSON;

//定义实体类，用来存放Json的数据
public class UserData
{
    public string userId;
    public string userName;
    public int trophy;
}
//存放实体类的链表
public class AnalyzeJsonData : MonoBehaviour
{
    //静态链表
    public static List<UserData> UserMessageList;
    //json文件和内容
	public string jsonData;
    public TextAsset jsonTxt;
    
    //将json文件转换成string
     void Start()
     {
         jsonData=jsonTxt.text;
         InitTextList ();
    }

     //解析Json，存放到List中
    public void InitTextList()
    {
        UserMessageList = new List<UserData>();
        var n = JSONNode.Parse (jsonData);
        CountDown.countDownSecond = int.Parse(n["countDown"]);
        var m = n["list"];
        for (int i = 0; i < m.Count; i++)
        {
            UserData userData = new UserData();
            userData.userId=m[i]["uid"];
            userData.userName = m[i]["nickName"];
            userData.trophy = m[i]["trophy"];
            UserMessageList.Add(userData);
        }
        UserMessageList.Sort((x,y) =>y.trophy - x.trophy);
    }
}








