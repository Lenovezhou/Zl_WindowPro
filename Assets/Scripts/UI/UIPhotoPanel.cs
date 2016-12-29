using UnityEngine;
using System.Collections;

using UnityEngine.UI;

public class UIPhotoPanel : TTUIPage {
    public override void Awake(GameObject go)
    {
        this.transform.Find("btn_takePhoto").GetComponent<Button>().onClick.AddListener(TakePhotoBtnOnClick);
        this.transform.Find("btn_album").GetComponent<Button>().onClick.AddListener(AlbumBtnOnClick);
        this.transform.Find("btn_return").GetComponent<Button>().onClick.AddListener(ReturnBtnOnClick);
    }

    public UIPhotoPanel()
        : base(UIType.Normal, UIMode.HideOther, UICollider.None)
    {
        uiPath = "DesignReal/PhotoPanel";
    }

    void TakePhotoBtnOnClick()
    {
        //调取手机相机  拍照后 show        
        ShowPage<UICameraPanel>();
    }

    void AlbumBtnOnClick()
    {
        //调取手机相册  选择照片后 show
        ShowPage<UICameraPanel>();
    }

    void ReturnBtnOnClick()
    {
        ShowPage<UIHomePanel>();
    }
}
