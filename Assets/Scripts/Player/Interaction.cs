using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Interaction : MonoBehaviour
{
    public BoatMovement movement;
    public CameraScript playerCamera;
    public TMP_Text toolTipText;

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
        try { hit.transform.GetComponent<ItemScript>().Highlight(false); }
        catch { }

        if (interacting)
        {
            toolTipText.text = "";
            return;
        }

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, interactionDistance, itemLayer))
        {
            try
            {
                hit.transform.GetComponent<ItemScript>().Highlight(true);
                toolTipText.text = hit.transform.GetComponent<ItemScript>().toolTip;
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
        else
        {
            toolTipText.text = "";
        }
    }

    public void ResetInteraction()
    {
        interacting = !interacting;
        movement.isDisabled = interacting;
        playerCamera.isDisabled = interacting;
    }
}
