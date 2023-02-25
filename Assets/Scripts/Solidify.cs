using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Solidify : MonoBehaviour
{
    public BoxCollider2D box;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("ToggleIsTrigger", 0.1f);
    }

    void ToggleIsTrigger()
    {
        box.isTrigger = false;
    }

}
