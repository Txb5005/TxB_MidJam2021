using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Manager : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] List<AudioClip> audioClips = new List<AudioClip>();
    List<AudioSource> sfx = new List<AudioSource>();

    public static Audio_Manager Instance { get; private set; }

    void Awake()
    {
        if (Instance == null)
        {
            audioSource = GetComponent<AudioSource>();
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            NewScene();
            Destroy(gameObject);
            return;
        }
    }

    void NewScene()
    {

    }
    public void PlayAudioClip(string audioName)
    {
        foreach (var item in audioClips)
        {
            if (item.name == audioName)
            {
                audioSource.clip = item;
                audioSource.Play();
            }
        }
    }
    public void ChangeSFXVolume()
    {

    }
}
