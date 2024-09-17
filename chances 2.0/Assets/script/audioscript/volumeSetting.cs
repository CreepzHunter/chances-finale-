using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class volumeSetting : MonoBehaviour
{
    [SerializeField] private AudioMixer myMixer;
    [SerializeField] private Slider slider;
    [SerializeField] private Slider SFXslider;

    private void Start()
    {
        if(PlayerPrefs.HasKey("musicVolume"))
        {
            loadVolume();
        }
        else
        {
            SetMusicVolume();
            SetSFXVolume();
        }
    }
    
    public void SetMusicVolume()
    {
        float volume = slider.value;
        myMixer.SetFloat("music",Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("musicVolume", volume);
    }

    public void SetSFXVolume()
    {
        float volume = SFXslider.value;
        myMixer.SetFloat("sfx",Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("sfxVolume", volume);
    }

    private void loadVolume()
    {
        slider.value = PlayerPrefs.GetFloat("musicVolume");
        SFXslider.value = PlayerPrefs.GetFloat("sfxVolume");

        SetMusicVolume();
        SetSFXVolume();
    }
}
