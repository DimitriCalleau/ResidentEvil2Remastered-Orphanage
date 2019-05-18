using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OuverturePorte : MonoBehaviour
{
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
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            timer = 0;
        }

        RaycastHit hit;
        Ray rightRay = new Ray(transform.position, Vector3.back);
        Ray leftRay = new Ray(transform.position, Vector3.forward);
        if(Physics.Raycast(rightRay, out hit))
        {
            if (hit.collider.tag == "Player")
            {
                detectRight = true;
                Debug.Log("bof ");

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
        Debug.DrawRay(transform.position, Vector3.forward, Color.red);
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
        else
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
        }
    }
} 

