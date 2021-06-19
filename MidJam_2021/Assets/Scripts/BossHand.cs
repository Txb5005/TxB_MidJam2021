using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHand : MonoBehaviour
{
    public float currentSpeed;
    Rigidbody rb;
    Camera cam;
    PlayerCharacter player;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cam = GameObject.FindObjectOfType<Camera>();
        player = GameObject.FindObjectOfType<PlayerCharacter>();
        currentSpeed = player.maxSpeed - .5f;
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
            other.gameObject.GetComponent<AI_GingerBread>().die();  // Kill Gingerbread
            // Possible Animation (Hand grabbing gingerbread)
            // Sound FX (Crunch)
            // Particle FX (Crumbs/Pieces of gingerbread flying)
            StartCoroutine(cam.Shake(.3f, .15f)); // Camera Shake function
            currentSpeed += .1f;  // Potential increase of boss speed and player max speed
            player.maxSpeed += .1f;
        }

        if (other.gameObject.GetComponent<PlayerCharacter>())
        {
            // Death animation
            // Stop game play
            // Lose Screen
        }
    }
}
