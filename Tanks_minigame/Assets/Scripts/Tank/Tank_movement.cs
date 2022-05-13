using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank_movement : MonoBehaviour
{
    [Header("Movement variables")]
    public int speed;
    public int turn_speed;
    public bool is_ground;

    [Header("Audio")]
    AudioSource child_audio;
    public GameObject child;
    
    // Components
    Rigidbody rb;
    Ray ray;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        child_audio = child.GetComponent<AudioSource>();
    }

    void Update()
    {
        Player_movement_input();
        Is_grounded();
    }

    void Player_movement_input()
    {
        // Get player input
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        
        // Use player input to move and rotate
        transform.Translate(Vector3.forward * speed * Time.deltaTime * v);
        transform.Rotate(Vector3.up * turn_speed * Time.deltaTime * h);

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

        // Tank jump with player input
        if (Input.GetKeyDown(KeyCode.Space) && is_ground == true)
        {
            rb.AddForce(transform.up * 500);
        }
    }

    bool Is_grounded() // Check if the tank is grounded
    {
        ray.origin = transform.position; // Raycast origin
        ray.direction = -transform.up; // Raycast direction

        if(Physics.Raycast(ray)) {is_ground = false;}
        else {is_ground = true;}

        return is_ground;
    }
}