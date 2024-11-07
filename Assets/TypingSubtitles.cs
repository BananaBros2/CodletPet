using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TypingSubtitles : MonoBehaviour
{
    public bool subtitlesPresent;

    public TMP_Text textBox;

    public string tempText;
    public float characterDelay = 0.05f;
    private void Start()
    {
        textBox = transform.GetComponent<TMP_Text>();
        textBox.text = "";
        StartCoroutine(TypeWriterText(tempText));
    }

    public IEnumerator TypeWriterText(string text)
    {
        subtitlesPresent = true;
        text = text + " "; 

        for (int i = 0; i < text.Length; i++)
        {
            textBox.text = text.Substring(0, i);

            // Wait briefly if current character is not a space
            if (text.Substring(i,1) != " ") { yield return new WaitForSeconds(characterDelay); }
        }

        subtitlesPresent = false;
    }
}
