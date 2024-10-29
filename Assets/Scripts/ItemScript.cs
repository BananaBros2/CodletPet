using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class ItemScript : MonoBehaviour
{

    public Outline outline;
    public float smallOutline = 4;
    public float largeOutline = 8;

    public Color normalOutlineColour;
    public Color highlightedOutlineColour;


    public UnityEvent interacted;


    // Start is called before the first frame update
    void Start()
    {
        outline = GetComponent<Outline>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Highlight(bool active)
    {
        outline.OutlineWidth = active ? largeOutline : smallOutline;
        outline.OutlineColor = active ? highlightedOutlineColour : normalOutlineColour;
    }

    public void Interact()
    {
        interacted.Invoke();

        //if (type == InteractableType.note)
        //{
        //    noteViewer.enabled = !noteViewer.enabled;
        //    noteViewer.sprite = noteImage;
        //}
    }

}
