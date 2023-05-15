using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float followSpeed = 2f;
    public Transform target1;
    public Transform target2;

    void Update(){

        Vector3 newPosition = new Vector3((target1.position.x + target2.position.x)/2, (target1.position.y + target2.position.y)/2, -10f);
        transform.position = Vector3.Slerp(transform.position, newPosition, followSpeed*Time.deltaTime);
    }
    
}
