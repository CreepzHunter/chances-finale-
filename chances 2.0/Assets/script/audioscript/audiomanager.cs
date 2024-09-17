using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audiomanager : MonoBehaviour
{
    [Header("Audio Source")]

    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("Audio Clip")]
    public AudioClip Background;
    public AudioClip pickup;

    void Start()
    {
        musicSource.clip = Background;
        musicSource.Play();
    }

    public void sfxSound(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
