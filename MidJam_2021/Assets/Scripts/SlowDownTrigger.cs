using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowDownTrigger : MonoBehaviour
{
    [Header("Assigned")]
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
            player.DecreaseSpeed();
            audioSource.Play();
        }
    }
}
