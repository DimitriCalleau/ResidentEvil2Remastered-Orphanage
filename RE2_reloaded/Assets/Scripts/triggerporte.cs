using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerporte : MonoBehaviour
{
    public GameObject porte;
    public bool trigger;

    public void OnTriggerEnter(Collider other)
    {
        if (trigger)
        {
            Debug.Log("Trigger");
            Destroy(porte);
        }
    }
}
