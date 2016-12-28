using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public delegate void togglecall(bool ison);

public class UIVRpage : TTUIPage {

	public UIVRpage() : base(UIType.Normal, UIMode.HideOther, UICollider.None)
    {
        uiPath = "VRHome/VRpage";
    }
	List<GameObject> reuseitems = new List<GameObject>();
	List<GameObject> itemps_Pool = new List<GameObject> ();

    togglecall call;
    Text leftname,replacename;
    Toggle HoleToggle, BodyToggle, windmToggle, WindshaToggle, HouseMapToggle, UploadToggle, aspecktToggle, GroundToggle, WallToggle
      , BedroomToggle, LivingroomToggle, EditwindToggle, EditEnviromentToggle;
    Button BackHomeButton;
    GameObject itemes, changestylepanel, VRUploadPage, VRHouseMap, EditWindPanel, EditEnviroPanel, EditPanel, VRChangeStyel;
     public override void Awake(GameObject go) 
     {
		FindInit ();
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
     }

	void FindInit()
	{
        VRChangeStyel = transform.FindChild("VRChangeStyel").gameObject;
        EditPanel = transform.FindChild("EditPanel").gameObject;
        VRUploadPage = transform.FindChild("VRUploadPage").gameObject;
        VRHouseMap = transform.FindChild("VRHouseMap").gameObject;
        leftname = VRChangeStyel.transform.FindChild("ChangeName").GetComponent<Text>();
        replacename = VRChangeStyel.transform.FindChild("NameText").GetComponent<Text>();
        BedroomToggle = VRHouseMap.transform.FindChild("BedroomToggle").GetComponent<Toggle>();
        LivingroomToggle = VRHouseMap.transform.FindChild("LivingroomToggle").GetComponent<Toggle>();
		changestylepanel = transform.FindChild ("VRChangeStyel").gameObject;
		itemes = changestylepanel.transform.FindChild ("Scroll View/Viewport/Content/ChoiseHouseItem").gameObject;
		BackHomeButton = transform.FindChild("BackHomeButton").GetComponent<Button>();
		BackHomeButton.onClick.AddListener(BackHome);
        EditwindToggle = EditPanel.transform.FindChild("EditwindToggle").GetComponent<Toggle>();
        EditEnviromentToggle = EditPanel.transform.FindChild("EditEnviromentToggle").GetComponent<Toggle>();
		HouseMapToggle = transform.FindChild("HouseMapToggle").GetComponent<Toggle>();
        EditWindPanel = transform.FindChild("EditWindPanel").gameObject;
        EditEnviroPanel = transform.FindChild("EditEnviroPanel").gameObject;
        GroundToggle = EditWindPanel.transform.FindChild("GroundToggle").GetComponent<Toggle>();
        WallToggle = EditWindPanel.transform.FindChild("WallToggle").GetComponent<Toggle>();
        HoleToggle = EditEnviroPanel.transform.FindChild("HoleToggle").GetComponent<Toggle>();
        BodyToggle = EditEnviroPanel.transform.FindChild("BodyToggle").GetComponent<Toggle>();
        windmToggle = EditEnviroPanel.transform.FindChild("windmToggle").GetComponent<Toggle>();
        WindshaToggle = EditEnviroPanel.transform.FindChild("WindshaToggle").GetComponent<Toggle>();
        aspecktToggle = transform.FindChild("aspecktToggle").GetComponent<Toggle>();
		UploadToggle = transform.FindChild("UploadToggle").GetComponent<Toggle>();
		HoleToggle.isOn = false;
		BodyToggle.isOn = false;
		windmToggle.isOn = false;
		WindshaToggle.isOn = false;
		changestylepanel.SetActive (false);
        GroundToggle.isOn = false;
        WallToggle.isOn = false;
        BedroomToggle.isOn = true;
        LivingroomToggle.isOn = false;
        EditEnviromentToggle.isOn = false;
        EditwindToggle.isOn = true;
	}

    void ToBedroom(bool ison) 
    {
     //   LivingroomPanel.SetActive(!ison);
    }

    void EditFlywindows(bool ison) 
    {
        EditWindPanel.SetActive(ison);
        EditEnviroPanel.SetActive(!ison);
    }

    void EditEnvir(bool ison) 
    {
        EditEnviroPanel.SetActive(ison);
        EditWindPanel.SetActive(!ison);
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
         //ShowPage<>();
     }
	void RefreshItems(List<GameObject> templist)
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
				item = GameObject.Instantiate (itemes) as GameObject;
			}
			item.SetActive (true);
			reuseitems.Add (item);
			item.transform.SetParent (itemes.transform.parent);
			item.transform.localScale = Vector3.one;
			item.transform.localPosition = Vector3.zero;
		}
		for (int i = 0; i < reuseitems.Count; i++) 
		{
			itemps_Pool.Add (reuseitems [i]);
		}
	}



    /// <summary>
    /// 上传
    /// </summary>
     void Upload( bool ison) 
     {
         if (!VRUploadPage.activeSelf)
         {
             VRUploadPage.SetActive(true);
             VRHouseMap.SetActive(false);
         }
         else {
             VRUploadPage.SetActive(false);
         }
     }

    /// <summary>
    /// 户型地图
    /// </summary>
     void HouseMap( bool ison) 
     {
         if (!VRHouseMap.activeSelf)
         {
             VRHouseMap.SetActive(true);
             VRUploadPage.SetActive(false);
         }
         else {
             VRHouseMap.SetActive(false);
         }

     }
    
    /// <summary>
    /// 打开切换款式
    /// </summary>
     void ChangStyel(bool ison) 
     {
         //Debug.Log("ison"+ison);
		changestylepanel.SetActive (ison);
		if (ison) 
		{
           leftname.text = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.GetComponentInChildren<Text>().text;
           replacename.text = "款式";
        }
     }

     void LivingroomChangeStyel(bool ison) 
     {
         changestylepanel.SetActive(ison);
         if (ison)
         {
             replacename.text = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.GetComponentInChildren<Text>().text;
             leftname.text = "替换";
         }
     }
   

}
