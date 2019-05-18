using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OuverturePorte : MonoBehaviour
{
    private Vector3 positionRay;
    private bool isOpenedRight;
    private bool isOpenedLeft;
    private bool detectRight;
    private bool detectLeft;
    public Animator animator;
    public float time;
    public float timer;

    // Start is called before the first frame update
    void Start()
    {
        time = 0.25f;
        positionRay = new Vector3(-0.45f, 1, 0);
    }

    // Update is called once per frame
    void Update()
    {
    
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            timer = 0;
        }
        //Debug.Log(timer);

        RaycastHit hit1;
        RaycastHit hit2;
        Ray rightRay = new Ray(transform.position, transform.TransformDirection(Vector3.back));
        Ray leftRay = new Ray(transform.position, transform.TransformDirection(Vector3.forward));

        if (Physics.Raycast(rightRay, out hit1, Mathf.Infinity))
        {
           
            if (hit1.collider.tag == "Player")
            {
                Debug.Log("bof");
                detectRight = true;
            }
            else
            {
                detectRight = false;
            }
        }
        if (Physics.Raycast(leftRay, out hit2, Mathf.Infinity))
        {
            if (hit2.collider.tag == "Player")
            {
                Debug.Log("bof");
                detectLeft = true;
            }
            else
            {
                detectLeft = false;
            }
        }
        Debug.DrawRay(transform.position+positionRay,transform.TransformDirection( Vector3.forward), Color.red);
        Debug.DrawRay(transform.position+positionRay, transform.TransformDirection(Vector3.back ), Color.red);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            if (detectRight == true)
            {
                animator.SetBool("OpenRight", true);
            }
            
            if (detectLeft == true)
            {
                animator.SetBool("OpenLeft", true);
            }
        }
        /*else
        {
            animator.SetBool("OpenRight", false);
            animator.SetBool("OpenLeft", false);
            animator.SetBool("CloseLeft", true);
            animator.SetBool("CloseRight", true);
            timer += time;

            if(timer <= 0)
            {
                animator.SetBool("CloseLeft", false);
                animator.SetBool("CloseRight", false);
            }
        }*/
    }
} 

