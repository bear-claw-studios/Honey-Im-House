using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollOnCommand : MonoBehaviour
{
    //Thanks buds https://answers.unity.com/questions/1287258/how-to-make-an-enemy-ragdoll-on-death.html

    //This script is meant to keep the model from Ragdolling until the camera's first move
    void Start()
    {
        SetKinematic(true);
    }

    void SetKinematic(bool newValue)
    {
        Rigidbody[] bodies = GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody rb in bodies)
            rb.isKinematic = newValue;
    }

    public void GoRagdoll()
    {
        SetKinematic(false);
        GetComponent<Animator>().enabled = false;
    }
}
