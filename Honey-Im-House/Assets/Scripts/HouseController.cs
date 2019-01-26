using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseController : MonoBehaviour
{
    Rigidbody rb;

    public float rotateSpeed;
    public float h, v, rsh;

    public float lerpRate;

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
        Vector3 input = new Vector3(v, rsh, h);

        if (Input.GetButton("Return"))
            HandleNormalRotation();

        transform.Rotate(input * rotateSpeed);
    }

    //Return cube to its original orientation
    public void HandleNormalRotation()
    {
        //Whatever man
        Vector3 origin = new Vector3(90.0f, 0.0f, 180.0f);
        if (transform.rotation != Quaternion.Euler(origin))
        {
            Quaternion current = transform.rotation;
            Vector3 currentRotation = current.eulerAngles;
            //Using the lerp function allows a smoother rotation towards the origin instead of snapping into place
            Vector3 newRotation = Vector3.Lerp(currentRotation, origin, lerpRate);
            Quaternion rotationSet = Quaternion.Euler(newRotation);
            transform.rotation = rotationSet;
        }
    }
}
