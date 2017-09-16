// Converted from UnityScript to C# at http://www.M2H.nl/files/js_to_c.php - by Mike Hergaarden
// Do test the code! You usually need to change a few small bits.

using UnityEngine;
using System.Collections;

public class CameraControls : MonoBehaviour
{


    public float flySpeed = .001F;
    GameObject defaultCam;
    GameObject playerObject;
    bool isEnabled;

    bool shift;
    bool ctrl;
    float accelerationAmount = 1;
    float accelerationRatio = 3;
    float slowDownRatio = 0.2f;
[SerializeField]
private float rotationSpeed;

 public Transform target;

    void Update()
    {
      
        UserInputAndMovement();
       


    }
 void FixedUpdate()
{
     RotateObject();
}
    void UserInputAndMovement()
    {
  //use shift to speed up flight
        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        {
            shift = true;
            flySpeed *= accelerationRatio;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.RightShift))
        {
            shift = false;
            flySpeed /= accelerationRatio;
        }

        //use ctrl to slow up flight
        if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl))
        {
            ctrl = true;
            flySpeed *= slowDownRatio;
        }

        if (Input.GetKeyUp(KeyCode.LeftControl) || Input.GetKeyUp(KeyCode.RightControl))
        {
            ctrl = false;
            flySpeed /= slowDownRatio;
        }
        //
        if (Input.GetAxis("Vertical") != 0)
        {
            transform.Translate(Vector3.forward * flySpeed * Input.GetAxis("Vertical") * Time.deltaTime);
        }


        if (Input.GetAxis("Horizontal") != 0)
        {
            transform.Translate(Vector3.right * flySpeed * Input.GetAxis("Horizontal") * Time.deltaTime);
        }


        if (Input.GetKey(KeyCode.E))
        {
            transform.Translate(Vector3.up * flySpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.Q))
        {
            transform.Translate(Vector3.down * flySpeed * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            playerObject.transform.position = transform.position; //Moves the player to the flycam's position. Make sure not to just move the player's camera.
        }

    }

    void RotateObject()
    {
        
        Vector3 targetDir = target.position - transform.position;
        float step = rotationSpeed * Time.deltaTime;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0F);
        Debug.DrawRay(transform.position, newDir, Color.red);
        transform.rotation = Quaternion.LookRotation(newDir);
    }

}