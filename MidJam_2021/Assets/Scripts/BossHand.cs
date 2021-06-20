using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHand : MonoBehaviour
{
    public float currentSpeed;
    Rigidbody rb;
    Camera cam;
    PlayerCharacter player;
    List<AudioSource> gingerbreadMenAudioSources = new List<AudioSource>();
    [SerializeField] List<AudioClip> gingerbreadMenAudioClips = new List<AudioClip>();
    List<AudioSource> munchingAudioSources = new List<AudioSource>();
    [SerializeField] List<AudioClip> munchingAudioClips = new List<AudioClip>();
    ParticleSystem cookieParticleSystem;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cam = FindObjectOfType<Camera>();
        player = FindObjectOfType<PlayerCharacter>();
        Transform t = GameObject.Find("Gingerbread Men Audio").transform;
        for (int i = 0; i < t.childCount; i++)
        {
            AudioSource ass = t.GetChild(i).GetComponent<AudioSource>();
            if (ass)
            {
                gingerbreadMenAudioSources.Add(ass);
            }
        }
        t = GameObject.Find("Munching Audio").transform;
        for (int i = 0; i < t.childCount; i++)
        {
            AudioSource ass = t.GetChild(i).GetComponent<AudioSource>();
            if (ass)
            {
                munchingAudioSources.Add(ass);
            }
        }
        cookieParticleSystem = GameObject.Find("Cookie Particle Effect").GetComponent<ParticleSystem>();
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
            other.gameObject.GetComponent<AI_GingerBread>().die(); // Kill Gingerbread
            // Possible Animation (Hand grabbing gingerbread)
            Munch();
            GingerbreadManScream();
            cookieParticleSystem.Play();
            StartCoroutine(cam.Shake(.3f, .15f)); // Camera Shake function
            currentSpeed += .1f;  // Potential increase of boss speed and player max speed
            player.maxSpeed += .1f;
        }

        if (other.gameObject.GetComponent<PlayerCharacter>())
        {
            // Death animation
            // Stop game play

            if (true) // after death animation is fully complete
            {
                Scene_Manager.Instance.LoadScene("Lose");
            }
        }
    }

    void GingerbreadManScream()
    {
        int rand = Random.Range(0, gingerbreadMenAudioClips.Count);
        foreach (var item in gingerbreadMenAudioSources)
        {
            if (!item.isPlaying)
            {
                item.clip = gingerbreadMenAudioClips[rand];
                item.Play();
                return;
            }
        }
    }
    void Munch()
    {
        int rand = Random.Range(0, munchingAudioClips.Count);
        foreach (var item in munchingAudioSources)
        {
            if (!item.isPlaying)
            {
                item.clip = munchingAudioClips[rand];
                item.Play();
                return;
            }
        }
    }
}
