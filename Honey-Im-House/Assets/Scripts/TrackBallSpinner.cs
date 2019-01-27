using System;
using UnityEngine;

public class TrackBallSpinner : MonoBehaviour
{
    //Component reference
    Rigidbody rb;

    //Thanks to this video https://www.youtube.com/watch?v=kplusZYqBok

    Vector3 prevPos = Vector3.zero;
    Vector3 posDelta = Vector3.zero;
    Vector3 origin = Vector3.zero;
    private DateTime freezeTime = DateTime.MinValue;

    public float lerpRate;
    public float rotationSpeed;
    public RagdollOnCommand rdoc;
    public bool hasItMovedYet;
    public float TorqueCoefficient;
    public float MaxAngularVelocity;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.maxAngularVelocity = MaxAngularVelocity;
        prevPos = Input.mousePosition;
        rdoc = FindObjectOfType<RagdollOnCommand>();
        hasItMovedYet = false;
    }

    void OnMouseDrag()
    {
        rb.AddTorque(Vector3.up * TorqueCoefficient * -Input.GetAxis("Mouse X"));
        rb.AddTorque(Vector3.right * TorqueCoefficient * Input.GetAxis("Mouse Y"));
    }

    private void FixedUpdate()
    {
        if (Input.GetButton("Return") || Input.GetMouseButton(1))
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
}