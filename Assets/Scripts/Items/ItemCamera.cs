using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCamera : MonoBehaviour
{
    public GameObject photoFrame;
    private Rect photoRect;

    private void Update()
    {
        if (Input.GetButtonDown("TakePhoto"))
        {
            //print("aw");
            StartCoroutine("TakeScreenshot");
        }

    }

    private IEnumerator TakeScreenshot()
    {
        //print("Photo Taken");

        Camera cam = Camera.main;
        Texture2D image = new Texture2D(1000, 1000);

        RenderTexture currentRT = RenderTexture.active;

        RenderTexture.active = cam.targetTexture;
        cam.Render();

        yield return new WaitForEndOfFrame();

        photoRect = new Rect(0, 0, Screen.width, Screen.height);
        image.ReadPixels(photoRect, 0, 0);

        image.Apply();
        RenderTexture.active = currentRT;

        photoFrame.GetComponent<Renderer>().material.mainTexture = image;

    }
}
