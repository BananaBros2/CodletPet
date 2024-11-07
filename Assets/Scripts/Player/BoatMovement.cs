using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMovement : MonoBehaviour
{
    Rigidbody rb;

    float horizontalInput;
    float verticalInput;

    public float speed = 25f;
    public float steerSpeed = 400f;

    public bool isDisabled = false;


    // Start is called before the first frame update
    void Start()
    {
        rb = transform.GetComponent<Rigidbody>();
    }

    // Update is called once per frame

    private void Update()
    {

        if (Input.GetAxisRaw("Vertical") > 0)
        {
            verticalInput = 1;
        }
        else if (Input.GetAxisRaw("Vertical") < 0)
        {
            verticalInput = -0.8f;
        }
        else
        {
            verticalInput = 0;
        }
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            horizontalInput = 1;
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            horizontalInput = -1;
        }
        else
        {
            horizontalInput = 0;
        }
    }

    void FixedUpdate()
    {
        if (isDisabled)
        {
            verticalInput = 0;
            horizontalInput = 0;
        }

        rb.AddForce(new Vector3(transform.forward.x, transform.forward.y * 0.1f, transform.forward.z) * verticalInput * speed, ForceMode.Acceleration);
        rb.AddTorque(new Vector3(0, 1, 0) * horizontalInput * steerSpeed, ForceMode.Acceleration);
    }

    public void DisableControls(bool disabled)
    {
        isDisabled = disabled;

    }
}
