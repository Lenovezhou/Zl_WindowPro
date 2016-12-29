using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System.IO;

public class UIMypro : TTUIPage {

    public UIMypro()
        : base(UIType.Normal, UIMode.HideOther, UICollider.None)
    {
        uiPath = "VRHome/MyPro";
    }
	public Dictionary<int,Object> templist = new Dictionary<int,Object>();
	List<GameObject> itemps_Pool = new List<GameObject> ();
    List<Button> buttonsDownMain = new List<Button>();
    List<Button> buttonsMM = new List<Button>();
    GameObject solutionpanle, ChoiseStylePanel, itemes, ProShowPanel, UpPanel, DownPanel;
	Button ProductButton,MyStyelButton,MyTexButton,RealenvButton,BackHomeButton
    , AllButton, ChinaButton, EuropButton, NaturalButton, TownButton, KawayiButton, RebackButton;
    Image singleshowimag;
     public override void Awake(GameObject go) 
     {
         FindChildInit();
         buttonsDownMain.Add(ProductButton);
         buttonsDownMain.Add(MyTexButton);
         buttonsDownMain.Add(RealenvButton);
         buttonsMM.Add(AllButton);
         buttonsMM.Add(ChinaButton);
         buttonsMM.Add(EuropButton);
         buttonsMM.Add(NaturalButton);
         buttonsMM.Add(TownButton);
         buttonsMM.Add(KawayiButton);
         InitButtonEvent(buttonsMM);
		itemes.SetActive (false);
		BackHomeButton.onClick.AddListener(BackHome);
        RefreshItems(Test(),true);
        ChangMMColor(buttonsMM, true);
		ProductButton.onClick.AddListener (delegate() {
			RefreshItems(Test());
		});
		MyStyelButton.onClick.AddListener (delegate() {
			RefreshItems(new List<GameObject>());
		});
		MyTexButton.onClick.AddListener (delegate() {
			RefreshItems(new List<GameObject>());
		});
		RealenvButton.onClick.AddListener (delegate() {
			RefreshItems(new List<GameObject>());
		});
        RebackButton.onClick.AddListener(Reback);
     }

     void InitButtonEvent(List<Button> lis) 
     {
         for (int i = 0; i < lis.Count; i++)
         {
             lis[i].onClick.AddListener(delegate() { ChangMMColor(buttonsMM); });
         }
     }

    /// <summary>
    /// 测试
    /// </summary>
     List<GameObject> Test() 
     {
         GameObject a = new GameObject();
         List<GameObject> templist = new List<GameObject>();
         templist.Add(a);
         templist.Add(a);
         templist.Add(a);
         return templist;
     }

	void FindChildInit()
	{
        ProShowPanel = transform.FindChild("ProShowPanel").gameObject;
        singleshowimag = ProShowPanel.transform.FindChild("ShowImage").GetComponent<Image>();
        RebackButton = ProShowPanel.transform.FindChild("RebackButton").GetComponent<Button>();
        UpPanel = transform.FindChild("UpPanel").gameObject;
        DownPanel = transform.FindChild("DownPanel").gameObject;
        itemes = UpPanel.transform.FindChild("Scroll View/Viewport/Content/Image").gameObject;
        solutionpanle = DownPanel.transform.FindChild("SolutionPanel").gameObject;
        ChoiseStylePanel = DownPanel.transform.FindChild("ChoiseStylePanel").gameObject;
		ProductButton = solutionpanle.transform.FindChild ("ProductButton").GetComponent<Button>();
		MyStyelButton = solutionpanle.transform.FindChild ("MyStyelButton").GetComponent<Button>();
		MyTexButton = solutionpanle.transform.FindChild ("MyTexButton").GetComponent<Button>();
		RealenvButton = solutionpanle.transform.FindChild ("RealenvButton").GetComponent<Button>();
		BackHomeButton = solutionpanle.transform.FindChild ("BackHomeButton").GetComponent<Button> ();
		AllButton = ChoiseStylePanel.transform.FindChild ("AllButton").GetComponent<Button> ();
		ChinaButton = ChoiseStylePanel.transform.FindChild ("ChinaButton").GetComponent<Button> ();
		EuropButton = ChoiseStylePanel.transform.FindChild ("EuropButton").GetComponent<Button> ();
		NaturalButton = ChoiseStylePanel.transform.FindChild ("NaturalButton").GetComponent<Button> ();
		TownButton = ChoiseStylePanel.transform.FindChild ("TownButton").GetComponent<Button> ();
		KawayiButton = ChoiseStylePanel.transform.FindChild ("KawayiButton").GetComponent<Button> ();
        itemes.SetActive(false);
	}
     void BackHome() 
     {
        ShowPage<UIHomePanel>();
     }


