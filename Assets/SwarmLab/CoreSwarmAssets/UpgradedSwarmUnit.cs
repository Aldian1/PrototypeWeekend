using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UpgradedSwarmUnit : MonoBehaviour
{
    NavMeshAgent navAgent;
    Rigidbody swarmAgent;
    // Use this for initialization
    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
        ActivateUnit();
        swarmAgent = GetComponent<Rigidbody>();
    }

    public void SetNewPosition(Vector3 newPosition)
    {
       // swarmAgent.isKinematic = true;
        if (navAgent != null && navAgent.enabled == true)
        {
            navAgent.SetDestination(newPosition);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if("DeadZone".Equals(other.tag))
        {
           
        }
    }

    private void ActivateUnit()
    {
        UpgradedSwarmController.Instance.AddToSwarm(this.gameObject);
    }
    public void RemoveUnit()
    {
        UpgradedSwarmController.Instance.RemoveFromSwarm(this.gameObject);
        
    }

    

    }

