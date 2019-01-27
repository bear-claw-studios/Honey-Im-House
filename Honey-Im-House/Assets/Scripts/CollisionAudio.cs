using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionAudio : MonoBehaviour
{
    AudioSource audio;
    public AudioClip[] grunts;

    public float gruntCooldown, timeOfLastGrunt;

    void Awake()
    {
        audio = GetComponent<AudioSource>();
        AssignNewGrunt();
    }

    public void Grunt()
    {
        if (Time.time - timeOfLastGrunt >= gruntCooldown)
        {
            AssignNewGrunt();
            audio.Play();
            timeOfLastGrunt = Time.time;
        }
    }

    public void AssignNewGrunt()
    {
        audio.clip = audio.clip = grunts[Random.Range(0, grunts.Length - 1)];
    }
}
