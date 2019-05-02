using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignalementItems : MonoBehaviour
{
    public Transform playerposition;
    public GameObject Interractable;
    public GameObject Pickable;
    // Start is called before the first frame update
    void Start()
    {
        Interractable.SetActive(false);
        Pickable.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        float vectorAB = ((gameObject.transform.position.x - playerposition.position.x) * (gameObject.transform.position.x - playerposition.position.x)) + ((gameObject.transform.position.z - playerposition.position.z) * (gameObject.transform.position.z - playerposition.position.z));
        float distance = Mathf.Sqrt(vectorAB);
        if (distance <= 2)
        {
            Interractable.SetActive(false);
            Pickable.SetActive(true);
        }
        else if (distance <= 5 && distance > 2)
        {
            Interractable.SetActive(true);
            Pickable.SetActive(false);
        }
        else
        {
            Interractable.SetActive(false);
            Pickable.SetActive(false);
        }
    }
}
