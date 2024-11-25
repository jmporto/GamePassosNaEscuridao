using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioMixerScript : MonoBehaviour
{
    [SerializeField] private AudioMixer myMixer;
    [SerializeField] private Slider music;
    [SerializeField] private Slider sfx;

    public void Start() {
        if (PlayerPrefs.HasKey("musicVolume")) {
            LoadVolume();
        }
        else {
            SetMusicVolume();
        }
    }

    public void SetMusicVolume() {
        float volume = music.value;
        myMixer.SetFloat("music", Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("musicVolume", volume);
    }

    public void SetSFXVolume() {
        float volume = sfx.value;
        myMixer.SetFloat("sfx", Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("sfxVolume", volume);
    }

    public void LoadVolume() {
        music.value = PlayerPrefs.GetFloat("musicVolume");
        sfx.value = PlayerPrefs.GetFloat("sfxVolume");

        SetMusicVolume();
        SetSFXVolume();
    }
}
