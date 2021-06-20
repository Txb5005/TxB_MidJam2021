using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI_GingerBread : MonoBehaviour
{
    public float speedDecreaseRate; //This should be between the range of (.1 -> .3)
    public float minSpeed = 3.5f;

    GameObject target; // This is an empty gameobject placed at the end of the game/level

    NavMeshAgent gingerbreadAI;
    public Animator anim;

    void Start()
    {
        //anim = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Target");
        gingerbreadAI = GetComponent<NavMeshAgent>(); // Reference to the NavmeshAgent on this object
        StartCoroutine("slowlyDecreaseSpeed", .25f); // Run the decrease speed function every .25 seconds
        gingerbreadAI.speed = Random.Range(6, 9);
        anim.SetBool("IsRun", true);
    }

    // Update is called once per frame
    void Update()
    {
        moveToTarget();
        anim.SetBool("IsRun", true);
        // This keeps the speed of the agent from dropping below "minSpeed"
        if (gingerbreadAI.speed < minSpeed)
        {
            gingerbreadAI.speed = minSpeed;
        }
    }

    public void moveToTarget() // Move agent to location plugged through inspector
    {
        gingerbreadAI.SetDestination(target.transform.position);
    }

    public void jump()
    {

    }

    public void die()
    {
        Destroy(gameObject);
    }

    IEnumerator slowlyDecreaseSpeed(float waitTime) // This function subtracts from the speed of the agent based on the specified wait time
    {
        while (gingerbreadAI.speed > minSpeed)
        {
            yield return new WaitForSeconds(waitTime);
            gingerbreadAI.speed = gingerbreadAI.speed - speedDecreaseRate;
        }
    }
}
