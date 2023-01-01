using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioOptionsManager : MonoBehaviour
{

    public Slider Music_VolumeSlider;
    public Slider Sound_Effects_VolumeSlider;
    public static float musicVolume { get; private set; }
    public static float soundEffectsVolume { get; private set; }

    [SerializeField] private Text musicSliderText = null;
    [SerializeField] private Text soundEffectsSliderText = null;
    public void OnMusicSliderValueChange(float value)
    {
        musicVolume = value;
        musicSliderText.text = Math.Floor((value * 100)).ToString();
        AudioManager.instance.updateMixerVolume();
    }

    public void OnSoundEffectSliderValueChange(float value)
    {
        soundEffectsVolume = value;
        soundEffectsSliderText.text = Math.Floor((value * 100)).ToString();
        AudioManager.instance.updateMixerVolume();
    }
    void LoadValues()
    {
        musicSliderText.text = PlayerPrefs.GetString("MusicText");
        musicVolume = PlayerPrefs.GetFloat("MusicVolume");
       // Music_VolumeSlider.value = musicVolume;
        

        soundEffectsSliderText.text = PlayerPrefs.GetString("SoundEffectsText");
        soundEffectsVolume = PlayerPrefs.GetFloat("SoundEffectVolume");
       //Sound_Effects_VolumeSlider.value = soundEffectsVolume;
        
    }
    public void Update()
    {
        // musicVolume = Music_VolumeSlider.value;
        // Sound_Effects_VolumeSlider.value = soundEffectsVolume ;
        PlayerPrefs.SetString("MusicText", musicSliderText.text);
        PlayerPrefs.SetFloat("MusicVolume", musicVolume);
        // PlayerPrefs.SetFloat("MusicSliderValue", Music_VolumeSlider.value);
        PlayerPrefs.SetString("SoundEffectsText", soundEffectsSliderText.text);
        PlayerPrefs.SetFloat("SoundEffectVolume", soundEffectsVolume);
        // PlayerPrefs.SetFloat("SoundEffectsSliderValue", Sound_Effects_VolumeSlider.value);
    }
    public void Start()
    {
       // LoadValues();
    }



}// end of class
