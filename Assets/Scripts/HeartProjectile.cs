using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartProjectile : MonoBehaviour
{
    public Transform throwPoint;
    public GameObject HeartObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1")){
            Throw();
        }

    }

    void Throw(){
        Instantiate(HeartObject, throwPoint.position, throwPoint.rotation);
    }
}
