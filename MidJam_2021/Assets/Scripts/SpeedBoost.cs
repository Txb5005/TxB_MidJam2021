using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    public PlayerCharacter player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerCharacter>(); //finds the player characater
    }

    public void OnTriggerEnter(Collider other)
    {
        if(player)
        {
            player.IncreaseSpeed();
            Destroy(gameObject); //When player enters trigger call increase speed function in player character script and delete object after
        }
    }
}
