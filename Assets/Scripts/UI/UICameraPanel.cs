using UnityEngine;
using System.Collections;

using UnityEngine.UI;

public class UICameraPanel : TTUIPage
{
    private Transform btn_complete;
    private Transform btn_retake;
    private Transform btn_confirm;
    public override void Awake(GameObject go)
    {      
        btn_complete = transform.Find("btn_complete");
        btn_complete.GetComponent<Button>().onClick.AddListener(CompleteBtnOnClick);
        btn_retake = transform.Find("btn_retake");
        btn_retake.GetComponent<Button>().onClick.AddListener(ReTakeBtnOnClick);
        btn_confirm = transform.Find("btn_confirm");
        btn_confirm.GetComponent<Button>().onClick.AddListener(ConfirmBtnOnClick);
    }    

    public UICameraPanel()
        : base(UIType.Normal, UIMode.HideOther, UICollider.None)
    {
        uiPath = "DesignReal/CameraPanel";        
    }

    void Init()
    {      
        DisplayOrHideGo(btn_complete, true);
        DisplayOrHideGo(btn_retake, true);
        DisplayOrHideGo(btn_confirm,false);
    }   
    void CompleteBtnOnClick()
    {        
        DisplayOrHideGo(btn_complete, false);
        DisplayOrHideGo(btn_retake, false);
        //设置骨骼点
        DisplayOrHideGo(btn_confirm,true);        
    }

    void ReTakeBtnOnClick()
    {       
        Init();

        //重新拍照
    }

    void ConfirmBtnOnClick()
    {
        Init();
        ShowPage<UIPhotoEditPanel>(); 
    }

    void DisplayOrHideGo(Transform tf,bool isDisplay)
    {
        tf.gameObject.SetActive(isDisplay);       
    }
}
