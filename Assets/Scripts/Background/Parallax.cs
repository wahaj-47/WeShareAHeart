using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{

    private float length, startPosition;
    public float intensity;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        float temp = (Camera.main.transform.position.x * (1 - intensity));
        float distance = (Camera.main.transform.position.x * intensity);

        Vector3 newPosition = transform.position;
        newPosition.x = startPosition + distance;
        transform.position = newPosition;

        if (temp > startPosition + length) startPosition += length;
        else if (temp < startPosition - length) startPosition -= length;
    }
}
