﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using DG.Tweening;


public class UIVRpage : TTUIPage {

    public UIVRpage()
        : base(UIType.Normal, UIMode.HideOther, UICollider.None)
    {
        uiPath = "VRHome/VRPage";
    }
	List<GameObject> reuseitems = new List<GameObject>();
	List<GameObject> itemps_Pool = new List<GameObject> ();
    List<Toggle> toggles = new List<Toggle>();

    Text leftname,replacename;
    Toggle HoleToggle, BodyToggle, windmToggle, WindshaToggle, HouseMapToggle, UploadToggle, aspecktToggle, GroundToggle, WallToggle
      , BedroomToggle, LivingroomToggle;
	Button BackHomeButton, BackButton, ConfigButton, EditwindButton, EditEnviromentButton;
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
		EditwindButton.onClick.AddListener (delegate() {
			EditButtonCall(EditwindButton,EditWindPanel);});
		EditEnviromentButton.onClick.AddListener (delegate() {
			EditButtonCall(EditEnviromentButton,EditEnviroPanel);});
//         EditwindToggle.onValueChanged.AddListener(EditFlywindows);
//         EditEnviromentToggle.onValueChanged.AddListener(EditEnvir);
         aspecktToggle.onValueChanged.AddListener(RoateSelf);
         BackHomeButton.onClick.AddListener(BackHome);
         BackButton.onClick.AddListener(BackHome);
         ConfigButton.onClick.AddListener(delegate() { VRUploadPage.SetActive(false); });
         toggles.Add(HoleToggle);
         toggles.Add(BodyToggle);
         toggles.Add(windmToggle);
         toggles.Add(WindshaToggle);
         toggles.Add(GroundToggle);
         toggles.Add(WallToggle);
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
        ConfigButton = VRUploadPage.transform.FindChild("ConfigButton").GetComponent<Button>();
        VRHouseMap = transform.FindChild("VRHouseMap").gameObject;
        leftname = VRChangeStyel.transform.FindChild("ChangeName").GetComponent<Text>();
        replacename = VRChangeStyel.transform.FindChild("NameText").GetComponent<Text>();
        BedroomToggle = VRHouseMap.transform.FindChild("BedroomToggle").GetComponent<Toggle>();
        LivingroomToggle = VRHouseMap.transform.FindChild("LivingroomToggle").GetComponent<Toggle>();
		changestylepanel = transform.FindChild ("VRChangeStyel").gameObject;
		secenditemes = changestylepanel.transform.FindChild ("Scroll View/Viewport/Content/ChoiseHouseItem").gameObject;
        firstitems = ChoiseHousePanel.transform.FindChild("MainPanel/Scroll View/Viewport/Content/HouseLitItems").gameObject;
        BackHomeButton = EditHousePanel.transform.FindChild("BackHomeButton").GetComponent<Button>();
		EditwindButton = EditPanel.transform.FindChild("EditwindButton").GetComponent<Button>();
		EditEnviromentButton = EditPanel.transform.FindChild("EditEnviromentButton").GetComponent<Button>();
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
		changestylepanel.SetActive (false);
        GroundToggle.isOn = false;
        WallToggle.isOn = false;
        BedroomToggle.isOn = true;
        LivingroomToggle.isOn = false;
//		EditEnviromentButton.GetComponent<Image>().color = color
		EditwindButton.GetComponent<Image>().color = new Color(0.05f, 0.68f, 0.68f);
        firstitems.SetActive(false);
	}

    void ToBedroom(bool ison) 
    {
     //   LivingroomPanel.SetActive(!ison);
    }

	void EditButtonCall(Button b,GameObject go) 
    {
		Button nb = b == EditEnviromentButton ? EditwindButton : EditEnviromentButton;
		GameObject ngo = go == EditEnviroPanel ? EditWindPanel : EditEnviroPanel;
		b.GetComponent<Image> ().color = new Color (0.05f, 0.68f, 0.68f);
		nb.GetComponent<Image> ().color = Color.white;
		go.gameObject.SetActive(true);
		ngo.gameObject.SetActive(false);
     //   EditEnviromentToggle.isOn = !ison;
    }
//    void EditEnvir() 
//    {
//        EditEnviroPanel.SetActive(ison);
//        EditWindPanel.SetActive(!ison);
//    //    EditwindToggle.isOn = !ison;
//    }
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
        StyleAccept(ison, AlivePanel.transform);
        if (ischangstyelBig && !ison)
        {
            StyleAccept(ison, changestylepanel.transform);
            RevertToggles();
        }
    }
    void RevertToggles() 
    {
        for (int i = 0; i < toggles.Count; i++)
        {
            toggles[i].isOn = false;
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

     bool ischangstyelBig = false;
    /// <summary>
    /// 打开切换款式
    /// </summary>
     void ChangStyel(bool ison) 
     {
         StyleAccept(ison,changestylepanel.transform);
         if (ison)
         {
             ischangstyelBig = true;
             leftname.text = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.GetComponentInChildren<Text>().text;
             replacename.text = "款式";
         }
         else {
             ischangstyelBig = false;
         }
     }

     void LivingroomChangeStyel(bool ison) 
     {
         StyleAccept(ison,changestylepanel.transform);
         if (ison)
         {
             ischangstyelBig = true;
             replacename.text = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.GetComponentInChildren<Text>().text;
             leftname.text = "替换";
         }
         else {
             ischangstyelBig = false;
         }
        
     }
     void StyleAccept(bool candoscale,Transform tr) 
     {
         if (candoscale)
         {
             tr.gameObject.SetActive(candoscale);
             //tr.transform.DOScale(Vector3.one, 0.2f);
             tr.DOLocalMoveY(0, 0.2f);
//			tr.DOScaleY (1, 0.2f);
         }
         else 
         {

             tr.DOLocalMoveY(-200, 0.2f);
//			tr.DOScaleY(0,0.2f);
         }
        
     }


}
