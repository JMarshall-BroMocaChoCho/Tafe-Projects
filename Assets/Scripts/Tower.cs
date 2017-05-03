using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{

    public float towerShootDelay;
    public float towerDamage;
    public int towerAmmo;
    public List<GameObject> objectsFound = new List<GameObject>();

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    protected virtual void Scan()
    {
        // if list > 0 then start attacking
        if (objectsFound.Count > 0)
        {
            Vector3 targetPos;
            Vector3 aimDirection;

            targetPos = objectsFound[0].transform.position;
            aimDirection = targetPos - transform.position;

            aimDirection.Normalize();

            Debug.DrawRay(transform.position, aimDirection, Color.red);
        }
    }

    protected virtual void Attack()
    {

    }

    void OnTriggerEnter(Collider col)
    {
        //If Colliding
        if (col.tag == "SeenByTower")
        {
            // add to list
            objectsFound.Add(col.gameObject);
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.tag == "SeenByTower")
        {
            // add to list
            objectsFound.Remove(col.gameObject);
        }
    }
}
