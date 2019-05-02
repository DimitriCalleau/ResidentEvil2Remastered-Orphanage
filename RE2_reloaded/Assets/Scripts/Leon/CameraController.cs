using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    //caméra movement

    public float yaw;
    public float pitch;
    public float sensitivityX;
    public float sensitivityY;
    public Transform target;
    public float distance;
    public float maxAngle;
    public float minAngle;
    public float rotationSmoothTime;
    Vector3 rotationSmoothVelocity;
    Vector3 currentRotation;
    
    void Update()
    {
        if (Time.timeScale == 1)
        {
            pitch += Input.GetAxis("Horizontal2") * sensitivityX;
            yaw += Input.GetAxis("Vertical2") * sensitivityY;
            pitch = Mathf.Clamp(pitch, minAngle, maxAngle);

            currentRotation = Vector3.SmoothDamp(currentRotation, new Vector3(pitch, yaw), ref rotationSmoothVelocity, rotationSmoothTime);

            Vector3 targetRotation = new Vector3(pitch, yaw, 0);
            transform.eulerAngles = targetRotation;
            transform.eulerAngles = currentRotation;
            transform.position = target.position - transform.forward * distance;
        }
    }
}
