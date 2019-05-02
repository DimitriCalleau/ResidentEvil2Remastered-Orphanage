using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    //mvt
    public float walkSpeed = 3;
    public float runSpeed = 6;
    public float aimSpeed = 1;
    public float turnSmoothTime = 0.2f;
    public float turnSmoothVelocity;
    public float speedSmoothTime = 0.1f;
    public float speedSmoothVelocity;
    public float currentSpeed;
    public bool isAiming;
    public bool isRunning;
    public bool detectObject;
    public float targetRotation;

    //public Animator animator;
    public Transform Camera;

    private void Update()
    {
        if(Time.timeScale == 1)
        {
            isRunning = Input.GetButton("Left Shift");
            if (Input.GetMouseButton(1))
            {
                isAiming = true;
            }
            else
            {
                isAiming = false;
            }
            Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            Vector3 inputDir = input.normalized;

            if (isAiming)
            {
                targetRotation = Camera.eulerAngles.y;
                transform.eulerAngles = Vector3.up * targetRotation;
            }
            else
            {
                targetRotation = Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg + Camera.eulerAngles.y;
                transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref turnSmoothVelocity, turnSmoothTime);
            }

            float targetSpeed = ((isRunning) ? runSpeed : walkSpeed) * inputDir.magnitude;
            if (isAiming)
            {
                targetSpeed = aimSpeed * inputDir.magnitude;
            }
            currentSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref speedSmoothVelocity, speedSmoothTime);

            transform.Translate(transform.forward * currentSpeed * Time.deltaTime, Space.World);
        }
    }

}
