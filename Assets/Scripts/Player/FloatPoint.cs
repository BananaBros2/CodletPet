using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatPoint : MonoBehaviour
{
    public WaterWaves waves;

    public Rigidbody rb;
    public float depthBeforeSubmerged = 1f;
    public float displacementAmount = 6f;
    public LayerMask waterLayer;
    public int floaterCount = 4;
    public float waterDrag = 0.99f;
    public float waterAngularDrag = 0.5f;

    private void Start()
    {
        waves = GameObject.FindGameObjectWithTag("Water").GetComponent<WaterWaves>();
    }

    void FixedUpdate()
    {


        rb.AddForceAtPosition(Physics.gravity * 1.6f / floaterCount, transform.position, ForceMode.Acceleration);

        float heightAboveGround = 11;

        heightAboveGround = waves.GetHeight(transform.position);


        if (heightAboveGround < 0f)
        {
            float displacementMultiplier = Mathf.Clamp01(-heightAboveGround / depthBeforeSubmerged) * displacementAmount;
            rb.AddForceAtPosition(new Vector3(0, Mathf.Abs(Physics.gravity.y) * displacementMultiplier, 0), transform.position, ForceMode.Acceleration);
            rb.AddForce(displacementMultiplier * -rb.velocity * waterDrag * Time.fixedDeltaTime, ForceMode.VelocityChange);
            rb.AddTorque(displacementMultiplier * -rb.angularVelocity * waterAngularDrag * Time.fixedDeltaTime, ForceMode.VelocityChange);
        }

    }

}