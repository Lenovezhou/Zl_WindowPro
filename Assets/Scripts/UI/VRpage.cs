using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class VRpage : TTUIPage {

	 public VRpage() : base(UIType.Normal, UIMode.HideOther, UICollider.None)
    {
        uiPath = "VRHome/VRpage";
    }

     public override void Awake(GameObject go) 
     {
         transform.FindChild("BackHomeButton").GetComponent<Button>().onClick.AddListener(BackHome);
     }
     void BackHome() 
     {
     
     }

}
