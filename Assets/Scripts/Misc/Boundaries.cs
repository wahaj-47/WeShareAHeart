using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundaries : MonoBehaviour
{

    SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void LateUpdate()
    {

        float objectWidth = spriteRenderer.bounds.size.x / 2;
        float objectHeight = spriteRenderer.bounds.size.y / 2;

        Vector3 minScreenBounds = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 10));
        Vector3 maxScreenBounds = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 10));

        Vector3 viewPos = transform.position;

        viewPos.x = Mathf.Clamp(viewPos.x, minScreenBounds.x + objectWidth, maxScreenBounds.x - objectWidth);
        viewPos.y = Mathf.Clamp(viewPos.y, minScreenBounds.y + objectHeight, maxScreenBounds.y - objectHeight);

        transform.position = viewPos;
    }
}
