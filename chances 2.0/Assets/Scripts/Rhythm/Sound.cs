using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public AudioClip musicClip;  // Your .wav file
    private AudioSource audioSource;  // Audio source to play the clip


    void Start()
    {
        // Add an AudioSource component to the GameObject and assign the music clip
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = musicClip;
        audioSource.Play();  // Play the music
    }
}

