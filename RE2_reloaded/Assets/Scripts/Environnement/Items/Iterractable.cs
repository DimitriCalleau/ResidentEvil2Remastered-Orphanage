using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Iterractable : MonoBehaviour
{
    public Transform Cam;

    private void Update()
    {
        transform.LookAt(Cam, Vector3.up);
    }
}
