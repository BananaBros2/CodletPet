using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraScript : MonoBehaviour
{
    public GameObject cameraPosition;
    public CinemachineFreeLook normalPOV;
    public BoatMovement movementScript;

    public float sensitivityX = 15F;
    public float sensitivityY = 15F;

    public float minimumX = -360F;
    public float maximumX = 360F;

    public float minimumY = -60F;
    public float maximumY = 60F;

    float rotationY = 0F;

    private Vector3 originalPosition;

    public float leanDistance = 0.45f;

    public bool isDisabled;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        originalPosition = transform.position;
    }
    void Update()
    {
        if (isDisabled) return;

        float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;

        rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
        rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

        transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);

        Vector3 targetPosition = cameraPosition.transform.position;
        if (Input.GetAxisRaw("Lean") < 0)
        {
            targetPosition = cameraPosition.transform.position + cameraPosition.transform.right * leanDistance;
        }
        else if (Input.GetAxisRaw("Lean") > 0)
        {
            targetPosition = cameraPosition.transform.position + cameraPosition.transform.right * -leanDistance;
        }

        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * 6);
    }

    public void SwitchCamera(CinemachineFreeLook otherCamera)
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        isDisabled = true;
        movementScript.isDisabled = true;

        otherCamera.Priority = 10;
        normalPOV.Priority = 0;
    }

    public void ReturnCameraView(CinemachineFreeLook otherCamera)
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        isDisabled = false;
        movementScript.isDisabled = false;

        otherCamera.Priority = 0;
        normalPOV.Priority = 10;
    }
}