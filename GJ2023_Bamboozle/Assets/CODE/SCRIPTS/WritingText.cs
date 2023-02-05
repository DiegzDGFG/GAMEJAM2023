using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WritingText : MonoBehaviour
{
    public TMP_Text textMeshPro;
    public string fullText;
    public float writingSpeed = 0.1f;

    private string currentText = "";

    void Start()
    {
        StartCoroutine(WriteText());
    }

    IEnumerator WriteText()
    {
        int textIndex = 0;
        while (textIndex < fullText.Length)
        {
            currentText += fullText[textIndex];
            textMeshPro.text = currentText;
            textIndex++;
            yield return new WaitForSeconds(writingSpeed);
        }
    }
}
