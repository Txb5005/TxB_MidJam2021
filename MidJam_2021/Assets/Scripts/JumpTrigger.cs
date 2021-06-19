using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpTrigger : MonoBehaviour
{
    public PlayerCharacter player;

    public void Start()
    {
        player = FindObjectOfType<PlayerCharacter>();

    }

    public void OnTriggerStay(Collider other)
    {
        if(other.tag == "Floor")
        {
            player.canJump = true;
        }
    }
}
