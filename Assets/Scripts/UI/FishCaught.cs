using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FishCaught : MonoBehaviour
{

    public FishBehaviour fish;
    public InventoryScript inventory;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void ActivateCaughtScreen()
    {
        transform.GetChild(0).GetComponent<TMP_Text>().text = fish.fishName;

        int randomIndex = Random.Range(0, fish.kText.Length - 1);
        string description = fish.kText[randomIndex];

        transform.GetChild(1).GetChild(0).GetComponent<TypingSubtitles>().ActivateSubtitles(description);
        transform.GetChild(2).GetComponent<AudioSource>().clip = fish.kAudioClip[randomIndex];

        inventory.AddItem(fish.fishName, null);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            gameObject.SetActive(false);
            transform.GetChild(1).GetChild(0).GetComponent<TypingSubtitles>().resetText();
        }
    }
}
