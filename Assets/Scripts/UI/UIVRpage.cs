using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using DG.Tweening;

public delegate void togglecall(bool ison);

public class UIVRpage : TTUIPage {

    public UIVRpage()
        : base(UIType.Normal, UIMode.HideOther, UICollider.None)
    {
        uiPath = "VRHome/VRPage";
    }
	List<GameObject> reuseitems = new List<GameObject>();
	List<GameObject> itemps_Pool = new List<GameObject> ();
	List<Toggle> toggles = new List<Toggle> ();

	bool isChangStyelBig = false;
    togglecall call;
    Text leftname,replacename;
	InputField InputField;
    Toggle HoleToggle, BodyToggle, windmToggle, WindshaToggle, HouseMapToggle, UploadToggle, aspecktToggle, GroundToggle, WallToggle
      , BedroomToggle, LivingroomToggle, EditwindToggle, EditEnviromentToggle;
    Button BackHomeButton, BackButton,ConfigButton;
    GameObject secenditemes,firstitems ,changestylepanel, VRUploadPage, VRHouseMap, EditWindPanel
        , EditEnviroPanel, EditPanel, VRChangeStyel, EditHousePanel, ChoiseHousePanel, AlivePanel;
     public override void Awake(GameObject go) 
     {
		FindInit ();
        RefreshItems(Test(),firstitems);
         HoleToggle.onValueChanged.AddListener(ChangStyel);
         BodyToggle.onValueChanged.AddListener(ChangStyel);
         windmToggle.onValueChanged.AddListener(ChangStyel);
         WindshaToggle.onValueChanged.AddListener(ChangStyel);
         HouseMapToggle.onValueChanged.AddListener(HouseMap);
         UploadToggle.onValueChanged.AddListener(Upload);
         BedroomToggle.onValueChanged.AddListener(ToBedroom);
         LivingroomToggle.onValueChanged.AddListener(ToLivingroom);
         GroundToggle.onValueChanged.AddListener(LivingroomChangeStyel);
         WallToggle.onValueChanged.AddListener(LivingroomChangeStyel);
         EditwindToggle.onValueChanged.AddListener(EditFlywindows);
         EditEnviromentToggle.onValueChanged.AddListener(EditEnvir);
         aspecktToggle.onValueChanged.AddListener(RoateSelf);
		BackHomeButton.onClick.AddListener(BackHome);
		BackButton.onClick.AddListener(BackHome);
		ConfigButton.onClick.AddListener (delegate() 
			{VRUploadPage.transform.DOScale(Vector3.zero,0.2f);
				UploadToggle.isOn = false;
			});
		toggles.Add (HoleToggle);
		toggles.Add (BodyToggle);
		toggles.Add (windmToggle);
		toggles.Add (WindshaToggle);
		toggles.Add (GroundToggle);
		toggles.Add (WallToggle);
     }

    /// <summary>
    /// 测试
    /// </summary>
     List<GameObject> Test() 
     {
         List<GameObject> temp = new List<GameObject>();
         GameObject a = new GameObject();
         temp.Add(a);
         temp.Add(a);
         temp.Add(a);
         temp.Add(a);
         return temp;
     }

	void FindInit()
	{
        AlivePanel = transform.FindChild("AlivePanel").gameObject;
        ChoiseHousePanel = transform.FindChild("ChoiseHousePanel").gameObject;
        EditHousePanel = AlivePanel.transform.FindChild("EditHousePanel").gameObject;
        BackButton = ChoiseHousePanel.transform.FindChild("BackButton").GetComponent<Button>();
        VRChangeStyel = transform.FindChild("VRChangeStyel").gameObject;
        EditPanel = EditHousePanel.transform.FindChild("EditPanel").gameObject;
        VRUploadPage = transform.FindChild("VRUploadPage").gameObject;
		ConfigButton = VRUploadPage.transform.FindChild ("ConfigButton").GetComponent<Button> ();
		InputField = VRUploadPage.transform.FindChild ("InputField").GetComponent<InputField> ();
        VRHouseMap = transform.FindChild("VRHouseMap").gameObject;
        leftname = VRChangeStyel.transform.FindChild("ChangeName").GetComponent<Text>();
        replacename = VRChangeStyel.transform.FindChild("NameText").GetComponent<Text>();
        BedroomToggle = VRHouseMap.transform.FindChild("BedroomToggle").GetComponent<Toggle>();
        LivingroomToggle = VRHouseMap.transform.FindChild("LivingroomToggle").GetComponent<Toggle>();
		changestylepanel = transform.FindChild ("VRChangeStyel").gameObject;
		secenditemes = changestylepanel.transform.FindChild ("Scroll View/Viewport/Content/ChoiseHouseItem").gameObject;
        firstitems = ChoiseHousePanel.transform.FindChild("MainPanel/Scroll View/Viewport/Content/HouseLitItems").gameObject;
        BackHomeButton = EditHousePanel.transform.FindChild("BackHomeButton").GetComponent<Button>();
        EditwindToggle = EditPanel.transform.FindChild("EditwindToggle").GetComponent<Toggle>();
        EditEnviromentToggle = EditPanel.transform.FindChild("EditEnviromentToggle").GetComponent<Toggle>();
        HouseMapToggle = EditHousePanel.transform.FindChild("HouseMapToggle").GetComponent<Toggle>();
        EditWindPanel = AlivePanel.transform.FindChild("EditWindPanel").gameObject;
        EditEnviroPanel = AlivePanel.transform.FindChild("EditEnviroPanel").gameObject;
        GroundToggle = EditWindPanel.transform.FindChild("GroundToggle").GetComponent<Toggle>();
        WallToggle = EditWindPanel.transform.FindChild("WallToggle").GetComponent<Toggle>();
        HoleToggle = EditEnviroPanel.transform.FindChild("HoleToggle").GetComponent<Toggle>();
        BodyToggle = EditEnviroPanel.transform.FindChild("BodyToggle").GetComponent<Toggle>();
        windmToggle = EditEnviroPanel.transform.FindChild("windmToggle").GetComponent<Toggle>();
        WindshaToggle = EditEnviroPanel.transform.FindChild("WindshaToggle").GetComponent<Toggle>();
        aspecktToggle = transform.FindChild("aspecktToggle").GetComponent<Toggle>();
        UploadToggle = EditHousePanel.transform.FindChild("UploadToggle").GetComponent<Toggle>();
		HoleToggle.isOn = false;
		BodyToggle.isOn = false;
		windmToggle.isOn = false;
		WindshaToggle.isOn = false;
		//changestylepanel.SetActive (false);
        GroundToggle.isOn = false;
        WallToggle.isOn = false;
        BedroomToggle.isOn = true;
        LivingroomToggle.isOn = false;
        EditEnviromentToggle.isOn = false;
        EditwindToggle.isOn = true;
        firstitems.SetActive(false);
		changestylepanel.transform.localScale = Vector3.zero;
		VRHouseMap.transform.localScale = Vector3.zero;
		VRUploadPage.transform.localScale = Vector3.zero;
	}

