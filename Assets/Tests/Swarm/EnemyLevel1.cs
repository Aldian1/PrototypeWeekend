using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyLevel1 : MonoBehaviour
{

    private Text myText;
    private int health = 50;

    [SerializeField]
    private GameObject agent;

    [SerializeField]
    private GameObject EnemyGates;
    // Use this for initialization
    void Start()
    {
        myText = GetComponentInChildren<Text>();
        InvokeRepeating("BuildUnit", 0, 3);
    }

    // Update is called once per frame
    void Update()
    {
        myText.text = health.ToString();
        if (health < 0)
        {
            Destroy(this);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Agent")
        {
            other.transform.GetComponent<SwarmUnit>().RemoveUnit();
            TakeDamage();
        }
    }

    private void BuildUnit()
    {
        if (health > 0)
        {
            health--;
            GameObject tm = Instantiate(agent, transform.position, Quaternion.identity);
            tm.transform.position = new Vector3(tm.transform.position.x, tm.transform.position.y + transform.position.y, tm.transform.position.z);
            tm.GetComponent<SwarmUnit>().SetNewPosition(EnemyGates.transform.position);
        }
    }

    private void TakeDamage()
    {
        health--;
    }
}
