using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OuverturePorte : MonoBehaviour
{
    private bool isOpenedRight;
    private bool isOpenedLeft;
    private bool detectRight;
    private bool detectLeft;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray rightRay = new Ray(transform.position, Vector3.right);
        Ray leftRay = new Ray(transform.position, Vector3.left);
        if(Physics.Raycast(rightRay, out hit))
        {
            if (hit.collider.tag == "Player")
            {
                detectRight = true;
            }
            else
            {
                detectRight = false;
            }
        }
        if (Physics.Raycast(leftRay, out hit))
        {
            if (hit.collider.tag == "Player")
            {
                detectLeft = true;
            }
            else
            {
                detectLeft = false;
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            if (detectRight == true)
            {

            }
            
            if (detectLeft == true)
            {

            }
        }
    }
} 

