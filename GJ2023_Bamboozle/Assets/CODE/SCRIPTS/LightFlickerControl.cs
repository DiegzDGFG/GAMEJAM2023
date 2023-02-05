using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlickerControl : MonoBehaviour
{

    public float minIntensity = 0.5f;
    public float maxIntensity = 1f;
    public float flickerSpeed = 0.1f;

    private Light pointLight;
    private float targetIntensity;

    void Start()
    {
        pointLight = GetComponent<Light>();
        targetIntensity = Random.Range(minIntensity, maxIntensity);
    }

    void Update()
    {
        pointLight.intensity = Mathf.Lerp(pointLight.intensity, targetIntensity, flickerSpeed * Time.deltaTime);

        if (Mathf.Abs(pointLight.intensity - targetIntensity) < 0.01f)
        {
            targetIntensity = Random.Range(minIntensity, maxIntensity);
        }
    }
}
