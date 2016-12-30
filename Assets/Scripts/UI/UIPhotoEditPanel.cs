using UnityEngine;
using System.Collections;
using System.Text;
using DG.Tweening;
using JetBrains.Annotations;
using UnityEngine.UI;

public class UIPhotoEditPanel : TTUIPage
{

    private Transform toggle;
    private Transform bottomPanel;
    private Transform storagePanel;
    private Text storageText;

    private Transform confirmPanel;

    private Button btn_curtain;
    private Image img_curtain;
    private Transform curtainPanel;
    private Button btn_scene;
    private Image img_scene;
    private Transform scenePanel;

    public override void Awake(GameObject go)
    {
        Toggle to;
        toggle = transform.Find("Toggle");
        to =toggle.GetComponent<Toggle>();
        to.onValueChanged.AddListener(delegate { ToggleOnClick(to.isOn, to.transform); });
        
        
        bottomPanel = transform.Find("BottomPanel");
        btn_curtain = bottomPanel.Find("btn_curtain").GetComponent<Button>();
        img_curtain = bottomPanel.Find("btn_curtain").GetComponent<Image>();
        btn_curtain.onClick.AddListener(CurtainEdit);
        curtainPanel = bottomPanel.Find("curtainPanel");

        btn_scene = bottomPanel.Find("btn_scene").GetComponent<Button>();
        img_scene = bottomPanel.Find("btn_scene").GetComponent<Image>();
        btn_scene.onClick.AddListener(SceneEdit);
        scenePanel = bottomPanel.Find("scenePanel");

        Toggle to1;
        to1 = bottomPanel.Find("scenePanel/tog_ground").GetComponent<Toggle>();
        to1.onValueChanged.AddListener(delegate{ OnClick(to1.isOn, "地面"); });
        Toggle to2;
        to2 = bottomPanel.Find("scenePanel/tog_wall").GetComponent<Toggle>();
        to2.onValueChanged.AddListener(delegate { OnClick(to2.isOn, "墙面"); });
        Toggle to3;
        to3 = bottomPanel.Find("scenePanel/tog_furniture").GetComponent<Toggle>();
        to3.onValueChanged.AddListener(delegate { OnClick(to3.isOn, "家具装饰"); });
        Toggle to4;
        to4 = bottomPanel.Find("curtainPanel/tog_zhengti").GetComponent<Toggle>();
        to4.onValueChanged.AddListener(delegate { OnClick(to4.isOn, "窗帘款式"); });
        Toggle to5;
        to5 = bottomPanel.Find("curtainPanel/tog_lianshen").GetComponent<Toggle>();
        to5.onValueChanged.AddListener(delegate { OnClick(to5.isOn, "窗身款式"); });
        Toggle to6;
        to6= bottomPanel.Find("curtainPanel/tog_chuangman").GetComponent<Toggle>();
        to6.onValueChanged.AddListener(delegate { OnClick(to6.isOn, "窗幔款式"); });
        Toggle to7;
        to7 = bottomPanel.Find("curtainPanel/tog_chuangsha").GetComponent<Toggle>();
        to7.onValueChanged.AddListener(delegate { OnClick(to7.isOn, "窗纱款式"); });


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

    void ToggleOnClick(bool isOn,Transform tf)
    {
        if (isOn)
        {
            bottomPanel.gameObject.SetActive(true);
            tf.Rotate(0,0,180);
            
        }
        else
        {
            tf.Rotate(0, 0, 180);
            bottomPanel.gameObject.SetActive(false);
        }
    }

    void CurtainEdit()
    {
        //变色
        img_curtain.color = new Color(0.05f, 0.68f, 0.68f);
        img_scene.color = Color.white;              
        //更改界面
        curtainPanel.gameObject.SetActive(true);
        scenePanel.gameObject.SetActive(false);
    }

    void SceneEdit()
    {
        img_curtain.color = Color.white;
        img_scene.color = new Color(0.05f, 0.68f, 0.68f);        

        curtainPanel.gameObject.SetActive(false);
        scenePanel.gameObject.SetActive(true);
    }

    void OnClick(bool isOn, string title)
    {
        storagePanel.gameObject.SetActive(isOn);
        if (isOn)
        {
            InitStorageInfo(title);         
        }       
   }    
    //#region   ssss
    //void GroundBtnOnClick(bool isOn)
    //{
    //    if (isOn)
    //    {
    //        storagePanel.DOScale(Vector3.one, 0.2f);
    //        InitStorageInfo("地面");
    //    }
    //    else
    //    {
    //        storagePanel.DOScale(Vector3.zero, 0.2f);
    //    }
    //}

    //void WallBtnOnClick(bool isOn)
    //{
    //    if (isOn)
    //    {
    //        storagePanel.DOScale(Vector3.one, 0.2f);
    //        InitStorageInfo("墙面");
    //    }
    //    else
    //    {
    //        storagePanel.DOScale(Vector3.zero, 0.2f);
    //    }
    //}

    //void FurnitureBtnOnClick(bool isOn)
    //{
    //    if (isOn)
    //    {
    //        storagePanel.DOScale(Vector3.one, 0.2f);
    //        InitStorageInfo("家具装饰");
    //    }
    //    else
    //    {
    //        storagePanel.DOScale(Vector3.zero, 0.2f);
    //    }
    //}

    //void ZhengtiBtnOnClick(bool isOn)
    //{

    //}

    //void ZhengtiBtnOnClick(bool isOn)
    //{

    //}

    //void ZhengtiBtnOnClick(bool isOn)
    //{

    //}

    //void ZhengtiBtnOnClick(bool isOn)
    //{

    //}
    //#endregion
    
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
