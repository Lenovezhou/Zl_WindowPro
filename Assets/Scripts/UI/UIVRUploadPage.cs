using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIVRUploadPage : TTUIPage {

    public UIVRUploadPage()
        : base(UIType.Normal, UIMode.DoNothing, UICollider.None)
    {
        uiPath = "VRHome/VRUploadPage";
    }

    public override void Awake(GameObject go)
    {
        transform.FindChild("ConfigButton").GetComponent<Button>().onClick.AddListener(Hide);

    }

    //void HideME() 
    //{
    //    Hide();
    //}

}
