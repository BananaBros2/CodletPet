using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeypadButton : MonoBehaviour
{
    private KeypadScript keypadController;


    public ButtonType buttonType = ButtonType.Number;

    public string number = "[NOT_SET]";
    public Outline outline;

    private void Start()
    {
        keypadController = transform.parent.GetComponent<KeypadScript>();
    }


    public enum ButtonType
    {
        Number,
        Enter,
        Remove,
        Clear,
    }

    private void OnMouseDown()
    {
        if (!keypadController.isActive || keypadController.resetting) { return; }

        switch (buttonType)
        {
            case ButtonType.Number:
                keypadController.AddNumber(number);
                break;
            case ButtonType.Enter:
                keypadController.EnterInput();
                break;
            case ButtonType.Remove:
                keypadController.Backspace();
                break;
            default:
                keypadController.ClearDisplay();
                break;
        }

    }

    private void OnMouseEnter()
    {
        if (!keypadController.isActive) { return; }

        outline.enabled = true;
    }

    private void OnMouseExit()
    {
        outline.enabled = false;
    }

}
