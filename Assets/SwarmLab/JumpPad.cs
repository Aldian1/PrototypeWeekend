using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class JumpPad : MonoBehaviour {
    [SerializeField]
    private float airTime = .5F;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider collision)
    {
        if("Agent".Equals(collision.transform.tag))
        {
            StartCoroutine(MoveTargetUp(collision.gameObject));
        }

    }

    private IEnumerator MoveTargetUp(GameObject swarmUnit)
    {
        yield return new WaitForSeconds(.25F);
        float entryTime = Time.time;
        swarmUnit.GetComponent<NavMeshAgent>().enabled = false;
        while(Time.time < entryTime + airTime)
        {
            swarmUnit.transform.position = Vector3.up * Time.time;
            yield return null;
        }
        swarmUnit.GetComponent<NavMeshAgent>().enabled = true;

    }
}
