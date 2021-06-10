using UnityEngine;
using UnityEngine.UI;
using PolyAndCode.UI;

public class DemoCell : MonoBehaviour, ICell
{
    public Text userName;
    public Text userId;
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
    private int i;
    
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
    private void Start()
    {
        //Can also be done in the inspector
        GetComponent<Button>().onClick.AddListener(ShowToastMessageClick);
    }

    //This is called from the SetCell method in DataSource
    public void ConfigureCell(ContactInfo contactInfo,int cellIndex)
    {
        if (cellIndex > AnalyzeJsonData.UserMessageList.Count-1) return;
        i = cellIndex;
        rankingNumberImage.gameObject.SetActive(false);
        rankingNumberText.text = (i+1).ToString();
        int trophy=int.Parse(AnalyzeJsonData.UserMessageList[i].trophy.ToString());
        rankingTageImage.sprite = arenaBadge[trophy/1000+1];
        userName.text = AnalyzeJsonData.UserMessageList[cellIndex].userName;
        userId.text = AnalyzeJsonData.UserMessageList[cellIndex].userId;
        userTrophyText.text = AnalyzeJsonData.UserMessageList[cellIndex].trophy.ToString();
    }
    public void ShowToastMessageClick()
    {
        ToastItem.Instance.Exit(i);
    }
}
