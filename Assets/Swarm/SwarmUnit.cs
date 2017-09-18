using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SwarmUnit : MonoBehaviour
{
    NavMeshAgent navAgent;
    // Use this for initialization
    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
    }

    public void SetNewPosition(Vector3 newPosition)
    {
        if (navAgent != null)
        {
            navAgent.SetDestination(newPosition);
        }
    }

    public void RemoveUnit()
    {
        SwarmController.Instance.RemoveFromSwarm(this.gameObject);
        Destroy(this.gameObject);
    }
}
