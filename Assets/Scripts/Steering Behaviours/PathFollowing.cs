using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GGL;

public class PathFollowing : SteeringBehaviour
{
    public Transform target;
    //Distance to current node
    public float nodeRadius = .5f;
    // Distance to end node
    public float targetRadius = 1.5f;
    private Graph graph;
    public int currentNode = 0;
    public bool showGizmos;
    private bool isAtTarget = false;
    public List<Node> path;
    public GameObject flag;
    public int i_flag = 0;
    public GameObject currentFlag;

    // Use this for initialization
    void Start()
    {
        // SET Grapth to FindObjectofType<Graph>();
        graph = FindObjectOfType<Graph>();
        // IF graph is null
        if (graph == null)
        {
            // CALL Debug.LogError() and pass an Error message
            Debug.LogError("Graph is null");
            // CALL Debug.Break() (pauses the editor)
            Debug.Break();
        }
    }

    public void UpdatePath()
    {
        // SET path to graph.FindPath() and pass transform's position, target's postion
        path = graph.FindPath(transform.position, target.transform.position);
        // SET currentNode to zero
        currentNode = 0;
        if (target != null && gameObject.tag == "Ship" && i_flag <1)
        {
            currentFlag = Instantiate(flag, target.position, Quaternion.identity);
            i_flag++;
        }
        if (currentFlag != null)
        {
            currentFlag.transform.position = target.position;   
        }
        
    }

    #region SEEK
    // Special version of Seek that takes into account the node radius & target radius
    Vector3 Seek(Vector3 target)
    {
        // SET force to zero
        Vector3 force = Vector3.zero;

        // SET desiredForce to target - transform.position
        Vector3 desiredForce = target - transform.position;
        // SET desiredForce.y to 0
        desiredForce.y = 0;

        // IF isAtTarget NOTE: this needs to be done with a ternary operator
        // SET distance to targetradius
        // ELSE
        // SET Distance to nodeRadius
        // SET Distance to       |   THIS   | OR |   THIS   |
                // IF |   THIS   | is    True           else

        // SET distance to zero
        float distance = isAtTarget ? targetRadius : nodeRadius;

        // IF desiredForce's length is greater than distance
        if (desiredForce.magnitude > distance)
        {

            // SET desiredForce to desiredForce.normalised * weighing
            desiredForce = desiredForce.normalized * weighting;
            // SET force to desired force - owner's velocity
            force = desiredForce - owner.velocity;
        }
        else if(isAtTarget)
        {
            owner.velocity = Vector3.zero;
            Destroy(currentFlag);
            i_flag = 0;
        }

        // RETURN force
        return force;
    }
    #endregion

    #region GetForce
    public override Vector3 GetForce()
    {
        Vector3 force = Vector3.zero;

        // IF path is not null AND path count is greater than zero
        if (path != null && path.Count > 0)
        {
            // SET currentPos to path[currentNode] position
            Vector3 currentPos = path[currentNode].position;
            float distance = Vector3.Distance(transform.position, currentPos);
            // IF distance between transform's position AND currentPos is less than or equal to nodeRadius
            if (distance <= nodeRadius)
            {
                // Increment currentNode
                currentNode++;
                // IF currentNode is greater than or equal to path.Count
                if (currentNode >= path.Count)
                {
                    isAtTarget = true;
                    // SET currentNode to path.Count
                    currentNode = path.Count - 1;
                }
            }

            // SET force to Seek() nad pass currentPos
            force = Seek(currentPos);

            if (showGizmos)
            {
                #region GIZMOS
                // SET prevPosition to path[0].position
                Vector3 prevPos = path[0].position;
                // FOREACH node in path
                foreach (Node node in path)
                {
                    // CALL GizmosGL.AddSphere() and pass node's position, graph's nodeRadius, identity, any color
                    // GizmosGL.AddSphere(node.position, graph.nodeRadius, Quaternion.identity, Color.red);
                    // CALL GizmosGL.AddLine() and pass prev, node's postion, 0.1f, 0.1f, any color, any color
                    GizmosGL.AddLine(prevPos, node.position, 0.1f, 0.1f, Color.green, Color.green);
                    // SET prev to node's position
                    prevPos = node.position;
                }

                #endregion
            }


        }
        // RETURN FORE
        return force;
    }
    #endregion
}
