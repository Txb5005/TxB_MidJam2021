using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    [Header("Assigned")]
    public AudioSource audioSource;
    public PlayerCharacter player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerCharacter>(); //finds the player characater
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<PlayerCharacter>())
        {
            audioSource.Play();
            player.IncreaseSpeed();
            Destroy(gameObject, .3f); //When player enters trigger call increase speed function in player character script and delete object after
        }
    }
}
