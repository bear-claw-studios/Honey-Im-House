using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public AudioSource currentTrack;
    public AudioClip[] otherTracks;

    void Start()
    {
        currentTrack = GetComponent<AudioSource>();
    }

    public void SkipTrack()
    {
        int index = Random.Range(0, otherTracks.Length - 1);
        AudioClip nextTrack = otherTracks[index];
        if (nextTrack == currentTrack)
            SkipTrack();
        currentTrack.clip = nextTrack;
        currentTrack.Play();
    }
}
