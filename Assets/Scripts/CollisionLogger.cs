using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionLogger : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D collision){
        Debug.Log(collision.gameObject.name);
    }
}
