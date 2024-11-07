using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Notepad : MonoBehaviour
{
    public Interaction playerInteractor;

    public GameObject NoteUI;

    private Image noteViewer;
    public Sprite noteImage;

    private TMP_Text noteTextComponent;

    public string noteText = "NOT SET";

    private bool interacting;
    private bool textUp;

    private void Start()
    {
        noteViewer = NoteUI.transform.GetChild(0).GetComponent<Image>();
        noteTextComponent = NoteUI.transform.GetChild(0).GetChild(0).GetComponent<TMP_Text>();
    }

    public void ViewNote()
    {
        NoteUI.SetActive(true);

        noteViewer.sprite = noteImage;
        noteTextComponent.text = noteText;

        interacting = true;
    }

    private void Update()
    {
        if (!interacting) { return; }

        if (Input.GetButtonDown("Interact") && !textUp)
        {
            noteViewer.color = new Color(0.2f,0.2f,0.2f);
            noteTextComponent.enabled = true;
            textUp = true;
        }
        else if (Input.GetButtonDown("Cancel") && textUp)
        {
            noteViewer.color = new Color(1, 1, 1);
            noteTextComponent.enabled = false;

            textUp = false;
        }
        else if (Input.GetButtonDown("Cancel"))
        {
            playerInteractor.ResetInteraction();

            NoteUI.SetActive(false);

            interacting = false;
        } 
    }
}
