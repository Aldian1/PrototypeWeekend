using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradedSwarmController : Singleton<UpgradedSwarmController>
{
    //http://answers.unity3d.com/questions/486023/disabling-collisions-between-nav-mesh-agents.html
    protected UpgradedSwarmController() { }
   
    private List<GameObject> swarmRef = new List<GameObject>();
   
    private GameObject currentlySelectedBuilding;

    [SerializeField]
    private GameObject auraMarker;
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
                Vector3 newPos = new Vector3(hit.point.x, -10.26F, hit.point.z);
                auraMarker.transform.position = newPos;
                for (int i = 0; i < swarmRef.Count - 1; i++)
                {
                    swarmRef[i].GetComponent<UpgradedSwarmUnit>().SetNewPosition(hit.point);
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
        Destroy(swarmUnit, 0F);
    }
}
