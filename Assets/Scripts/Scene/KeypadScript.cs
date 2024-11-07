using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class KeypadScript : MonoBehaviour
{
    public CameraScript playerCamera;
    public Interaction playerInteractor;

    public CinemachineFreeLook cameraView;
    public ItemScript itemScript;

    public TMP_Text text;

    public string currentNumber;
    public string correctCode;

    public bool isActive;

    public UnityEvent activate;

    private void Start()
    {
        text.text = "";
    }

    private void Update()
    {
        if (!isActive) { return; }

        if (Input.GetButtonDown("Cancel"))
        {
            playerCamera.ReturnCameraView(cameraView);
            playerInteractor.ResetInteraction();

            itemScript.DisableOutline(false);
            isActive = false;
        }
    }


    public void InitiateKeypad()
    {
        if (!isActive)
        {
            playerCamera.SwitchCamera(cameraView);
            itemScript.DisableOutline(true);
            isActive = true;
        }

    }

    public void EnterInput()
    {
        if (currentNumber == correctCode)
        {
            activate.Invoke();
        }

    }

    public void AddNumber(string num)
    {
        if (currentNumber.Length < 4)
        {
            currentNumber = currentNumber + num;
        }

        text.text = currentNumber;
    }

    public void Backspace()
    {
        if (currentNumber.Length > 0)
        {
            currentNumber = currentNumber.Substring(0, currentNumber.Length - 1);
        }
        text.text = currentNumber;
    }

    public void ClearDisplay()
    {
        currentNumber = "";
        text.text = currentNumber;
    }

}
