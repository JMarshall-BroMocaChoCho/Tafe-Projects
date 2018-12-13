using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower_Rotate : Tower
{
    public float speed = 30f;

    public Transform from;
    public Transform to;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Scan();

        if (targetFound)
        {
            Attack();
        }   
    }

    protected override void Scan()
    {
        base.Scan();

        if (objectsFound.Count < 0)
        {
            transform.rotation = Quaternion.Slerp(from.rotation, to.rotation, Time.time * speed);
        }
        else
        {

        }
        
        

    }

    protected override void Attack()
    {
        base.Attack();
    }
}
