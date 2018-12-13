using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Tower_Lazer : Tower
{
    public bool lazerIsActive;
    public LineRenderer lineRender;
    private GameObject target;

    private float killTimer = 0.2f, resetKillTimer = 0.2f;

    // Use this for initialization
    void Start()
    {
        lineRender = GetComponent<LineRenderer>();
        // Make sure the lazer isn't seen until firing (Can cause issues with loading position if removed)
        lazerIsActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Run the Scan() function
        objectsFound = objectsFound.Where(item => item != null).ToList();
        Scan();
        AimGun();
        // If the tower has found an object and is ready to attack, then Attack();
        if (targetFound)
        {
            // Run the new Attack() function
            Attack();
        }
        else
        {
            // If the tower is not attacking, the lazer is not seen
            lineRender.enabled = false;
        }
    }

    protected override void Attack()
    {
        base.Attack();
        if (isAttacking)
        {
            // Set origin point for lazer       
            lineRender.SetPosition(0, transform.position);
            // Set target position for lazer
            lineRender.SetPosition(1, objectsFound[0].transform.position);
            // Once the lazer is set correctly, Show lazer
            lineRender.enabled = true;

            if (killTimer <= 0)
            {
                target = objectsFound[0];
                //Enemy enemy = target.GetComponent<Enemy>();

                if (objectsFound[0] != null)
                {
                    //enemy.enemyHealth -= towerDamage;
                }
                
                killTimer = resetKillTimer;
            }
            else
            {
                killTimer -= Time.deltaTime;
            }           
        }
    }
}
