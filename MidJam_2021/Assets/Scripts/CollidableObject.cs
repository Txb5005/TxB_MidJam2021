using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollidableObject : MonoBehaviour
{
    PlayerCharacter player;
    float speedIncreaseRate;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindObjectOfType<PlayerCharacter>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerCharacter>() && player.isInvulnerable == false)
        {
            Debug.Log("trigger entered");
            player.ToggleInvulnerable();
            player.currentSpeed -= 3;
            player.StartCoroutine("slowlyIncreasePlayerSpeed", .25f);
        }
    }
}
