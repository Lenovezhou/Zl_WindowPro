using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIVRHouseMap : TTUIPage {
    public UIVRHouseMap()
		: base(UIType.Normal, UIMode.DoNothing, UICollider.None)
    {
        uiPath = "VRHome/VRHouseMap";
    }
    public override void Awake(GameObject go)
    {
        transform.FindChild("ChoiseHouseItem").GetComponent<Button>().onClick.AddListener(ToanotherHouse);   
    }

    void ToanotherHouse()
    {
	//	ShowPage<VRpage> ();
    }
}
