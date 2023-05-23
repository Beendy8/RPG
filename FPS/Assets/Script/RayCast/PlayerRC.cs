using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerRC : MonoBehaviour
{
    [SerializeField] private NavMeshAgent navMA;
    [SerializeField] private Vector3 target;
    private void Update()
    {
        RaycastHit hit;
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            {
                target = hit.point;
            }
        }

        navMA.SetDestination(target);
    }
}
