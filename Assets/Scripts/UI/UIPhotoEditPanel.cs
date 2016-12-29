using UnityEngine;
using System.Collections;
using System.Text;
using DG.Tweening;
using UnityEngine.UI;

public class UIPhotoEditPanel : TTUIPage
{

    private Transform toggle;
    private Transform bottomPanel;
    private Transform storagePanel;
    private Text storageText;

    private Transform confirmPanel;

    public override void Awake(GameObject go)
    {
        toggle = transform.Find("Toggle");
        toggle.GetComponent<Toggle>().onValueChanged.AddListener(ToggleOnClick);
        
        bottomPanel = transform.Find("BottomPanel");
        bottomPanel.Find("btn_curtain").GetComponent<Button>().onClick.AddListener(CurtainEdit);
        bottomPanel.Find("btn_scene").GetComponent<Button>().onClick.AddListener(SceneEdit);
        bottomPanel.Find("tog_ground").GetComponent<Toggle>().onValueChanged.AddListener(GroundBtnOnClick);
        bottomPanel.Find("tog_wall").GetComponent<Toggle>().onValueChanged.AddListener(WallBtnOnClick);
        bottomPanel.Find("tog_furniture").GetComponent<Toggle>().onValueChanged.AddListener(FurnitureBtnOnClick);
        bottomPanel.Find("btn_home").GetComponent<Button>().onClick.AddListener(HomeBtnOnClick);
        bottomPanel.Find("btn_save").GetComponent<Button>().onClick.AddListener(SaveBtnOnClick);
        
        storagePanel = transform.Find("StoragePanel");
        storageText = storagePanel.Find("txt_title").GetComponent<Text>();

        confirmPanel = transform.Find("confirmPanel");
        confirmPanel.Find("btn_confirm").GetComponent<Button>().onClick.AddListener(ConfirmBtnOnClick);
    }

    void InitStorageInfo(string title)
    {
        StringBuilder sb=new StringBuilder();
        for (int i = 0; i < title.Length; i++)
        {
            sb.Append(title[i]);
            if (i!=title.Length-1)
            {
                sb.Append('\n');
            }            
        }
        storageText.text = sb.ToString();
    }

    public UIPhotoEditPanel()
        : base(UIType.Normal, UIMode.HideOther, UICollider.None)
    {
        uiPath = "DesignReal/PhotoEditPanel";
    }

    void ToggleOnClick(bool isOn)
    {
        if (isOn)
        {
            bottomPanel.gameObject.SetActive(true);
            bottomPanel.DOScale(Vector3.one, 0.2f);
        }
        else
        {
            bottomPanel.DOScale(Vector3.zero, 0.2f);

        }
    }

    void CurtainEdit()
    {
        
    }

    void SceneEdit()
    {
        
    }

    void GroundBtnOnClick(bool isOn)
    {
        if (isOn)
        {
            storagePanel.DOScale(Vector3.one, 0.2f);
            InitStorageInfo("地面");
        }
        else
        {
            storagePanel.DOScale(Vector3.zero, 0.2f);
        }
    }

    void WallBtnOnClick(bool isOn)
    {
        if (isOn)
        {
            storagePanel.DOScale(Vector3.one, 0.2f);
            InitStorageInfo("墙面");
        }
        else
        {
            storagePanel.DOScale(Vector3.zero, 0.2f);
        }
    }

    void FurnitureBtnOnClick(bool isOn)
    {
        if (isOn)
        {
            storagePanel.DOScale(Vector3.one, 0.2f);
            InitStorageInfo("家具装饰");
        }
        else
        {
            storagePanel.DOScale(Vector3.zero, 0.2f);
        }
    }

    void HomeBtnOnClick()
    {
        ShowPage<UIHomePanel>();
    }

    void SaveBtnOnClick()
    {
        confirmPanel.DOScale(Vector3.one, 0.2f);
        //todo 截图保存至我的设计
    }

    void ConfirmBtnOnClick()
    {
        confirmPanel.DOScale(Vector3.zero, 0.2f);
    }



}
