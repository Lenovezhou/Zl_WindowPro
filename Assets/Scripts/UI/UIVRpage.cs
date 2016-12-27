using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class UIVRpage : TTUIPage {

	public UIVRpage() : base(UIType.Normal, UIMode.HideOther, UICollider.None)
    {
        uiPath = "VRHome/VRpage";
    }
	List<GameObject> reuseitems = new List<GameObject>();
	List<GameObject> itemps_Pool = new List<GameObject> ();

     Toggle HoleToggle, BodyToggle, windmToggle, WindshaToggle, HouseMapToggle, UploadToggle;
     Button  BackHomeButton;
	GameObject itemes,changestylepanel;
     public override void Awake(GameObject go) 
     {
		FindInit ();
         HoleToggle.onValueChanged.AddListener(ChangStyel);
         BodyToggle.onValueChanged.AddListener(ChangStyel);
         windmToggle.onValueChanged.AddListener(ChangStyel);
         WindshaToggle.onValueChanged.AddListener(ChangStyel);
         HouseMapToggle.onValueChanged.AddListener(HouseMap);
         UploadToggle.onValueChanged.AddListener(Upload);
     }

	void FindInit()
	{
		changestylepanel = transform.FindChild ("VRChangeStyel").gameObject;
		itemes = changestylepanel.transform.FindChild ("Scroll View/Viewport/Content/ChoiseHouseItem").gameObject;
		BackHomeButton = transform.FindChild("BackHomeButton").GetComponent<Button>();
		BackHomeButton.onClick.AddListener(BackHome);
		HouseMapToggle = transform.FindChild("HouseMapToggle").GetComponent<Toggle>();
		HoleToggle = transform.FindChild("HoleToggle").GetComponent<Toggle>();
		BodyToggle = transform.FindChild("BodyToggle").GetComponent<Toggle>();
		windmToggle = transform.FindChild("windmToggle").GetComponent<Toggle>();
		WindshaToggle= transform.FindChild("WindshaToggle").GetComponent<Toggle>();
		UploadToggle = transform.FindChild("UploadToggle").GetComponent<Toggle>();
		HoleToggle.isOn = false;
		BodyToggle.isOn = false;
		windmToggle.isOn = false;
		WindshaToggle.isOn = false;
		changestylepanel.SetActive (false);
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
		Debug.Log ("<color=yellow>对啦"+templist.Count+"</color>");
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
         if (ison)
         {
             ShowPage<UIVRUploadPage>();
         }
         else {
             ClosePage<UIVRUploadPage>();
         }
     }

    /// <summary>
    /// 户型地图
    /// </summary>
     void HouseMap( bool ison) 
     {
         if (ison)
         {
             ShowPage<UIVRHouseMap>();
         }
         else 
         {
             ClosePage<UIVRHouseMap>();
         }
     }

    /// <summary>
    /// 打开切换款式
    /// </summary>
     void ChangStyel(bool ison) 
     {
         Debug.Log("ison"+ison);
		changestylepanel.SetActive (ison);
		if (ison) 
		{
			RefreshItems (new List<GameObject> ());	
		}
     }
   

}
