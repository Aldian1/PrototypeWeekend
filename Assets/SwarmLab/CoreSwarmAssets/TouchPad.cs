using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TouchPad : MonoBehaviour {
    [SerializeField]
    private Animator objectToMove;
    [SerializeField]
    private string animatorTriggerName;
    [SerializeField]
    private float animationDelay;
[SerializeField]
    private GameObject objectToDisable;

    private void OnTriggerEnter(Collider other)
    {
        if("Agent".Equals(other.tag))
        {
            StartCoroutine(PlayAnimationDelay());
        }
    }

    private IEnumerator PlayAnimationDelay()
    {
        yield return new WaitForSeconds(animationDelay);
        objectToDisable.GetComponent<NavMeshObstacle>().enabled = false;
        objectToMove.SetTrigger(animatorTriggerName);
    }
}
