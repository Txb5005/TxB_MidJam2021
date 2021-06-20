using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Manager : MonoBehaviour
{
    [SerializeField] List<AudioClip> uiAudio = new List<AudioClip>();
    [SerializeField] List<AudioClip> bgMusicAudio = new List<AudioClip>();

    List<AudioSource> sfxSources = new List<AudioSource>();
    [HideInInspector] public float sfxAudioPercent = 1;
    [HideInInspector] public AudioSource bgMusicSource;
    [HideInInspector] public int bgMusicSong = 0;

    public static Audio_Manager Instance { get; private set; }

    void Awake()
    {
        if (Instance == null)
        {
            NewInstance();
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Instance.OldInstance();
            Destroy(gameObject);
            return;
        }
    }

    void NewInstance()
    {
        GetBGMusicAudioSource();
        OldInstance();
    }
    void OldInstance()
    {
        GetAllSFXAudioSources();
        ChangeSFXVolume(sfxAudioPercent);
    }
    void GetBGMusicAudioSource()
    {
        bgMusicSource = GameObject.Find("BG Music").GetComponent<AudioSource>();
    }
    void GetAllSFXAudioSources()
    {
        AudioSource[] audioSources = FindObjectsOfType<AudioSource>();
        List<AudioSource> audioSourcesList = new List<AudioSource>();
        foreach (var item in audioSources)
        {
            audioSourcesList.Add(item);
        }
        sfxSources = audioSourcesList;
        for (int i = sfxSources.Count - 1; i >= 0; i--)
        {
            if (sfxSources[i] == bgMusicSource)
            {
                sfxSources.RemoveAt(i);
                return;
            }
        }
    }
    public void PlayUIAudio(string audioClipName)
    {
        AudioSource aS = GetUnplayingAudioSource(sfxSources);
        if (aS)
        {
            AudioClip aC = GetAudioClip(uiAudio, audioClipName);
            if (aC)
            {
                PlayAudioClip(aS, aC);
            }
        }
    }
    AudioSource GetUnplayingAudioSource(List<AudioSource> audioSources)
    {
        foreach (var item in audioSources)
        {
            if (item && !item.isPlaying)
            {
                return item;
            }
        }
        return null;
    }
    AudioClip GetAudioClip(List<AudioClip> audioClips, string audioClipName)
    {
        foreach (var item in audioClips)
        {
            if (item.name == audioClipName)
            {
                return item;
            }
        }
        return null;
    }
    void PlayAudioClip(AudioSource audioSource, AudioClip audioClip)
    {
        audioSource.clip = audioClip;
        audioSource.Play();
    }
    public void ChangeSFXVolume(float _sfxAudioPercent)
    {
        sfxAudioPercent = _sfxAudioPercent;
        foreach (var item in sfxSources)
        {
            if (item)
            {
                item.volume = sfxAudioPercent;
            }
        }
    }
    public void ChangeBGMusicVolume(float _bgMusicAudioPercent)
    {
        bgMusicSource.volume = _bgMusicAudioPercent;
    }
    public void ChangeBGMusic(string bgMusicName)
    {
        if (bgMusicSource.clip != null && bgMusicSource.clip.name != bgMusicName)
        {
            if (bgMusicName == "Country")
            {
                bgMusicSong = 0;
            }
            else
            {
                bgMusicSong = 1;
            }
            AudioClip aC = GetAudioClip(bgMusicAudio, bgMusicName);
            if (aC)
            {
                PlayAudioClip(bgMusicSource, aC);
            }
        }
    }
}
