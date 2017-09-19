using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class JumpPad : MonoBehaviour {
    //https://docs.unity3d.com/Manual/nav-MixingComponents.html

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
        yield return new WaitForSeconds(1);
        GetComponent<Animator>().SetTrigger(0);
        
        

    }
}
