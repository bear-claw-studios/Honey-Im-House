using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackBallSpinner : MonoBehaviour
{
    //Thanks to this video https://www.youtube.com/watch?v=S3pjBQObC90

    public float rotationSpeed;

    Vector3 origin = new Vector3(0.0f, 0.0f, 0.0f);
    public float lerpRate;

    private void OnMouseDrag()
    {/*
        float rotationX = Input.GetAxis("Mouse X") * rotationSpeed * Mathf.Deg2Rad;
        float rotationY = Input.GetAxis("Mouse Y") * rotationSpeed * Mathf.Deg2Rad;

        transform.Rotate(Vector3.up, -rotationX, Space.World);
        transform.Rotate(Vector3.right, rotationY, Space.World);
        */

        float xAxisRotation = Input.GetAxis("Mouse X") * rotationSpeed;
        float yAxisRotation = Input.GetAxis("Mouse Y") * rotationSpeed;

        transform.Rotate(Vector3.down, xAxisRotation);
        transform.Rotate(Vector3.right, yAxisRotation);
    }

    private void FixedUpdate()
    {
        if (Input.GetButton("Return"))
            ReturnToOriginalRotation();
    }

    //Return cube to its original orientation
    public void ReturnToOriginalRotation()
    {
        if (transform.rotation != Quaternion.Euler(origin))
        {
            Quaternion current = transform.rotation;
            //Spherical lerp call to smoothly rotate the cube while the "Return" button is held down
            Quaternion newRotation = Quaternion.Slerp(current, Quaternion.Euler(origin), lerpRate);
            transform.rotation = newRotation;
        }
    }
}
