using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseController : MonoBehaviour
{
    Rigidbody rb;

    public float rotateSpeed;
    public float h, v, rsh;
    //input threshold for h, v, and rsh
    public float threshold;

    public float lerpRate;

    Vector3 origin = new Vector3(-90.0f, 0.0f, -180.0f);
    public float diffX, diffY, diffZ;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateDifference();
        //Basic rotation
        h = Input.GetAxis("LeftStickHorizontal");
        v = Input.GetAxis("LeftStickVertical");
        rsh= Input.GetAxis("RightStickHorizontal");

        if (Mathf.Abs(h) < threshold)
            h = 0.0f;
        if (Mathf.Abs(v) < threshold)
            v = 0.0f;
        if (Mathf.Abs(rsh) < threshold)
            rsh = 0.0f;

        Vector3 input = new Vector3(v, rsh, h);

        transform.Rotate(input * rotateSpeed);
    }
    
    void UpdateDifference()
    {
        diffX = Mathf.Abs(transform.rotation.eulerAngles.x - origin.x);
        diffY = Mathf.Abs(transform.rotation.eulerAngles.y - origin.y);
        diffZ = Mathf.Abs(transform.rotation.eulerAngles.z - origin.z);
    }
    

    private void FixedUpdate()
    {
        if (Input.GetButton("Return"))
            HandleNormalRotation();
    }

    //Return cube to its original orientation
    public void HandleNormalRotation()
    {
        //Whatever man
       
        Vector3 thresholdVector = new Vector3(1.0f, 1.0f, 1.0f);

        //bool withinThreshold = IsWithinThreshold();

        if (transform.rotation != Quaternion.Euler(origin))
        //if(!withinThreshold)
        {
            Quaternion current = transform.rotation;
            //Vector3 currentRotation = current.eulerAngles;
            //Using the lerp function allows a smoother rotation towards the origin instead of snapping into place
            //Vector3 newRotation = Vector3.Lerp(currentRotation, origin, lerpRate);
            //Quaternion rotationSet = Quaternion.Euler(newRotation);
            //transform.rotation = rotationSet;

            Quaternion newRotation = Quaternion.Slerp(current, Quaternion.Euler(origin), lerpRate);
            transform.rotation = newRotation;        
        }
    }

    public bool IsWithinThreshold()
    {
        if (diffX < 5.0f)
            return true;
        else if (diffY < 5.0f)
            return true;
        else if (diffZ < 5.0f)
            return true;
        else
            return false;
    }
}
