using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FactoryBuilding : MonoBehaviour
{

    private enum CurrentTeam { Neutral, Red, Blue }

    [SerializeField]
    private CurrentTeam currentTeam;

    [SerializeField]
    private int buildingGoal;

    private Text buildingText;
    [SerializeField]
    private Color redTeamColor;

    private bool haveATeam;

    private float enemySpawnRate;

    private GameObject enemyAgent;

    // Use this for initialization
    void Start()
    {
        buildingText = GetComponentInChildren<Text>();
        enemySpawnRate = .5F;
        enemyAgent = Resources.Load("RedAgent") as GameObject;
        if (currentTeam == CurrentTeam.Red || currentTeam == CurrentTeam.Blue)
        {
            haveATeam = true;
            InvokeRepeating("BuildUnit", 0, enemySpawnRate);
        }

    }

    // Update is called once per frame
    void Update()
    {
        buildingText.text = buildingGoal.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {

        if (currentTeam == CurrentTeam.Neutral)
        {
            if (other.tag == "Agent" && !haveATeam)
            {
                other.GetComponent<SwarmUnit>().RemoveUnit();
                TakeDamage();
            }
        }
        else
        {
            if (other.tag == "Agent" && haveATeam)
            {
                //other.GetComponent<SwarmUnit>().RemoveUnit();
                //AddToBarracks();
            }
        }
    }

    private void TakeDamage()
    {
        if (buildingGoal > 0)
        {
            buildingGoal--;
        }
        else
        {
            ChangeCurrentTeam();
        }
    }
    private void ChangeCurrentTeam()
    {
        currentTeam = CurrentTeam.Red;
        haveATeam = true;
        this.GetComponent<Renderer>().material.color = redTeamColor;
        CancelInvoke("BuildUnit");
        InvokeRepeating("BuildUnit", 0, enemySpawnRate);
    }
    private void AddToBarracks()
    {
        buildingGoal++;
    }

    private void BuildUnit()
    {
        if (buildingGoal > 0)
        {
            buildingGoal--;
            GameObject tm = Instantiate(enemyAgent, transform.position, Quaternion.identity);
            tm.transform.position = new Vector3(tm.transform.position.x, tm.transform.position.y + transform.position.y, tm.transform.position.z);
            SwarmController.Instance.AddToSwarm(tm.gameObject);
        }
    }


}
