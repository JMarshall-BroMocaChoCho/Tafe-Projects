using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public Texture2D healthBar, healthBarBorder;

    public int gold, dockArmour, shipsTotal, shipsKilled, shipsLost;
    public float health = 100;

    private bool showShopOptions, showShipStats;


    // Use this for initialization
    void Start()
    {
        healthBar = Resources.Load("Textures/Red") as Texture2D;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnGUI()
    {
        float scrW = Screen.width / 16;
        float scrH = Screen.height / 9;

        GUI.Box(new Rect(scrW * 0, scrH * 0, scrW * 16.1f, scrH * .75f), "");


        GUI.DrawTexture(new Rect(scrW * 6, scrH * .125f, scrW * (health * .05f), scrH * .5f), healthBar);
        //GUI.DrawTexture(new Rect(scrW * 0, scrH * 0, scrW * 16.1f, scrH * .75f), healthBarBorder);

    }
}
