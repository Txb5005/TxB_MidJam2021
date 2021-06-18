using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    [Header("Stats")]
    public float speed = 5;
    public float jumpHeight = 5;

    [Header("Assigned Objects")]
    public Rigidbody rb;

    [Header("Bools")]
    public bool canJump;

    public void Update()
    {
        //Movement Foward
        if (Input.GetKey(KeyCode.W)) 
        {
            rb.velocity = new Vector3(speed, rb.velocity.y, rb.velocity.z);
        }
        //if (Input.GetKey(KeyCode.S))
        //{
        //    rb.velocity = new Vector3(-speed, 0);
        //}

        //Movement Left
        if(Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, speed);
        }
        //Movement Right
        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, -speed);
        }
        //Movement Jump
        if (Input.GetKey(KeyCode.Space))
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpHeight, rb.velocity.z);
        }
    }
   
}
