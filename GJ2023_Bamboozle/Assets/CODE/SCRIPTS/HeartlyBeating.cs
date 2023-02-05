using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartlyBeating : MonoBehaviour
{
    public Sprite sprite1;
    public Sprite sprite2;

    public float switchInterval = 1.0f;  // time interval for switching between sprites

    private SpriteRenderer spriteRenderer;
    private float elapsedTime = 0.0f;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprite1;
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= switchInterval)
        {
            elapsedTime = 0.0f;

            // switch between sprites
            if (spriteRenderer.sprite == sprite1)
            {
                spriteRenderer.sprite = sprite2;
            }
            else
            {
                spriteRenderer.sprite = sprite1;
            }
        }
    }
}
