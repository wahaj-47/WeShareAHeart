using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Solidify : MonoBehaviour
{
    public CircleCollider2D circle;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("ToggleIsTrigger", 0.1f);
    }

    void ToggleIsTrigger()
    {
        circle.isTrigger = false;
        gameObject.layer = LayerMask.NameToLayer("Default");
    }

}
