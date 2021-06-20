using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinTrigger : MonoBehaviour
{
    [Header("Assigned")]
    public PlayerCharacter player;
    public AudioSource audioSource;


    public void Start()
    {
        player = FindObjectOfType<PlayerCharacter>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<PlayerCharacter>())
        {
            Scene_Manager.Instance.LoadScene("Win");
            audioSource.Play();
            Time.timeScale = 0;
        }
    }


}
