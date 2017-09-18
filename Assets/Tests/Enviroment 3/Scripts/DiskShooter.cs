using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiskShooter : MonoBehaviour
{
    [SerializeField]
    private GameObject clayPiegon;
    [SerializeField]
    private float power;

    public void ShootClayPigeon()
    {
        GameObject p = Instantiate(clayPiegon, transform.position + (transform.position / 2), Quaternion.identity);
        p.GetComponent<Rigidbody>().AddForce(-transform.forward * power);
        p.transform.rotation = this.transform.rotation;
        GameController.Instance.AddAPoint();
    }
}
