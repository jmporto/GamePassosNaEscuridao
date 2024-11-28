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

    private const float MIN_VOLUME = -80f;  // Valor mínimo do volume (dB)
    private const float MAX_VOLUME = 0f;     // Valor máximo do volume (dB)

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
        float dbValue = Mathf.Lerp(MAX_VOLUME, MIN_VOLUME, 1 - volume); 
        myMixer.SetFloat("music", dbValue);
        PlayerPrefs.SetFloat("musicVolume", volume);
    }

    public void SetSFXVolume() {
        float volume = sfx.value;
        float dbValue = Mathf.Lerp(MAX_VOLUME, MIN_VOLUME, 1 - volume);
        myMixer.SetFloat("sfx", dbValue);
        PlayerPrefs.SetFloat("sfxVolume", volume);
    }

    public void LoadVolume() {
        music.value = PlayerPrefs.GetFloat("musicVolume");
        sfx.value = PlayerPrefs.GetFloat("sfxVolume");

        SetMusicVolume();
        SetSFXVolume();
    }
}
