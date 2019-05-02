using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aiming : MonoBehaviour
{
    public float distance;
    public float normalDistance;
    public float aimingDistance;
    public float smooth = 10f;
    Vector3 def;
    public GameObject cameraBase;
    public GameObject Viseur;

    // Update is called once per frame
    private void Awake()
    {
        def = transform.localPosition.normalized;
        distance = transform.localPosition.magnitude;
    }
    private void Start()
    {
        Viseur.SetActive(false);
    }
    private void Update()
    {    
        if (Input.GetMouseButton(1))
        {
            distance = aimingDistance;
            Viseur.SetActive(true);

        }
        else
        {
            distance = normalDistance;
            Viseur.SetActive(false);
        }

        transform.localPosition = Vector3.Lerp(transform.localPosition, def * distance, Time.deltaTime * smooth);
    }
}
