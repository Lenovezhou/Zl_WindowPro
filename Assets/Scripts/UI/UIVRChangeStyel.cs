using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIVRChangeStyel : TTUIPage {

    public UIVRChangeStyel()
        : base(UIType.Normal, UIMode.DoNothing, UICollider.None)
    {
        uiPath = "VRHome/VRChangeStyel";
    }


    public override void Awake(GameObject go) 
    {
             
    }

   
}
