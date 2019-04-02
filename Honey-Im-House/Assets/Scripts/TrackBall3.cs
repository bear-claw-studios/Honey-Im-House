using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class TrackBall3 : MonoBehaviour
{
    //I'm gonna wreck it

    //Component reference
    Rigidbody rb;

    //Thanks to this video https://www.youtube.com/watch?v=kplusZYqBok

    Vector3 prevPos = Vector3.zero;
    Vector3 posDelta = Vector3.zero;
    Vector3 origin = Vector3.zero;
    private DateTime freezeTime = DateTime.MinValue;

    public float lerpRate;
    public float rotationSpeed;
    //Force of torque when mouse is let up
    public float TorqueCoefficient;
    //Force of torque while mouse is being dragged
    public float TorqueDragCoefficient;
    public float MaxAngularVelocity;

    public float torqueMagnitude;
    public float torqueThreshold;

    //The force to add upon letting go
    public Vector3 lastTorque;

    //Position of previous touch
    public Vector2 lastPos;


    //for the UI button to rotate back
    public bool returnPressed;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.maxAngularVelocity = MaxAngularVelocity;
        prevPos = Input.mousePosition;
    }

    void OnMouseDrag()
    {
        var newTorque = Vector3.up * -Input.GetAxis("Mouse X") + Vector3.right * Input.GetAxis("Mouse Y");

        if (newTorque == Vector3.zero)
            rb.freezeRotation = true;
        else
            rb.freezeRotation = false;

        //Update lastTorque so it can be used in OnMouseUp
        lastTorque = newTorque;
        torqueMagnitude = newTorque.magnitude;
        //if (torqueMagnitude > torqueThreshold)
            rb.AddTorque(newTorque.normalized * TorqueDragCoefficient);
        
        //A worthy attempt
        //rb.rotation = Quaternion.Euler(rb.rotation.eulerAngles + new Vector3(Input.GetAxis("Mouse Y"), -Input.GetAxis("Mouse X"), 0.0f));
    }

    void OnMouseUp()
    {
        rb.AddTorque(lastTorque.normalized * TorqueCoefficient);
    }

    private void FixedUpdate()
    {
        if (Input.GetButton("Return") || Input.GetMouseButton(1) || returnPressed)
        {
            if (!rb.freezeRotation)
            {
                ReturnToOriginalRotation();
            }
        }
        else if (rb.freezeRotation && freezeTime <= DateTime.Now.AddSeconds(-1))
        {
            rb.freezeRotation = false;
        }
    }

    public void ReturnToOriginalRotation()
    {
        float abs = Mathf.Abs(Quaternion.Dot(rb.rotation, Quaternion.Euler(origin)));
        if (abs >= 0.999f)
        {
            rb.angularVelocity = Vector3.zero;
            rb.freezeRotation = true;
            freezeTime = DateTime.Now;
        }
        else
        {
            var target = Quaternion.Euler(origin) * Quaternion.Inverse(rb.rotation);
            rb.AddTorque(target.x, target.y, target.z, ForceMode.VelocityChange);
        }
    }

    public void Freeze()
    {
        rb.freezeRotation = true;
    }

    public void ReturnPressed()
    {
        returnPressed = true;
    }

    public void ReturnReleased()
    {
        returnPressed = false;
    }
}
