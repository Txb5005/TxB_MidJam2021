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
        isInvulnerable = false;
        StartCoroutine("slowlyDecreasePlayerSpeed", .35f);
    }
    public void Update()
    {

        //player is always moving foward
        rb.velocity = new Vector3(currentSpeed, rb.velocity.y, rb.velocity.z);

        if (currentSpeed <= minSpeed)
        {
            currentSpeed = minSpeed; //if current speed is lower than min speed set it to min speed
        }

        if (currentSpeed >= maxSpeed)
        {
            currentSpeed = maxSpeed; // if current speed is greater than max set current speed to max speed
        }

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

    public void ToggleInvulnerable()
    {
        isInvulnerable = true;
        // Play stumble animation

        if (isInvulnerable == true) // if bool is true start the coroutine for the "flash" timer is set for .25 seconds
        {
            StartCoroutine("startInvulnerable", .15f);
        }
    }

    public IEnumerator slowlyIncreasePlayerSpeed(float waitTime) // This function slowly increases the player speed over the specified time frame
    {
        while (isInvulnerable == true)
        {
            yield return new WaitForSeconds(waitTime);
            currentSpeed = currentSpeed + .5f;
        }
    }

    public IEnumerator slowlyDecreasePlayerSpeed(float waitTime) // This function slowly decreases the player speed over the specified wait time
    {
        while (isInvulnerable == false)
        {
            yield return new WaitForSeconds(waitTime);
            currentSpeed = currentSpeed -= .05f;
        }
    }

    IEnumerator startInvulnerable(float meshTimer)
    {
        while (isInvulnerable == true) // while the bool is true will "flash" the player character for a total of 3 seconds then stop
        {
            mesh.enabled = true;
            yield return new WaitForSeconds(meshTimer);
            mesh.enabled = false;
            yield return new WaitForSeconds(meshTimer); //2
            mesh.enabled = true;
            yield return new WaitForSeconds(meshTimer);
            mesh.enabled = false;
            yield return new WaitForSeconds(meshTimer); //4
            mesh.enabled = true;
            yield return new WaitForSeconds(meshTimer);
            mesh.enabled = false;
            yield return new WaitForSeconds(meshTimer); //6
            mesh.enabled = true;
            yield return new WaitForSeconds(meshTimer);
            mesh.enabled = false;
            yield return new WaitForSeconds(meshTimer); //8
            mesh.enabled = true;
            yield return new WaitForSeconds(meshTimer);
            mesh.enabled = false;
            yield return new WaitForSeconds(meshTimer); //10
            mesh.enabled = true;
            yield return new WaitForSeconds(meshTimer);
            mesh.enabled = false;
            yield return new WaitForSeconds(meshTimer); //12
            mesh.enabled = true;

            yield return new WaitForSeconds(meshTimer);
            mesh.enabled = false;
            yield return new WaitForSeconds(meshTimer); //14
            mesh.enabled = true;
            yield return new WaitForSeconds(meshTimer);
            mesh.enabled = false;
            yield return new WaitForSeconds(meshTimer); //16
            mesh.enabled = true;

            yield return new WaitForSeconds(meshTimer);
            mesh.enabled = false;
            yield return new WaitForSeconds(meshTimer); //18
            mesh.enabled = true;
            yield return new WaitForSeconds(meshTimer);
            mesh.enabled = false;
            yield return new WaitForSeconds(meshTimer); //20
            mesh.enabled = true;

            isInvulnerable = false;
            StopCoroutine("startInvulnerable");
            StartCoroutine("slowlyDecreasePlayerSpeed", .35f);
        }
    }
    //void OnCollisionEnter(Collision collision)
    //{
    //    //When player is on the ground, player can jump again
    //    canJump = true;
    //}

}
