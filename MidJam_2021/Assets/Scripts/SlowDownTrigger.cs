using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowDownTrigger : MonoBehaviour
{
    public PlayerCharacter player;

    public void Start()
    {
        player = FindObjectOfType<PlayerCharacter>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if(player)
        {
            player.DecreaseSpeed();
        }
    }
}
