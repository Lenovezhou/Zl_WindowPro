using UnityEngine;
using System.Collections;
using DG.Tweening;

public class UILeftChoise : TTUIPage {

	public UILeftChoise() : base(UIType.PopUp,UIMode.DoNothing, UICollider.None)
	{
		uiPath = "Mine/LeftChoise";
	}

	Vector3 selfposition;
	public override void Awake (GameObject go)
	{
		selfposition = transform.localPosition;
		Debug.Log (selfposition);
	//	transform.localPosition = new Vector3 (selfposition.x + 100, 0, 0);
	}

	public override void Refresh ()
	{
		Debug.Log ("<color=yellow><size=20>"+transform.localPosition+"<><><>"+transform.name+"</size></color>");
		transform.DOScaleX (1, 0.2f);
	}
	public override void Hide ()
	{
//		transform.localPosition = new Vector3 (selfposition.x + 100, 0, 0);
		transform.DOScaleX(0,0.2f);
		Debug.Log ("<color=yellow><size=20>HideMe"+transform.localPosition+"</size></color>");
	}
}
