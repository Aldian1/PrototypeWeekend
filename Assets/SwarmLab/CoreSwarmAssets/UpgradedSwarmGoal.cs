using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpgradedSwarmGoal : MonoBehaviour {
    [SerializeField]
    private GameObject goalMesh;
    private TextMeshPro textMesh;

    private float currentScore;

    private void Start()
    {
        textMesh = goalMesh.GetComponent<TextMeshPro>();
        textMesh.text = "0";
    }
    private void OnTriggerEnter(Collider other)
    {
      
        if ("Agent".Equals(other.gameObject.tag))
        {
            currentScore++;
            textMesh.text = currentScore.ToString();
            UpgradedSwarmController.Instance.RemoveFromSwarm(other.gameObject);
        }
    }
}
