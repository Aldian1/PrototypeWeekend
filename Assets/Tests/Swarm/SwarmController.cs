using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwarmController : Singleton<SwarmController>
{

    protected SwarmController() { }

    private List<GameObject> swarmRef = new List<GameObject>();

    private GameObject currentlySelectedBuilding;
    // Use this for initialization
    void Start()
    {

    }


    void Update()
    {
        PhysicsRaycast();
    }

    private void PhysicsRaycast()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100))
        {
            Debug.DrawLine(ray.origin, hit.point);
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                for (int i = 0; i < swarmRef.Count - 1; i++)
                {
                    swarmRef[i].GetComponent<SwarmUnit>().SetNewPosition(hit.point);
                }

            }
        }
    }
    public void AddToSwarm(GameObject swarmUnit)
    {
        swarmRef.Add(swarmUnit);
    }

    public void RemoveFromSwarm(GameObject swarmUnit)
    {
        swarmRef.Remove(swarmUnit);
    }
}
