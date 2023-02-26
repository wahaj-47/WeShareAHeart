using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingWall : MonoBehaviour
{
    public GameObject wallObject;
    public float speed;

    // Update is called once per frame
    public void Update()
    {
        float y = Mathf.PingPong(Time.time* speed, 1) * 6 - 3;
        wallObject.transform.position = new Vector2(0, y);
        
    }
}
