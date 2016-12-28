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
        uiPath = "HomePage/PhotoPanel";
    }

    void TakePhotoBtnOnClick()
    {
        
    }

    void AlbumBtnOnClick()
    {
        
    }

    void ReturnBtnOnClick()
    {
        ShowPage<UIHomePanel>();
    }
}
