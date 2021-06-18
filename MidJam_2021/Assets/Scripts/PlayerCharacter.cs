using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    [Header("Stats")]
    public float maxSpeed = 10;
    public float currentSpeed = 5;
    public float minSpeed = 5;
    public float jumpHeight = 5;

    [Header("Timers")]
    public float waitTime = 5;
    public float slowdowntimer;

    [Header("Assigned Objects")]
    public Rigidbody rb;

    [Header("Bools")]
    public bool canJump;

    public void Start()
    {
 
    }
    public void Update()
    {
        slowdowntimer += Time.deltaTime;

        //player is always moving foward
        rb.velocity = new Vector3(currentSpeed, rb.velocity.y, rb.velocity.z);

        if(slowdowntimer >= waitTime)
        {
            currentSpeed -= 1f; //when slowdowntimer is greater than waittime decrease the current speed
            if (currentSpeed <= minSpeed)
            {
                currentSpeed = minSpeed; //if current speed is lower than min speed set it to min speed
            }
            slowdowntimer -= waitTime;
        }

        if(currentSpeed >= maxSpeed)
        {
            currentSpeed = maxSpeed; // if current speed is greater than max set current speed to max speed
        }



        ////Movement Foward
        //if (Input.GetKey(KeyCode.W)) 
        //{
        //    rb.velocity = new Vector3(speed, rb.velocity.y, rb.velocity.z);
        //}

        //Movement Backward
        //if (Input.GetKey(KeyCode.S))
        //{
        //    rb.velocity = new Vector3(-speed, 0);
        //}

        //Movement Left
        if(Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, currentSpeed);
        }
        //Movement Right
        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, -currentSpeed);
        }
        //Movement Jump
        if (Input.GetKey(KeyCode.Space))
        {
            if(canJump == true)
            {
                rb.velocity = new Vector3(rb.velocity.x, jumpHeight, rb.velocity.z);
                canJump = false; //player can't jump again
            }

        }
    }

    public void IncreaseSpeed()
    {
        currentSpeed += 1f;
    }
     void OnCollisionStay(Collision collision)
    {
        //When player is on the ground, player can jump again
        canJump = true;
    }

}
