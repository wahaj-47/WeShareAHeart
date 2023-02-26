using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Possess : MonoBehaviour
{

    void Start()
    {
        Invoke("Die", 10.0f);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ghost")
        {
            CancelInvoke("Die");
            other.gameObject.GetComponent<PlayerController>().RunCoroutine("Human", 0.1f);
            Destroy(gameObject);
        }
    }

    void Die()
    {
        LevelLoader.instance.LoadLevelByIndex(3);
    }
}
