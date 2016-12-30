using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UILoginPanel : TTUIPage
{

    private string userName;
    private string passWord;
    public override void Awake(GameObject go)
    {
        this.transform.Find("loginPanel/btn_login").GetComponent<Button>().onClick.AddListener(LoginBtnOnClick);
        this.transform.Find("loginPanel/Input_userName").GetComponent<InputField>().onEndEdit.AddListener(InputUserName);
        this.transform.Find("loginPanel/Input_passWord").GetComponent<InputField>().onEndEdit.AddListener(InputPassWord);
    }

    public UILoginPanel() : base(UIType.Normal,UIMode.HideOther, UICollider.None)
    {
        uiPath = "HomePage/LoginPanel";
    }

    void InputUserName(string message)
    {
        userName = message;
    }

    void InputPassWord(string message)
    {
        passWord = message;
    }

    void LoginBtnOnClick()
    {
        //todo 帐号验证

        //登录到主界面
        ShowPage<UIHomePanel>();
    }
}
