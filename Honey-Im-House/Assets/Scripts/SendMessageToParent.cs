using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendMessageToParent : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        float magnitude = collision.relativeVelocity.magnitude;
        SendMessageUpwards("Grunt", magnitude);
        //Debug.Log(magnitude);
    }
}
