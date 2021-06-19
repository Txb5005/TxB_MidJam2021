using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISpawner : MonoBehaviour
{
    public GameObject[] gingerbreadAI;
    public Transform spawnPoint;
    bool gingerbreadSpawned = false;
    Transform playerT;
    Timer timer;
    public float timeBetweenSpawns;
    int numGingerbread;
    int currentNumGingerbread;

    public float Distance
    {
        get
        {
            return Vector3.Distance(playerT.position, transform.position);
        }
    }

    public bool InRange
    {
        get
        {
            if (Distance <= 15)
            {
                Debug.Log("range entered");
                return true;
            }
            return false;
        }
    }

    void Start()
    {
        numGingerbread = Random.Range(0, 2);
        playerT = GameObject.FindObjectOfType<PlayerCharacter>().transform;
        timer = new Timer("", true, timeBetweenSpawns, spawnGingerbread, true);
    }


    void Update()
    {
        if (InRange && gingerbreadSpawned == false)
        {
            if (timer.IsOn)
            {
                timer.Run();
            }
            else
            {
                timer.Start();
            }
        }
    }

    public void spawnGingerbread()
    {
        if (currentNumGingerbread <= numGingerbread)
        {
            Instantiate(gingerbreadAI[Random.Range(0, gingerbreadAI.Length)], spawnPoint);
            currentNumGingerbread++;
            Debug.Log("spawned gingerbread");
        }
        else
        {
            gingerbreadSpawned = true;
        }
    }

}
