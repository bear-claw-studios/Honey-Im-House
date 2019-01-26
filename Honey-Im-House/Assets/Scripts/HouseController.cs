using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseController : MonoBehaviour
{
    //Rigidbody rb;

    public float rotateSpeed;

    // Start is called before the first frame update
    void Start()
    {
        //rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");

        transform.Rotate(new Vector3(0.0f, 0.0f, h * rotateSpeed));
        
        //rb.MoveRotation(Quaternion)
    }
}
