using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Text;

public class GameMain : MonoBehaviour
{

    public static bool isClone;
    // Use this for initialization
    void Start()
    {
        TTUIRoot tt= TTUIRoot.Instance;
        TTUIPage.ShowPage<UIVRpage>();
//        TTUIPage.ShowPage<UIMypro>();
    }

    // Update is called once per frame
    void Update()
    {

    }

}
