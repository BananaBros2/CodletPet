using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject cameraPosition;

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

}