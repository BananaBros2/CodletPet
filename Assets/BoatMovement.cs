using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;

public class BoatMovement : MonoBehaviour
{
    public Rigidbody rb;
    public List<GameObject> boatPoints;

    public LayerMask waterLayer;

    public float boatSpeed = 500;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        float forwardForce = Input.GetAxis("Vertical");
        float turningForce = Input.GetAxis("Horizontal");

        rb.AddForce(transform.GetChild(0).forward * forwardForce * Time.deltaTime * boatSpeed);

        //rb.AddTorque(new Vector3(0,turningForce * 1 * Time.deltaTime,0));

        foreach (GameObject point in boatPoints)
        {
            RaycastHit hit = Physics.Raycast(point.transform.position, -point.transform.up, 3, out hi, waterLayer)
            rb.AddForceAtPosition(new Vector3(0,  100 * Time.deltaTime, 0), point.transform.position);
            //rb.AddRelativeTorque(new Vector3(0,turningForce * 1 * Time.deltaTime,0));
            print("gabba ghoul");
            //point.GetComponent<Rigidbody>().AddRelativeTorque(new Vector3(0,turningForce * 1 * Time.deltaTime,0));
        }
        //rb.AddRelativeTorque(new Vector3(0,turningForce * 1 * Time.deltaTime,0));

    }
}
