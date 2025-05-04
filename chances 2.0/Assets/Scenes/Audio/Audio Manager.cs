using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Source")]
    [SerializeField] AudioSource MusicSource;
    [SerializeField] AudioSource SFXSource;
    [Header("Audio Clips")]

    [Header("Background")]
    public AudioClip Background;
    public AudioClip ScaryBackground;

    [Header("Background")]
    public AudioClip Click;

    private void Start()
    {
        MusicSource.clip = Background;
        MusicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

    public void PlayMusic(AudioClip music)
    {
        if (music != null)
        {
            MusicSource.Stop();
            MusicSource.clip = music;
            MusicSource.Play();
        }
    }

}
