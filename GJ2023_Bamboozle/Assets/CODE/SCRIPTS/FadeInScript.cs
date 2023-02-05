using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FadeInScript : MonoBehaviour
{

    public TMP_Text textMeshPro;
    public float fadeInSpeed = 0.1f;

    private float alpha = 0f;

    void Start()
    {
        StartCoroutine(FadeInText());
    }

    IEnumerator FadeInText()
    {
        while (alpha < 1f)
        {
            alpha += fadeInSpeed * Time.deltaTime;
            if(textMeshPro!=null)
            textMeshPro.color = new Color(textMeshPro.color.r, textMeshPro.color.g, textMeshPro.color.b, alpha);
            yield return null;
        }
    }

}
