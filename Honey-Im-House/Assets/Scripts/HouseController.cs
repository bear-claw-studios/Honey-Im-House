using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseController : MonoBehaviour
{
    //Rigidbody rb;

    public float rotateSpeed;

    public float h, v, rsh;

    // Start is called before the first frame update
    void Start()
    {
        //rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxis("LeftStickHorizontal");
        v = Input.GetAxis("LeftStickVertical");
        rsh= Input.GetAxis("RightStickHorizontal");

        transform.Rotate(new Vector3(0.0f, 0.0f, h) * rotateSpeed);
        
        //rb.MoveRotation(Quaternion)
    }
}
