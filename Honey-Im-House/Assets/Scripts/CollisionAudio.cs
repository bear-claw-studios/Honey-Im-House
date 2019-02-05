using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionAudio : MonoBehaviour
{
    Rigidbody rb;

    AudioSource audio;
    public AudioClip[] impacts;

    public float gruntCooldown, timeOfLastGrunt, magnitudeThreshold;

    public MusicController mc;
    public GameObject explosionEffect;
    public float exploisionForce;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
        AssignNewGrunt();
        mc = FindObjectOfType<MusicController>();
    }

    public void Grunt(float magnitude)
    {
        if (Time.time - timeOfLastGrunt >= gruntCooldown && magnitude >= magnitudeThreshold && !audio.isPlaying)
        {
            //Instantiate(explosionEffect, transform.position, transform.rotation);
            //rb.AddExplosionForce(exploisionForce, transform.position, 0.2f);
            AssignNewGrunt();
            audio.Play();
            timeOfLastGrunt = Time.time;
        }
    }

    public void AssignNewGrunt()
    {
        audio.clip = impacts[Random.Range(0, impacts.Length - 1)];
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Radio"))
            mc.SkipTrack();

        if (other.gameObject.CompareTag("CollisionAudioSource"))
            other.SendMessageUpwards("PlayAudio");
    }
}
