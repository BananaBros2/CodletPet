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

    public string toolTip = "Interact";

    public UnityEvent interacted;
    public bool disableOutline;


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
        if (disableOutline) { return;}

        outline.OutlineWidth = active ? largeOutline : smallOutline;
        outline.OutlineColor = active ? highlightedOutlineColour : normalOutlineColour;
    }

    public void Interact()
    {
        interacted.Invoke();

    }

    public void DisableOutline(bool doDisable)
    {
        disableOutline = doDisable;
        outline.enabled = !doDisable;

        outline.OutlineWidth = doDisable ? smallOutline : largeOutline;
        outline.OutlineColor = doDisable ? normalOutlineColour : highlightedOutlineColour;
    }



}
