using UnityEngine;
using System.Collections;

using UnityEngine.UI;

public class UICameraPanel : TTUIPage
{

    private Transform btn_takePhoto;
    private Transform btn_complete;
    private Transform btn_retake;
    private Transform btn_confirm;
    public override void Awake(GameObject go)
    {
        btn_takePhoto = transform.Find("btn_takePhoto");
        btn_takePhoto.GetComponent<Button>().onClick.AddListener(TakePhotoBtnOnClick);
        btn_complete = transform.Find("btn_complete");
        btn_complete.GetComponent<Button>().onClick.AddListener(CompleteBtnOnClick);
        btn_retake = transform.Find("btn_retake");
        btn_retake.GetComponent<Button>().onClick.AddListener(ReTakeBtnOnClick);
        btn_confirm = transform.Find("btn_confirm");
        btn_confirm.GetComponent<Button>().onClick.AddListener(ConfirmBtnOnClick);
    }

    public UICameraPanel() : base(UIType.Normal,UIMode.HideOther,UICollider.None)
    {
        uiPath = "HomePage/CameraPanel";
    }

    void TakePhotoBtnOnClick()
    {
        //1.图片放入rawimage

        //2.隐藏按钮 显示 complete and retake
        DisplayOrHideGo(btn_takePhoto,true);
        DisplayOrHideGo(btn_complete,false);
        DisplayOrHideGo(btn_retake,false);
    }

    void CompleteBtnOnClick()
    {
        DisplayOrHideGo(btn_complete, true);
        DisplayOrHideGo(btn_retake, true);
    }

    void ReTakeBtnOnClick()
    {
        DisplayOrHideGo(btn_takePhoto, true);
        DisplayOrHideGo(btn_complete, false);
        DisplayOrHideGo(btn_retake, false);
    }

    void ConfirmBtnOnClick()
    {
        //showpage 
    }

    void DisplayOrHideGo(Transform tf,bool isHide)
    {        
        tf.gameObject.SetActive(isHide);       
    }

}
