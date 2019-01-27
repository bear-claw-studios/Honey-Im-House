using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendMessageToParent : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        SendMessageUpwards("Grunt");
    }
}
