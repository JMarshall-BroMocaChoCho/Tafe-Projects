using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seek : SteeringBehaviour
{
    public Transform target;
    public float stoppingDistance = 0f;

    private void Update()
    {
        
    }

    public override Vector3 GetForce()
    {
        Vector3 force = Vector3.zero;

        // IF there is no target, THEN return force
        if (target == null)
        { return force; }
        // SET desiredForce to direction from target to position
        Vector3 desiredForce = target.position - transform.position;
        // SET desiredForce y to 0
        desiredForce.y = 0;

        // IF direction is greater than stoppingDistance
        if (desiredForce.magnitude > stoppingDistance)
        {
            // SET direction to normalised and multiply by weighing
            desiredForce = desiredForce.normalized * weighting;
            // SET force to desiredForce and subtract owner's velocity
            force = desiredForce - owner.velocity;
        }


        return force;
    }
}
