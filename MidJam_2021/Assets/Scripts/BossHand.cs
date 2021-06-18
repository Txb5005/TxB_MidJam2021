using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHand : MonoBehaviour
{
    public float currentSpeed;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        // Boss always moving forward
        rb.velocity = new Vector3(currentSpeed, rb.velocity.y, rb.velocity.z);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<AI_GingerBread>())
        {
            // Kill Gingerbread
            // Possible Animation (Hand grabbing gingerbread)
            // Sound FX (Crunch)
            // Particle FX (Crumbs/Pieces of gingerbread flying)
            // Camera Shake function
            // Potential increase of boss speed and player max speed
        }

        if (other.gameObject.GetComponent<PlayerCharacter>())
        {
            // Death animation
            // Stop game play
            // Lose Screen
        }
    }
}
