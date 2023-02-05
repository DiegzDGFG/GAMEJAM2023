using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PulseImage : MonoBehaviour
{
    public RawImage rawImage;
    public float pulseSpeed = 1f;
    public float minAlpha = 0.5f;
    public float maxAlpha = 1f;

    private float t = 0f;

    void Update()
    {
        t += Time.deltaTime * pulseSpeed;
        float alpha = Mathf.Lerp(minAlpha, maxAlpha, Mathf.Sin(t));
        rawImage.color = new Color(rawImage.color.r, rawImage.color.g, rawImage.color.b, alpha);
    }
}
