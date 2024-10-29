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
        //print("snap");

        Camera cam = Camera.main;
        Texture2D image = new Texture2D(1000, 1000);

        RenderTexture currentRT = RenderTexture.active;

        RenderTexture.active = cam.targetTexture;
        cam.Render();

        yield return new WaitForEndOfFrame();

        photoRect = new Rect(0, 0, Screen.width, Screen.height);
        image.ReadPixels(photoRect, 0, 0);

        //Resize the image. Useful if you don't need a 1:1 screenshot.
        //4 is just used as an example. You could use 10 to resize it
        //to a tenth of the original scale or whatever floats your boat.
        bool resizePhotos = false;
        //if (resizePhotos)
        //    TextureScale.Bilinear(image, image.width / 4, image.height / 4);

        image.Apply();
        RenderTexture.active = currentRT;

        photoFrame.GetComponent<Renderer>().material.mainTexture = image;

        //Save it as PNG, but it could easily be changed to JPG
        //byte[] bytes = screenshot.EncodeToPNG();

        string filename = "MyScreenshot";

        //System.IO.File.WriteAllBytes(filename, bytes);
        //Debug.Log(string.Format("Took screenshot to: {0}", filename));
    }
}
