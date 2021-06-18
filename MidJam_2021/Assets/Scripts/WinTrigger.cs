using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    [Header("Assigned")]
    public GameObject winScreen;
    public PlayerCharacter player;
    public AudioSource audioSource;

    public void Start()
    {
        player = FindObjectOfType<PlayerCharacter>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<PlayerCharacter>())
        {
            //winscreen pop up
            audioSource.Play();
            Time.timeScale = 0;
        }
    }


}
