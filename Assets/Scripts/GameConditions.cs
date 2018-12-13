using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameConditions : MonoBehaviour
{
    public float timer = 0;
    public bool GameOver, YouWin;
    // Use this for initialization
    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 60)
        {
            YouWin = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            GameOver = true;
        }
    }

    private void OnGUI()
    {
        float scrW = Screen.width / 16;
        float scrH = Screen.height / 9;
        GUI.Label(new Rect(scrW * 3, scrH, scrW, scrH),"Timer:" + timer);

        if (YouWin)
        {
            GUI.Label(new Rect(scrW * 3, scrH * 0.5f, scrW * 6, scrH * 4), "YOU WIN");
            if (GUI.Button(new Rect(scrW * 7,scrH * 4,scrW, scrH * 0.5f),"Play Again"))
            {
                SceneManager.LoadScene(0);
            }
            Time.timeScale = 0;
        }
        if (GameOver)
        {
            GUI.Label(new Rect(scrW * 3, scrH * 0.5f, scrW * 6, scrH * 4), "GAME OVER");
            if (GUI.Button(new Rect(scrW * 7, scrH * 4, scrW, scrH * 0.5f), "Play Again"))
            {
                SceneManager.LoadScene(0);
            }
            Time.timeScale = 0;
        }
    }
}
