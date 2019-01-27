using UnityEngine;

public class Trigger : MonoBehaviour
{
    void Start()
    {
    }

    void Update()
    {
    }

    void OnTriggerEnter(Collider other)
    {
        var x = other.transform.root.gameObject;
        if (x.tag == "Guy")
        {
            Destroy(x);
        }
    }
}