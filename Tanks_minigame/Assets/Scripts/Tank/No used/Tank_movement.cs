using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank_movement : MonoBehaviour
{
    [Header("Movement variables")]
    public int speed;
    public int turn_speed;
    bool camera_lock;

    [Header("Audio")]
    AudioSource child_audio;
    public GameObject child;
    
    // Components
    Rigidbody rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        child_audio = child.GetComponent<AudioSource>();
    }

    void Update()
    {
        Player_movement_input();
        camera_lock = GetComponent<Aim_atEnemy>().camera_lock;
    }

    void Player_movement_input()
    {
        // Get player input
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        
        // Use player input to move and rotate
        transform.Translate(Vector3.forward * speed * Time.deltaTime * v);
        
        if(camera_lock == false) // Check if camera is locked in enemy
        {   
            transform.Rotate(Vector3.up * turn_speed * Time.deltaTime * h);
        }

        // If moving stop idle audio, plays running audio
        if(h != 0 || v != 0)
        {
            GetComponent<AudioSource>().Pause();
            if (!child_audio.isPlaying)
            {
                child_audio.Play();
            }
        }
        else
        {
            GetComponent<AudioSource>().UnPause();
            child_audio.Stop();
        }
    }
}