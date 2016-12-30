using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIHomePanel : TTUIPage {

   
    public override void Awake(GameObject go)
    {
        this.transform.Find("btn_vr").GetComponent<Button>().onClick.AddListener(VRBtnOnClick);
        this.transform.Find("btn_photo").GetComponent<Button>().onClick.AddListener(PhotoBtnOnClick);
        this.transform.Find("btn_mine").GetComponent<Button>().onClick.AddListener(MineBtnOnClick);
    }

    public UIHomePanel()
        : base(UIType.Normal, UIMode.HideOther, UICollider.None)
    {
        uiPath = "HomePage/HomePanel";
    }

    void VRBtnOnClick()
    {
        ShowPage<UIVRpage>();
    }

    void PhotoBtnOnClick()
    {
        ShowPage<UIPhotoPanel>();
    }

    void MineBtnOnClick()
    {
        ShowPage<UIMypro>();
    }
}
