using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public GameObject[] ship;
    public GameObject spawnEffect, lastSpawned;
    public Transform spawn01, spawn02;

    public bool showShop;

    private Rect[,] shopWindow = new Rect[3,2];

    private int shopXSize, shopYSize;
    private float scrW = Screen.width / 16;
    private float scrH = Screen.height / 9;
    private float shopH;
    [Range (0,2)]
    private int i_Rect, i_type;

    public UnitManager unit_M;
    
    public WindowState shopWindowState;
    public enum WindowState
    {
        Free,
        HiddenFree,
        SnappedLeft,
        HiddenLeft,
        SnappedRight,
        HiddenRight
    }

    // Use this for initialization
    void Start()
    {
        unit_M = FindObjectOfType<UnitManager>();

        shopWindow[0, 0] = new Rect(scrW * 0, scrH * .75f, scrW * 4, scrH * 7f);
        // [0,1] is not set
        shopWindow[1, 0] = new Rect(scrW * 0, scrH * .75f, scrW * 4, scrH * 7f);
        shopWindow[1, 1] = new Rect(scrW * -4, scrH * .75f, scrW * 4, scrH * 7f);
        shopWindow[2, 0] = new Rect(scrW * 12.1f, scrH * .75f, scrW * 4, scrH * 7f);
        shopWindow[2, 1] = new Rect(scrW * 16.1f, scrH * .75f, scrW * 4, scrH * 7f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnGUI()
    {
        if (showShop)
        {
            switch (shopWindowState)
            {
                case WindowState.Free:
                    shopWindow[0, 0] = ClampToScreen(GUI.Window(0, shopWindow[0, 0], ShopWindow, ""));
                    break;
                case WindowState.HiddenFree:
                    break;
                case WindowState.SnappedLeft:
                    shopWindow[0, 0] = ClampToScreen(GUI.Window(0, shopWindow[1, 0], ShopWindow, ""));
                    break;
                case WindowState.HiddenLeft:
                    shopWindow[0, 0] = ClampToScreen(GUI.Window(0, shopWindow[1, 1], ShopWindow, ""));
                    break;
                case WindowState.SnappedRight:
                    shopWindow[0, 0] = ClampToScreen(GUI.Window(0, shopWindow[2, 0], ShopWindow, ""));
                    break;
                case WindowState.HiddenRight:
                    shopWindow[0, 0] = ClampToScreen(GUI.Window(0, shopWindow[2, 1], ShopWindow, ""));
                    break;
            }
        }
    }

    void ShopWindow(int windowID)
    {
        if (GUI.Button(new Rect(scrW * .25f, scrH * 5f, scrW * .5f, scrH * 1f), "<"))
        {
            if (i_type > 0)
            { i_type--; }
        }// Switch an index
        if (GUI.Button(new Rect(scrW * 1f,scrH * 4.5f, scrW * 2f, scrH * 2f),"Spawn"))
        {
            // Switch the type of ship to buy
            SpawnShip();
        }
        if (GUI.Button(new Rect(scrW * 3.25f, scrH * 5f, scrW * .5f, scrH * 1f), ">"))
        {
            if (i_type < ship.Length)
            { i_type++; }
        }// Switch an Index

        GUI.DragWindow();
    }

    Rect ClampToScreen(Rect r)
    {
        r.x = Mathf.Clamp(r.x, 0, Screen.width - r.width);
        r.y = Mathf.Clamp(r.y, 0, Screen.height - r.height);
        return r;
    }

    void SpawnShip()
    {
        StartCoroutine(SpawnEffect());
        GameObject clone = Instantiate(ship[i_type], spawn01.position, Quaternion.identity);
        lastSpawned = clone;
        unit_M.units.Add(lastSpawned);   
    }

    void PlayEffect()

    {
        // Create a copy of our explosionPrefab
        GameObject clone = Instantiate(spawnEffect, spawn01.position, Quaternion.identity);

        // Play the particle system
        ParticleSystem effect = clone.GetComponent<ParticleSystem>();
        effect.Play();
        // Destroy after play
        //Destroy(explosionPrefab);
    }

    IEnumerator SpawnEffect()
    {
        PlayEffect();
        // Delay to play particle system
        yield return new WaitForSeconds(2);
        Debug.Log("DONE");
        // Destroy Object
       // Destroy(gameObject);
    }
}
