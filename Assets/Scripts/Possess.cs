using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Possess : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Floor")
        {
            Destroy(gameObject);

            //Game over
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ghost")
        {
           other.gameObject.GetComponent<PlayerController>().RunCoroutine("Human", 0.1f);
           Destroy(gameObject);
        }
    }
}
