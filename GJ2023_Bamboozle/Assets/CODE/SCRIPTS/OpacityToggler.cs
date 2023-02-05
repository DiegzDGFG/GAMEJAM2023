using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpacityToggler : MonoBehaviour
{
    public Material material;
    public float interval = 1f;

    private void Start()
    {
        ResetOpacity();
        StartCoroutine(ToggleOpacity());
    }

    private void ResetOpacity()
    {
        material.color = new Color(material.color.r, material.color.g, material.color.b, 1);
    }

    private IEnumerator ToggleOpacity()
    {
        while (true)
        {
            material.color = new Color(material.color.r, material.color.g, material.color.b, 0);
            yield return new WaitForSeconds(interval);
            material.color = new Color(material.color.r, material.color.g, material.color.b, 1);
            yield return new WaitForSeconds(interval);
        }
    }
}
