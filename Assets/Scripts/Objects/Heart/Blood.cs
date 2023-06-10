using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blood : MonoBehaviour
{
    public GameObject blood;

    public void Spray()
    {
        blood.SetActive(true);
    }
}
