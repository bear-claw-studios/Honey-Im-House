using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallToChangeTrack : MonoBehaviour
{
    public MusicController mc;

    void Awake()
    {
        mc = FindObjectOfType<MusicController>();
    }

    void OnTriggerEnter(Collider other)
    {
        mc.SkipTrack();
    }
}
