using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    public List<GameObject> units;
    public GameObject selected;

    private void Update()
    {
        for (int i = 0; i < units.Count; i++)
        {
            units[i].GetComponentInChildren<Tower>().UnitNum = i;
        }
    }
}
