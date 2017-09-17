using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiskShooter : MonoBehaviour {
[SerializeField]
private GameObject clayPiegon;
	// Use this for initialization
	void Start () {
		InvokeRepeating("ShootClayPigeon", 2, 2);

	}
	
private void ShootClayPigeon()
{
    GameObject p = Instantiate(clayPiegon, transform.position + (transform.position / 2), Quaternion.identity);
    p.GetComponent<Rigidbody>().AddForce(-transform.forward * 200);
    p.transform.rotation = this.transform.rotation;
}
}
