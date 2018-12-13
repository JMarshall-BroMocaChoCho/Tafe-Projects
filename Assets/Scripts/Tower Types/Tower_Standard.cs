using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Tower_Standard : Tower
{
    public GameObject bullet;
    

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        objectsFound = objectsFound.Where(item => item != null).ToList();
        Scan();
        AimGun();
        ShowSelection(selected);

        if (targetFound)
        {
            Attack();
        }
    }

    protected override void Attack()
    {
        base.Attack();
        if (isAttacking)
        {         
            if (towerShootDelay <= 0)
            {
                GameObject clone = Instantiate(bullet, transform.position, transform.rotation);

                Bullet bulletScript = clone.GetComponent<Bullet>();
                aimDirection.Normalize();
                bulletScript.direction = aimDirection;
                towerShootDelay = resetShotDelay;
            }
            else
            {
                towerShootDelay -= Time.deltaTime;
            }
        }
    }
}
