using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TypingSubtitles : MonoBehaviour
{
    public bool subtitlesPresent;

    public TMP_Text textBox;

    public string tempText;

    public float startDelay = 1;
    public float characterDelay = 0.05f;

    public bool playAudio;
    public AudioSource audioSource;

    private void Start()
    {
        textBox = transform.GetComponent<TMP_Text>();
        textBox.text = "";
    }

    public void ActivateSubtitles(string givenText)
    {
        textBox.text = "";
        StartCoroutine(TypeWriterText(givenText));
    }

    public IEnumerator TypeWriterText(string text)
    {
        yield return new WaitForSeconds(startDelay);

        if (playAudio)
        {
            audioSource.Play();
        }

        subtitlesPresent = true;
        text += " "; 

        for (int i = 0; i < text.Length; i++)
        {
            textBox.text = text.Substring(0, i);

            // Wait briefly if current character is not a space
            if (text.Substring(i,1) != " ") { yield return new WaitForSeconds(characterDelay); }
        }

        subtitlesPresent = false;
    }

    public void resetText()
    {
        textBox.text = "";
    }
}
