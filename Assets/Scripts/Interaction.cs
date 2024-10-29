using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    public BoatMovement movement;
    public CameraScript playerCamera;


    public float interactionDistance = 3;
    public LayerMask itemLayer;

    private RaycastHit hit;

    private bool interacting;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (interacting)
        {
            if (Input.GetButtonDown("Interact"))
            {
                hit.transform.GetComponent<ItemScript>().Interact();
                interacting = !interacting;
                movement.isDisabled = interacting;
                playerCamera.isDisabled = interacting;
            }
            return;
        }

        try
        {
            hit.transform.GetComponent<ItemScript>().Highlight(false);
        }
        catch
        {

        }
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, interactionDistance, itemLayer))
        {
            try
            {
                print(hit.transform.name);
                hit.transform.GetComponent<ItemScript>().Highlight(true);
                if (Input.GetButtonDown("Interact"))
                {
                    hit.transform.GetComponent<ItemScript>().Interact();
                    interacting = !interacting;
                    movement.isDisabled = interacting;
                    playerCamera.isDisabled = interacting;
                }
            }
            catch
            {
                return;
            }

        }
    }
}
