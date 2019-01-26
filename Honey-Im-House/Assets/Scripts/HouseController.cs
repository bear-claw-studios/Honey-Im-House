using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseController : MonoBehaviour
{
    //Component reference
    Rigidbody rb;

    public float rotateSpeed;
    public float h, v, rsh;
    //input threshold for h, v, and rsh
    public float threshold;

    public float lerpRate;

    Vector3 origin = //new Vector3(-90.0f, 0.0f, -180.0f);
        new Vector3(0.0f, 0.0f, 0.0f);
    public float diffX, diffY, diffZ;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Basic rotation
        h = Input.GetAxis("LeftStickHorizontal");
        v = Input.GetAxis("LeftStickVertical");
        rsh= Input.GetAxis("RightStickHorizontal");

        //Prevents any trace inputs from the controller from manipulating the house
        if (Mathf.Abs(h) < threshold)
            h = 0.0f;
        if (Mathf.Abs(v) < threshold)
            v = 0.0f;
        if (Mathf.Abs(rsh) < threshold)
            rsh = 0.0f;

        Vector3 input = new Vector3(v, rsh, h);
        transform.Rotate(input * rotateSpeed);
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
