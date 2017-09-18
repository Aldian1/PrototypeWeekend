using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UpgradedSwarmUnit : MonoBehaviour
{
    NavMeshAgent navAgent;
    // Use this for initialization
    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
        ActivateUnit();
    }

    public void SetNewPosition(Vector3 newPosition)
    {
        if (navAgent != null)
        {
            navAgent.SetDestination(newPosition);
        }
    }

     private void ActivateUnit()
    {
        UpgradedSwarmController.Instance.AddToSwarm(this.gameObject);
    }
    public void RemoveUnit()
    {
        UpgradedSwarmController.Instance.RemoveFromSwarm(this.gameObject);
        Destroy(this.gameObject);
    }
}
