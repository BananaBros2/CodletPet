using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingRod : MonoBehaviour
{
    public GameObject bobber;
    public GameObject topOfRod;
    public GameObject cameraHolder;
    private bool cast;
    private bool canCastAgain = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && canCastAgain)
        {
            cast = !cast;
            if(cast)
            {
                bobber.transform.parent = null;
                bobber.GetComponent<SpringJoint>().maxDistance = 5;
                bobber.GetComponent<Rigidbody>().AddForce(cameraHolder.transform.TransformDirection(Vector3.forward) * 15, ForceMode.Impulse);
            }
            else
            {
                bobber.GetComponent<SpringJoint>().maxDistance = 0.01f;
                canCastAgain = false;
            }

        }

        if (!cast && Vector3.Distance(bobber.transform.position, topOfRod.transform.position) < 0.6f)
        {
            bobber.transform.parent = transform;
            canCastAgain = true;
        }
    }
}
