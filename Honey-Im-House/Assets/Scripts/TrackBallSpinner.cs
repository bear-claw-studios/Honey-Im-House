using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackBallSpinner : MonoBehaviour
{
    //Component reference
    Rigidbody rb;

    //Thanks to this video https://www.youtube.com/watch?v=kplusZYqBok

    Vector3 prevPos = Vector3.zero;
    Vector3 posDelta = Vector3.zero;

    Vector3 origin = Vector3.zero;
    public float lerpRate;
    public float rotationSpeed;

    public RagdollOnCommand rdoc;

    public bool hasItMovedYet;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        prevPos = Input.mousePosition;
        rdoc = FindObjectOfType<RagdollOnCommand>();
        hasItMovedYet = false;
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if(!hasItMovedYet)
            {
                hasItMovedYet = true;
                rdoc.GoRagdoll();
            }
            posDelta = Input.mousePosition - prevPos;
            if (Vector3.Dot(transform.up, Vector3.up) >= 0)
            {
                transform.Rotate(transform.up, -Vector3.Dot(posDelta, Camera.main.transform.right), Space.World);
            }
            else
            {
                transform.Rotate(transform.up, -Vector3.Dot(posDelta, Camera.main.transform.right), Space.World);
            }

            transform.Rotate(Camera.main.transform.right, Vector3.Dot(posDelta, Camera.main.transform.up), Space.World);
        }

        prevPos = Input.mousePosition;
    }

    private void FixedUpdate()
    {
        if (Input.GetButton("Return") || Input.GetMouseButton(1))
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
