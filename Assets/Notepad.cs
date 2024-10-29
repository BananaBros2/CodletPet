using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Notepad : MonoBehaviour
{
    public Image noteViewer;
    public Sprite noteImage;

    public void ViewNote()
    {
        noteViewer.enabled = !noteViewer.enabled;
        noteViewer.sprite = noteImage;
    }
}
