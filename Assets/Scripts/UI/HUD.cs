using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour
{
    private Shop shop; 

    private bool showShopOptions, showShipStats;
    // Use this for initialization
    void Start()
    {
        shop = GetComponent<Shop>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnGUI()
    {
        float scrW = Screen.width / 16;
        float scrH = Screen.height / 9;

        float i = 0;

        if (GUI.Button(new Rect(scrW * 14, scrH * .125f, scrW * 2, scrH * .5f), "Shop Settings"))
            showShopOptions = !showShopOptions;
        if (GUI.Button(new Rect(scrW * 13.25f, scrH * .125f, scrW * .5f, scrH * .5f), ""))
            shop.showShop = !shop.showShop;
        if (showShopOptions)
        {
            i = .75f;
            if (GUI.Button(new Rect(scrW * 14, scrH * i, scrW * 2, scrH * .5f), "Free"))
            {
                shop.shopWindowState = Shop.WindowState.Free;
                shop.showShop = true;
            }
            i += .5f;
            if (GUI.Button(new Rect(scrW * 14, scrH * i, scrW * 2, scrH * .5f), "Snapped Left"))
            { shop.shopWindowState = Shop.WindowState.SnappedLeft;
                shop.showShop = true;
            }
            i += .5f;
            if (GUI.Button(new Rect(scrW * 14, scrH * i, scrW * 2, scrH * .5f), "Snapped Right"))
            { shop.shopWindowState = Shop.WindowState.SnappedRight;
                shop.showShop = true;
            }
            i += .5f;
            if (GUI.Button(new Rect(scrW * 14, scrH * i, scrW * 2, scrH * .5f), "Off"))
                shop.shopWindowState = Shop.WindowState.HiddenFree;
        }
    }
}
