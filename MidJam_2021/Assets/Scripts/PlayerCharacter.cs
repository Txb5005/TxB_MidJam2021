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
    public MeshRenderer mesh;
    public GameObject losescreen;


    [Header("Bools")]
    public bool canJump;
    public bool isInvulnerable;

    public void Start()
    {
        rb = GetComponent<Rigidbody>();
        mesh = GetComponent<MeshRenderer>();
    }
    public void Update()
    {

        //player is always moving foward
        rb.velocity = new Vector3(currentSpeed, rb.velocity.y, rb.velocity.z);

        if (slowdowntimer >= waitTime)
        {
            currentSpeed -= 1f; //when slowdowntimer is greater than waittime decrease the current speed
            if (currentSpeed <= minSpeed)
            {
                currentSpeed = minSpeed; //if current speed is lower than min speed set it to min speed
            }
            slowdowntimer -= waitTime;
        }

        if (currentSpeed >= maxSpeed)
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
        if (Input.GetKey(KeyCode.A))
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
            if (canJump == true)
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

    public void DecreaseSpeed()
    {
        currentSpeed -= 1f;
    }

    public void Death()
    {

    }

    public void ToggleMesh()
    {
        if (mesh.enabled == true)
        {
            mesh.enabled = false;
        }
        else
        {
            mesh.enabled = true;
        }
    }

    public void ToggleInvulnerable()
    {
        isInvulnerable = true;

        if (isInvulnerable == true) // if bool is true start the coroutine for the "flash" timer is set for .25 seconds
        {
            StartCoroutine("startInvulnerable", .25f);
            
        }
    }

    IEnumerator startInvulnerable(float meshTimer)
    {
        while (isInvulnerable == true) // while the bool is true will "flash" the player character for a total of 3 seconds then stop
        {

            //ToggleMesh();
            //yield return new WaitForSeconds(.25f);
            //ToggleMesh();
            //yield return new WaitForSeconds(.25f);

            mesh.enabled = true;
            yield return new WaitForSeconds(meshTimer);
            mesh.enabled = false;
            yield return new WaitForSeconds(meshTimer);
            mesh.enabled = true;
            yield return new WaitForSeconds(meshTimer);
            mesh.enabled = false;
            yield return new WaitForSeconds(meshTimer);
            mesh.enabled = true;
            yield return new WaitForSeconds(meshTimer);
            mesh.enabled = false;
            yield return new WaitForSeconds(meshTimer);
            mesh.enabled = true;
            yield return new WaitForSeconds(meshTimer);
            mesh.enabled = false;
            yield return new WaitForSeconds(meshTimer);
            mesh.enabled = true;
            yield return new WaitForSeconds(meshTimer);
            mesh.enabled = false;
            yield return new WaitForSeconds(meshTimer);
            mesh.enabled = true;
            yield return new WaitForSeconds(meshTimer);
            mesh.enabled = false;
            yield return new WaitForSeconds(meshTimer);
            mesh.enabled = true;
            isInvulnerable = false;
            StopCoroutine("startInvulnerable");

        }
    }
    void OnCollisionStay(Collision collision)
    {
        //When player is on the ground, player can jump again
        canJump = true;
    }

}
