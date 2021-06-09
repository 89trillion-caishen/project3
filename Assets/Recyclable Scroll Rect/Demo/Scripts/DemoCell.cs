using UnityEngine;
using UnityEngine.UI;
using PolyAndCode.UI;

//Cell class for demo. A cell in Recyclable Scroll Rect must have a cell class inheriting from ICell.
//The class is required to configure the cell(updating UI elements etc) according to the data during recycling of cells.
//The configuration of a cell is done through the DataSource SetCellData method.
//Check RecyclableScrollerDemo class
public class DemoCell : MonoBehaviour, ICell
{
    //UI
    // public Text nameLabel;
    // public Text genderLabel;
    // public Text idLabel;
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
        //_contactInfo = contactInfo;
        // if (i < 3)
        // {
        //     rankingNumberText.gameObject.SetActive(false);
        //     rankingNumberImage.sprite = rankSprite[i];
        //     //rankingNumberImage.GetComponent<Image>().SetNativeSize();
        // }
        // else
        // {
        //}
            rankingNumberImage.gameObject.SetActive(false);
            rankingNumberText.text = (i+1).ToString();
        
        int trophy=int.Parse(AnalyzeJsonData.UserMessageList[i].trophy.ToString());
        rankingTageImage.sprite = arenaBadge[trophy/1000+1];
        userName.text = AnalyzeJsonData.UserMessageList[cellIndex].userName;
        userId.text = AnalyzeJsonData.UserMessageList[cellIndex].userId;
        userTrophyText.text= AnalyzeJsonData.UserMessageList[cellIndex].trophy.ToString();
        // nameLabel.text = contactInfo.Name;
        // genderLabel.text = contactInfo.Gender;
        // idLabel.text = contactInfo.id;
    }
    public void ShowToastMessageClick()
    {
        ToastItem.Instance.Exit(i);
    }
}
