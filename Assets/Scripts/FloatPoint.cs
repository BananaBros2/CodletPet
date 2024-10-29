using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatPoint : MonoBehaviour
{
    public Rigidbody rb;
    public float depthBeforeSubmerged = 1f;
    public float displacementAmount = 6f;
    public LayerMask waterLayer;
    public int floaterCount = 4;
    public float waterDrag = 0.99f;
    public float waterAngularDrag = 0.5f;

    void FixedUpdate()
    {
        rb.AddForceAtPosition(Physics.gravity * 1.6f / floaterCount, transform.position, ForceMode.Acceleration);

        float heightAboveGround = 11;
        Physics.Raycast(transform.position + Vector3.up * 5, Vector3.down, out RaycastHit hit, 25, waterLayer);
        if (hit.collider != null)
        {
            heightAboveGround = hit.distance - 5.066f;
        }

        if (heightAboveGround < 0f)
        {
            float displacementMultiplier = Mathf.Clamp01(-heightAboveGround / depthBeforeSubmerged) * displacementAmount;
            rb.AddForceAtPosition(new Vector3(0, Mathf.Abs(Physics.gravity.y) * displacementMultiplier, 0), transform.position, ForceMode.Acceleration);
            rb.AddForce(displacementMultiplier * -rb.velocity * waterDrag * Time.fixedDeltaTime, ForceMode.VelocityChange);
            rb.AddTorque(displacementMultiplier * -rb.angularVelocity * waterAngularDrag * Time.fixedDeltaTime, ForceMode.VelocityChange);
        }

    }
}