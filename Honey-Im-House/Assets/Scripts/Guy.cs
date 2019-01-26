using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guy : MonoBehaviour
{
    public enum GuyState
    {
        Red,
        Green
    }

    public GuyState State;
    public Material RedMaterial;
    public Material GreenMaterial;

    void Start()
    {
    }
    
    void Update()
    {
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Green")
        {
            State = GuyState.Green;
            Renderer renderer = GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.material = GreenMaterial;
            }
        }
    }
}