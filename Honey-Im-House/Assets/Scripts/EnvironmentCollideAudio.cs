using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentCollideAudio : MonoBehaviour
{
    public AudioSource audio;

    public void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    public void PlayAudio()
    {
        audio.Play();
    }
}
