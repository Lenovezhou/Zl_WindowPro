﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Text;

public class GameMain : MonoBehaviour
{

    public static bool isClone;
    // Use this for initialization
    void Start()
    {
        //GameObject.FindGameObjectWithTag("MainCamera").SetActive(false);
        TTUIRoot tt= TTUIRoot.Instance;
        TTUIPage.ShowPage<UILoginPanel>();
		TTUIPage.ShowPage<UILeftChoise>();
        //TTUIPage.ShowPage<UIMypro>();
    }


}
