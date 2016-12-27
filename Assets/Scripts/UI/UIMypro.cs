using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class UIMypro : TTUIPage {

    public UIMypro()
        : base(UIType.Normal, UIMode.DoNothing, UICollider.None)
    {
        uiPath = "VRHome/MyPro";
    }
	public Dictionary<int,Object> templist = new Dictionary<int,Object>();
	List<GameObject> itemps_Pool = new List<GameObject> ();
	GameObject solutionpanle,ChoiseStylePanel,itemes;
	Button ProductButton,MyStyelButton,MyTexButton,RealenvButton,BackHomeButton
	,AllButton,ChinaButton,EuropButton,NaturalButton,TownButton,KawayiButton;
     public override void Awake(GameObject go) 
     {
		FindChildAsinge ();
		itemes.SetActive (false);
		BackHomeButton.onClick.AddListener(BackHome);
		ProductButton.onClick.AddListener (delegate() {
			RefreshItems(new List<GameObject>());
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
     }


	void FindChildAsinge()
	{

		itemes = transform.FindChild ("UpPanel/Scroll View/Viewport/Content/Image").gameObject;
		solutionpanle = transform.FindChild ("DownPanel/SolutionPanel").gameObject;
		ChoiseStylePanel =transform.FindChild ("DownPanel/ChoiseStylePanel").gameObject;
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

	}
     void BackHome() 
     {
        //ShowPage<>();
//		Hide ();
     }


	List<GameObject> reuseitems = new List<GameObject>();
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

	public override void Refresh()
	{
	//	Debug.Log ("调用Refresh");
	}
}
