using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadTeamSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject swarmUnit;

    float lastKeyPress;
    [SerializeField]
    private float spawnLag;
    // Use this for initialization
    void Update()
    {
       
        if(Input.GetKey(KeyCode.E) && Time.time > lastKeyPress + spawnLag)
        {
            SpawnTeamMember();
            lastKeyPress = Time.time;
        }
  
    }
    private void SpawnTeamMember()
    {
        GameObject swarmCopy = Instantiate(swarmUnit, transform.position, Quaternion.identity);
    }
}