	List<GameObject> reuseitems = new List<GameObject>();
	void RefreshItems(List<GameObject> templist,bool isfirst = false)
	{
        ChangDBColor(isfirst,buttonsDownMain);
        //Debug.Log ("<color=yellow>对啦"+templist.Count+"</color>");
		reuseitems.Clear ();
		for (int i = 0; i < itemps_Pool.Count; i++)
		{
			itemps_Pool [i].SetActive (false);
		}
		for (int i = 0; i < templist.Count; i++) 
		{
			GameObject item = null;
			if (itemps_Pool.Count >= 1)
			{
				item = itemps_Pool [0];
				itemps_Pool.Remove (item);

			} 
			else 
			{
				item = GameObject.Instantiate (itemes) as GameObject;
                item.tag = "ImageShow";
                item.AddComponent<Button>().onClick.AddListener(ShowSingle);
			}
			item.SetActive (true);
			reuseitems.Add (item);
            item.GetComponent<Image>().overrideSprite = Resources.Load("modle", typeof(Sprite)) as Sprite;
			item.transform.SetParent (itemes.transform.parent);
			item.transform.localScale = Vector3.one;
			item.transform.localPosition = Vector3.zero;
           
		}
		for (int i = 0; i < reuseitems.Count; i++) 
		{
			itemps_Pool.Add (reuseitems [i]);
		}
	}

    void ChangDBColor( bool isfirst,List<Button> lis) 
    {
        GameObject tempselect = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
        if (isfirst)
        {
            tempselect = ProductButton.gameObject;
        }
        GameObject childimage = tempselect.transform.FindChild("Image").gameObject;
        childimage.SetActive(true);
        Color c = childimage.GetComponent<Image>().color;
        tempselect.GetComponentInChildren<Text>().color = c;

        for (int i = 0; i < lis.Count; i++)
        {
            if (!lis[i].name.Equals(tempselect.name))
            {
                lis[i].transform.FindChild("Image").gameObject.SetActive(false);
                lis[i].transform.GetComponentInChildren<Text>().color = Color.white;
            }
        }
       
    }

    void ChangMMColor(List<Button> lis,bool isfirst = false) 
    {
        GameObject tempselect = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
        if (isfirst)
        {
            tempselect = AllButton.gameObject;
        }
        tempselect.GetComponent<Image>().enabled = true;
        for (int i = 0; i < lis.Count; i++)
        {
            if (!lis[i].name.Equals(tempselect.name))
            {
                lis[i].GetComponent<Image>().enabled = false;
            }
        }
    }

	public override void Refresh()
	{
	//	Debug.Log ("调用Refresh");
	}

    void ShowSingle() 
    {
       // if (UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.CompareTag("ImageShow"))
       
            //跳转并关闭当前
        UpPanel.SetActive(false);
        DownPanel.SetActive(false);
        ProShowPanel.SetActive(true);
        singleshowimag.overrideSprite = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.GetComponent<Image>().overrideSprite;
     //  UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.CompareTag("ImageShow")
    }

    void Reback() 
    {
        UpPanel.SetActive(true);
        DownPanel.SetActive(true);
        ProShowPanel.SetActive(false);
    }
}
