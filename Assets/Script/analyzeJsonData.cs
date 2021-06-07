using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using SimpleJSON;

//定义实体类，用来存放Json的数据
public class UserData
{
    public string _nickName;
    public int _trophy;
}
//存放实体类的链表
public class analyzeJsonData : MonoBehaviour
{
    public static List<UserData> UserMessageList;
	public  static string _moveSpriet;
	
    public TextAsset txt;
     void Start()
     {
         _moveSpriet=txt.text;
         InitTextList ();
    }

     //解析Json，存放到List中
    public void InitTextList()
    {
        UserMessageList = new List<UserData>();
        var n = JSONNode.Parse (_moveSpriet);
        RankDinLog.countDownint = int.Parse(n["countDown"]);
        var m = n["list"];
        Debug.Log(m.Count);
        for (int i = 0; i < m.Count; i++)
        {
            UserData userData = new UserData();
            userData._nickName = m[i]["nickName"];
            userData._trophy = m[i]["trophy"];
            UserMessageList.Add(userData);
        }
    }
}