    void ToBedroom(bool ison) 
    {
     //   LivingroomPanel.SetActive(!ison);
    }

    void EditFlywindows(bool ison) 
    {
        EditWindPanel.SetActive(ison);
        EditEnviroPanel.SetActive(!ison);
        EditEnviromentToggle.isOn = !ison;
    }
    void EditEnvir(bool ison) 
    {
        EditEnviroPanel.SetActive(ison);
        EditWindPanel.SetActive(!ison);
        EditwindToggle.isOn = !ison;
    }

    void ToLivingroom(bool ison) 
    {
   //     BedroomPanel.SetActive(!ison);
    }
    /// <summary>
    /// 返回到主页
    /// </summary>
     void BackHome() 
     {
         ShowPage<UIHomePanel>();
     }

     public override void Refresh()
     {
         ShowHouseAll(false);
     }

	void RefreshItems(List<GameObject> templist,GameObject prefab)
	{
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
                item = GameObject.Instantiate(prefab) as GameObject;
			}
			item.SetActive (true);
			reuseitems.Add (item);
            item.transform.SetParent(prefab.transform.parent);
            item.GetComponent<Image>().overrideSprite = Resources.Load("modle",typeof(Sprite)) as Sprite;
            item.AddComponent<Button>().onClick.AddListener(delegate() { ShowHouseAll(true); });
			item.transform.localScale = Vector3.one;
			item.transform.localPosition = Vector3.zero;
		}
		for (int i = 0; i < reuseitems.Count; i++) 
		{
			itemps_Pool.Add (reuseitems [i]);
		}
	}

    void ShowHouseAll(bool isnext)
    {
        ChoiseHousePanel.SetActive(!isnext);
        EditHousePanel.SetActive(isnext);
        EditWindPanel.SetActive(isnext);
        aspecktToggle.gameObject.SetActive(isnext);
    }

    /// <summary>
    /// 沿自身旋转
    /// </summary>
    /// <param name="ison"></param>
    void RoateSelf(bool ison) 
    {
        aspecktToggle.transform.Rotate(0, 0, 180);
		ScaleBorn (AlivePanel.transform, ison);
		if (isChangStyelBig && !ison)
		{
			ScaleBorn (changestylepanel.transform, ison);
			RevertToggles ();
		}

    }
	void RevertToggles()
	{
		for (int i = 0; i < toggles.Count; i++)
		{
			toggles [i].isOn = false;
		}
	}

    /// <summary>
    /// 上传
    /// </summary>
     void Upload( bool ison) 
     {
		ScaleBorn (VRUploadPage.transform, ison);
		if (ison) 
		{
			HouseMapToggle.isOn = !ison;
		}
	//	HouseMapToggle.isOn = !ison;
     }

    /// <summary>
    /// 户型地图
    /// </summary>
     void HouseMap( bool ison) 
     {
		ScaleBorn (VRHouseMap.transform, ison);
		if (ison) 
		{
			UploadToggle.isOn = !ison;
		}

     }
    
    /// <summary>
    /// 打开切换款式
    /// </summary>
     void ChangStyel(bool ison) 
     {
		ScaleBorn (changestylepanel.transform, ison);
         if (ison)
         {
             leftname.text = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.GetComponentInChildren<Text>().text;
             replacename.text = "款式";
         }
       
     }

     void LivingroomChangeStyel(bool ison) 
     {
		ScaleBorn (changestylepanel.transform,ison);
         if (ison)
         {
             replacename.text = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.GetComponentInChildren<Text>().text;
             leftname.text = "替换";
         }
     }
	void ScaleBorn(Transform tr,bool b)
	{
		if (b) {
			tr.DOScale (Vector3.one, 0.2f);
		} else 
		{
			tr.DOScale (Vector3.zero, 0.2f);
		}
		if (tr.Equals(changestylepanel.transform)) 
		{
			if (b) {
				isChangStyelBig = true;
			} else {
				isChangStyelBig = false;
			}
		}
	}

}
