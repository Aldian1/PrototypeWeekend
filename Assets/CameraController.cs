namespace Tengio
{


    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class CameraController : MonoBehaviour
    {
        [SerializeField]
        private GameObject auraEffect;
        [SerializeField]
        private GameObject trackingMarker;
        [SerializeField]
        private GameObject cube;

        private List<GameObject> cubeList = new List<GameObject>();
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            UserInput();
        }

        private void UserInput()
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            { Debug.DrawLine(ray.origin, hit.point); }
            trackingMarker.transform.position = hit.point;
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if("Respawn".Equals(hit.transform.tag))
                {
                    ActivateAntiGravity();
                    
                }
                GameObject cubeClone = Instantiate(cube, hit.point, Quaternion.identity);
                cubeClone.transform.position = new Vector3(hit.point.x, hit.point.y + (cubeClone.transform.localScale.y / 2), hit.point.z);
                cubeList.Add(cubeClone);
            }
        }

        private void ActivateAntiGravity()
        {
            if(cubeList.Count > 0)
            {
            for(int i = 0; i < cubeList.Count; i++)
            {
                Rigidbody cubeRB = cubeList[i].GetComponent<Rigidbody>();
                GameObject auraEffectInst = Instantiate(auraEffect, cubeList[i].transform.position, Quaternion.identity);
                Destroy(auraEffectInst, 3F);
                cubeRB.useGravity = false;
                cubeRB.AddForce(Vector3.up * 20);
                cubeList.Remove(cubeList[i]);
            }
            }
        }
    }
}

