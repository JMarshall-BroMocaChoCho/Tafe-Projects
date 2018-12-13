using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundManager : MonoBehaviour
{

    public bool roundOver;
    public int round = 0;

    public int enemysToSpawn = 5;

    private EnemyManager enemy_Mngr;

    // Use this for initialization
    void Start()
    {
        enemy_Mngr = GetComponent<EnemyManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void IncreaseWave()
    {

    }

    void CountDownToNextWave()
    {

    }

    void StartNextWave()
    {

    }

    void LoadWave()
    {

    }
}
