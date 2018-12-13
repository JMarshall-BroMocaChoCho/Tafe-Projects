using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] enemyType;
    
    public bool spawning;
    public int i_count, waveNum = 5;

    private GameObject[] battlePostions;

    private float timer = 2, resetimer = 2;

    private void Awake()
    {
        battlePostions = GameObject.FindGameObjectsWithTag("EnemySpawn");
        spawning = true;
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (spawning)
        {
            SpawnWave();
        }
    }

    void SpawnEnemy(int type)
    {
        Instantiate(enemyType[0], battlePostions[Random.Range(0, battlePostions.Length)].transform.position, new Quaternion(0,-90,0,0));
    }

    void SpawnWave()
    {
        if (timer <= 0)
        {
            SpawnEnemy(0);
            i_count++;
            timer = resetimer;
        }
        else
        {
            timer -= Time.deltaTime;
        }

        if (i_count >= waveNum)
        {
            spawning = false;
        }
    }
}
