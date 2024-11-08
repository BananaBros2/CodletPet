using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using static UnityEngine.Rendering.DebugUI;

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


    [HideInInspector] public UnityEvent activate;
    [HideInInspector] public bool resetting;

    public Light redLED;
    public Light greenLED;


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
            playerCamera.ReturnCameraView(cameraView);
            playerInteractor.ResetInteraction();

            itemScript.DisableOutline(true);
            Destroy(itemScript);
            isActive = false;

            StartCoroutine(CorrectSequence());
        }
        else
        {
            resetting = true;
            StartCoroutine(IncorrectSequence());
        }
    }

    public IEnumerator IncorrectSequence()
    {
        for (int i = 0; i < 4; i++)
        {
            redLED.intensity = 0.5f;
            yield return new WaitForSeconds(0.2f);
            redLED.intensity = 0.002f;
            yield return new WaitForSeconds(0.2f);
        }

        currentNumber = "";
        text.text = currentNumber;

        resetting = false;
    }

    public IEnumerator CorrectSequence()
    {
        for (int i = 0; i < 4; i++)
        {
            greenLED.intensity = 0.002f;
            yield return new WaitForSeconds(0.2f);
            greenLED.intensity = 0.5f;
            yield return new WaitForSeconds(0.2f);

        }

        activate.Invoke();

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
