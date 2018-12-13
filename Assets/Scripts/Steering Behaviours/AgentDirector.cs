using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GGL;

public class AgentDirector : MonoBehaviour
{
    public Transform selectedTarget;
    public float rayDistance = 1000f;
    public bool unitSelected, placingUnit;
    public LayerMask selectionLayer, unitLayer;
    public AIAgent selected;
    public GameObject selectedObject;

    public UnitManager unit_M;


    // Use this for initialization
    void Start()
    {
        //agents = FindObjectsOfType<AIAgent>();
        unit_M = FindObjectOfType<UnitManager>();
    }

    // Update is called once per frame
    void Update()
    {
        SelectUnit();

        if (unitSelected)
        {
            CheckSelection();

            for (int i = 0; i < unit_M.units.Count; i++)
            {
                unit_M.units[i].GetComponentInChildren<Tower>().selected = false;           
            }
            selectedObject.GetComponentInChildren<Tower>().selected = true;
        }

    }

    #region [SIngle Unit Selection]
    void UnitApplySelection()
    {
        // SET pathFollowing to agent.GetComponent<PathFollowing>();
        PathFollowing pathFollowing = selected.GetComponent<PathFollowing>();
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

    // Constantly checking for input
    void CheckSelection()
    {
        // SET ray to ray from Camera
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        // SET hit to new RaycastHit
        RaycastHit hit = new RaycastHit();
        // IF Physics.Raycast() and pass ray, out hit, rayDistance, selectionLayer
        if (Physics.Raycast(ray, out hit, rayDistance, selectionLayer))
        {
            // CALL GizmoGL.AddSphere() and pass hit.point, 5f, Quaternion.Identity, any color
            if (Input.GetMouseButton(1))
            {
                // SET selectedTarget to hit.Collider.transform
                selectedTarget = hit.collider.transform;
                // CALL ApplySelection
                UnitApplySelection();
            }
        }
    }

    void SelectUnit()
    {
        // SET ray to ray from Camera
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        // SET hit to new RaycastHit
        RaycastHit hit = new RaycastHit();
        // CALL GizmoGL.AddSphere() and pass hit.point, 5f, Quaternion.Identity, any color
        if (Input.GetMouseButton(0) && (Physics.Raycast(ray, out hit, rayDistance, unitLayer)))
        {
            selectedObject = hit.collider.gameObject;
            selected = selectedObject.GetComponent<AIAgent>();
            unitSelected = true;
        }
        else if (Input.GetMouseButton(0) && (Physics.Raycast(ray, out hit, rayDistance, ~unitLayer)))
        {
            if (unitSelected)
            {
                selectedObject.GetComponentInChildren<Tower>().selected = false;
            }

            unitSelected = false;
        }
    }
}
