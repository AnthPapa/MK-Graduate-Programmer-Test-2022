using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsScript : MonoBehaviour
{
    public AudioMixer Mixer;
    [SerializeField]
    private Slider musicSlider, soundFXSlider;

    void Start()
    {
        musicSlider.value = PlayerPrefs.GetFloat("Music", musicSlider.value);
        soundFXSlider.value = PlayerPrefs.GetFloat("SoundFX", soundFXSlider.value);
    }
    private void OnDisable()
    {
        PlayerPrefs.SetFloat("Music", musicSlider.value);
        PlayerPrefs.SetFloat("SoundFX", soundFXSlider.value);
    }

    public void MusicLevel(float sliderValue)
    {
        Mixer.SetFloat("Music", Mathf.Log10(sliderValue) * 20);
    }

    public void SoundFXLevel(float sliderValue)
    {
        Mixer.SetFloat("SoundFX", Mathf.Log10(sliderValue) * 20);
    }
}
