using UnityEngine;
using UnityEngine.UI;
using PolyAndCode.UI;

public class DemoCell : MonoBehaviour, ICell
{
    [SerializeField] private Text userName;
    [SerializeField] private Text userId;
    [SerializeField] private Text userNameText;
    [SerializeField] private Text userTrophyText;
    [SerializeField] private Text userIdText;
    [SerializeField] private Text rankingNumberText;
    [SerializeField] private Image rankingNumberImage;
    [SerializeField] private Image rankingTageImage;

    [SerializeField] private Sprite[] rankSprite=new Sprite[3]; 
    [SerializeField] private Sprite[] arenaBadge = new Sprite[14];
    //Model
    private ContactInfo _contactInfo;
    private UserData userData;
    
    /// <summary>
    /// 动态加载资源
    /// </summary>
    private void Awake()
    {
        for (int i = 0; i < rankSprite.Length; i++)
        {
            rankSprite[i] = Resources.Load<Sprite>("rank_"+(i+1).ToString());
        }
        for (int i = 0; i < arenaBadge.Length; i++)
        {
            arenaBadge[i] = Resources.Load<Sprite>("arenaBadge_"+(i+1).ToString()); 
        }
    }
    /// <summary>
    /// 监听点击事件
    /// </summary>
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(ShowToastMessageClick);
    }
    /// <summary>
    /// 对生成的排名榜进行赋初值
    /// 根据杯数更改段位图片
    /// </summary>
    /// <param name="cellIndex"></param>
    public void RankInit(UserData userData,int cellIndex)
    {
        this.userData = userData;
        rankingNumberImage.gameObject.SetActive(false);
        rankingNumberText.text = (cellIndex+1).ToString();
        rankingTageImage.sprite = arenaBadge[(int.Parse(userData.trophy.ToString()))/1000+1];
        userName.text = userData.userName;
        userId.text = userData.userId;
        userTrophyText.text = userData.trophy.ToString();
    }
    
    /// <summary>
    /// 点击user展示Toast，toast展示用户的信息
    /// </summary>
    public void ShowToastMessageClick()
    {
        ToastItem.Instance.Exit(userData);
    }
}
