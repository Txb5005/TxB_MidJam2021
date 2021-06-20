using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    List<Toggle> bgMusicToggles = new List<Toggle>();
    Slider bgMusicVolumeSlider;
    Slider sfxVolumeSlider;

    void Awake()
    {
        GetBGMusicToggles();
        if (Audio_Manager.Instance.bgMusicSong == 0)
        {
            bgMusicToggles[0].isOn = true;
        }
        else
        {
            bgMusicToggles[1].isOn = true;
        }
        bgMusicVolumeSlider = GameObject.Find("BG Music Slider").GetComponent<Slider>();
        bgMusicVolumeSlider.value = Audio_Manager.Instance.bgMusicSource.volume;

        sfxVolumeSlider = GameObject.Find("SFX Slider").GetComponent<Slider>();
        sfxVolumeSlider.value = Audio_Manager.Instance.sfxAudioPercent;
    }
    void Update()
    {
        
    }

    void GetBGMusicToggles()
    {
        Transform t = GameObject.Find("Music Choices").transform;
        for (int i = 0; i < t.childCount; i++)
        {
            bgMusicToggles.Add(t.GetChild(i).GetComponent<Toggle>());
        }
    }
    public void ChangeSFXVolume()
    {
        Audio_Manager.Instance.ChangeSFXVolume(sfxVolumeSlider.value);
    }
    public void ChangeBGMusicVolume()
    {
        Audio_Manager.Instance.ChangeBGMusicVolume(bgMusicVolumeSlider.value);
    }
    public void ChangeBGMusic(string bgMusicName)
    {
        Audio_Manager.Instance.ChangeBGMusic(bgMusicName);
    }
}
