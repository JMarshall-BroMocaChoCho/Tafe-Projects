using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour
{
    public GameObject[] targets;

    public float health = 100;

    private EnemyDirector enemyDirector;

    private void Awake() // Runs on start no matter whether disbled or not
    {

    }

    void Start() // On START
    {
        targets = GameObject.FindGameObjectsWithTag("Target");
        enemyDirector = GetComponent<EnemyDirector>();
        enemyDirector.selectedTarget = targets[Random.Range(0, targets.Length)].transform;
    }


    void Update() // Every Frame
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Bullet")
        {          
            health -= 50;
            Destroy(col.gameObject);
        }
    }
}
