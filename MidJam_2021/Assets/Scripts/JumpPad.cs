using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    [Header("Stats")]
    public float jumpForce;

    [Header("Assigned")]
    public PlayerCharacter player;
    public AudioSource audioSource;

    public void Start()
    {
        // At very start find and assign the objects
        player = FindObjectOfType<PlayerCharacter>();
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerCharacter>())
        {
            player.GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce);
            audioSource.Play();
        }
    }
}
