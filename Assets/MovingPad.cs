using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovingPad : MonoBehaviour {
    [SerializeField]
    private float padCount;
	// Use this for initialization
	void Start () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if("Agent".Equals(other.tag))
        {
            padCount++;
            
            other.GetComponent<NavMeshAgent>().enabled = false;
            other.transform.parent = this.gameObject.transform;
            other.transform.position = Vector3.zero;
           // other.gameObject.transform.position = new Vector3(Random.Range(0, 3), transform.position.y, 0);
        }
       
    }
}
