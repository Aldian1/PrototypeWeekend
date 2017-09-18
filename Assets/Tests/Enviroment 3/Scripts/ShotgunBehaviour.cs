using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class ShotgunBehaviour : MonoBehaviour
{

    private bool shot;

    private LineRenderer lineRenderer;

    [SerializeField]
    private GameObject pelletShot;
    [SerializeField]
    private Transform pelletShotSpot;
    [SerializeField]
    private float shotPower;
    [SerializeField]
    private float shotAmount;
    [SerializeField]
    private float spreadAmount;

    [SerializeField]
    private RaycastHit hit;

    [SerializeField]
    private GameObject shotEffect;

    private List<GameObject> pelletCopys = new List<GameObject>();

    // Use this for initialization
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        SendOutRay();
        if (Input.GetKeyDown(KeyCode.Mouse0) && !shot && !EventSystem.current.IsPointerOverGameObject())
        {
            if (hit.point != null)
            {
                shot = true;
                ShootPellets();
                GameController.Instance.MinusAPoint();
            }
            StartCoroutine(ReloadGun());
        }
    }

    private IEnumerator ReloadGun()
    {
        yield return new WaitForSeconds(3);
        shot = false;
        shotEffect.SetActive(false);
        for (int i = 0; i < pelletCopys.Count - 1; i++)
        {
            pelletCopys.Remove(pelletCopys[i]);
            Destroy(pelletCopys[i]);
        }
    }
    private void ShootPellets()
    {
        for (int i = 0; i < shotAmount; i++)
        {
            float spreadAmountT = Random.Range(-spreadAmount, spreadAmount);
            GameObject pelletCopy = Instantiate(pelletShot, pelletShotSpot.position, Quaternion.identity);
            Vector3 newSpreadPosition = new Vector3(pelletShotSpot.position.x + spreadAmountT, pelletShotSpot.position.y + spreadAmountT, pelletShotSpot.transform.position.z);
            pelletCopy.transform.position = newSpreadPosition;
            pelletCopy.GetComponent<Rigidbody>().AddForce(pelletShotSpot.transform.up * shotPower);
            pelletCopys.Add(pelletCopy);
            shotEffect.SetActive(true);
        }
    }

    private void SendOutRay()
    {

        Vector3 fwd = pelletShotSpot.transform.TransformDirection(Vector3.up);
        if (Physics.Raycast(transform.position, fwd, out hit, 1000))
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) && !shot)
            {
                Debug.DrawLine(transform.position, hit.point);
                Debug.Log("Hit disc target: " + hit.distance);
                StartCoroutine(DeleteDiskTarget(hit.distance, hit.transform.gameObject));
            }
            lineRenderer.positionCount = 2;
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, hit.point);
        }
        else
        {
            lineRenderer.positionCount = 0;
            Debug.DrawLine(transform.position, fwd * 1000);
        }

    }

    private IEnumerator DeleteDiskTarget(float distance, GameObject target)
    {
        yield return new WaitForSeconds(distance / 100);
        StartCoroutine(ReloadGun());
        Destroy(target);
    }
}
