using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class Tower : MonoBehaviour
{
    [Header("Tower Attributes")]
    public GameObject selectionRadius, flag;
    public float towerShootDelay, resetShotDelay;
    public float towerChargeTimer, towerChargeReset;
    public float towerDamage;
    public int towerAmmo;
    public bool isAttacking = false, targetFound = false;
    public bool tookDamage = false, selected, showFlag;
    public Vector3 aimDirection;
    public int UnitNum;

    // List
    public List<GameObject> objectsFound = new List<GameObject>();

    protected virtual void Scan()
    {
        // If the tower's list of objects found is more than 0, Start scanning
        if (objectsFound.Count > 0)
        {
            // Setup a variable to be used for Objects postion
            Vector3 targetPos;

            // Set targetPos to the position of the first object on the list
            targetPos = objectsFound[0].transform.position;
            // Calculate the direction to aim (Vector B - Vector A = Direction)
            aimDirection = targetPos - transform.position;

            // aimDirection.Normalize();            

            // Draw the aimDirection
            Debug.DrawRay(transform.position, aimDirection, Color.red);

            // Set targetFound to true so that the tower knows to Attack()
            targetFound = true;
        }
        else
        {
            // If there are no objects found, No targets are found, the Tower is not attacking
            targetFound = false;
            isAttacking = false;
            // Incase an object enters and leaves radius more than once, reset charge timer
            towerChargeTimer = towerChargeReset;
        }
    }

    protected virtual void Attack()
    {
        // Timer to start attacking
        if (targetFound && towerChargeTimer <= 0)
        {
            // Tower can start attacking
            isAttacking = true;
        }
        else
        {
            // Count down timer        
            towerChargeTimer -= Time.deltaTime;
        }
    }

    protected

    void OnTriggerEnter(Collider col)
    {
        // If an 'Enemy' enters the towers range
        if (col.tag == "Enemy")
        {
            // Add 'Enemy' to list
            objectsFound.Add(col.gameObject);
        }
    }

    void OnTriggerExit(Collider col)
    {
        // If an 'Enemy' leaves the towers range
        if (col.tag == "Enemy")
        {
            // Remove 'Enemy' to list
            objectsFound.Remove(col.gameObject);
        }
    }

    protected virtual void ShowSelection(bool set)
    {
        MeshRenderer rend = selectionRadius.GetComponent<MeshRenderer>();

        if (selected)
        {
            rend.enabled = rend.enabled = true;
        }
        else
        {
            rend.enabled = rend.enabled = false;
        }
    }

    protected virtual void AimGun()
    {
        if (targetFound)
        {
            transform.rotation = Quaternion.LookRotation(aimDirection);
        }
    }
}
