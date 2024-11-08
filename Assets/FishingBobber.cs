using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingBobber : MonoBehaviour
{
    private float biteTimer = 4;

    public float timeToBite = 4;
    public float timeToLose = 3;

    private bool fishAttached;

    public Outline outline;

    public FishCaught caughtScreen;

    private void Start()
    {
        biteTimer = timeToBite;
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("FishingSpot"))
        {
            biteTimer -= Time.deltaTime;
            if (biteTimer < -timeToLose)
            {
                fishAttached = false;
                biteTimer = timeToBite;
            }
            else if (biteTimer < 0)
            {
                fishAttached = true;
                outline.OutlineColor = Color.red;
                outline.OutlineWidth = 8;
            }

            else
            {
                outline.OutlineColor = Color.yellow;
                outline.OutlineWidth = 3;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("FishingSpot"))
        {
            biteTimer = timeToBite;

            if(fishAttached)
            {
                caughtScreen.gameObject.SetActive(true);
                caughtScreen.ActivateCaughtScreen();
            }
            fishAttached = false;
            outline.OutlineColor = Color.white;
            outline.OutlineWidth = 2;
        }
    }
}
