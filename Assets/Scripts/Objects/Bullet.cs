using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector3 direction;

    private float bulletSpeed = 0.5f;

    // Update is called once per frame
    void Update()
    {
        // Move bullet in a forward relative direction
        transform.position += direction * bulletSpeed;
    }

    private void OnTriggerExit(Collider col)
    {
        // If the bullet leaves the Screen/Collider Box, Destroy the bullet
        if (col.gameObject.tag == "DestroyOnExitZone")
        {
            Destroy(gameObject);
        }
    }
}
