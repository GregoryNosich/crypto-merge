using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SparksController : MonoBehaviour
{
    void Start()
    {
        Invoke("DestroySparks", 3f);
    }

    void DestroySparks()
    {
        Destroy(GetComponent<ParticleSystem>().gameObject);
    }
}
