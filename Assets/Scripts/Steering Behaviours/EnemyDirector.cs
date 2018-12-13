using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GGL;

public class EnemyDirector : MonoBehaviour
{
    public Transform selectedTarget;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        UnitApplySelection();
    }

    #region [SIngle Unit Selection]
    void UnitApplySelection()
    {
        // SET pathFollowing to agent.GetComponent<PathFollowing>();
        PathFollowing pathFollowing = GetComponent<PathFollowing>();
        // IF pathFollowing is not null
        if (pathFollowing != null)
        {
            // SET pathFollowing.target to selectedTarget
            pathFollowing.target = selectedTarget;
            // CALL pathFollowing.UpdatePath()
            pathFollowing.UpdatePath();
        }
    }
    #endregion

    void SelectUnit()
    {

    }
}
