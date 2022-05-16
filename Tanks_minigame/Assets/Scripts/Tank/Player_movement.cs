using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_movement : MonoBehaviour
{
    // Movement variables
    [Header("Movement")]
    [SerializeField] int speed;
    [SerializeField] int rot_speed;
    Vector3 movement_vertical;
    Vector3 movement_horizontal;
    Rigidbody rb;
    bool camera_lock;

    // Input variables
    float horizontal;
    float vertical;

    [Header("Audio")]
    [SerializeField] AudioSource child_audio;
    
    void Start()
    {
        GetComponents();
    }

    void Update()
    {
        Movement_input();
        Is_camera_lock();
        Engine_audio();
    }

    void FixedUpdate()
    {
        Move();
    }

    void GetComponents()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    void Is_camera_lock()
    {
        camera_lock = GetComponent<Aim_atEnemy>().camera_lock;
    }

    void Movement_input()
    {
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");
    }

    void Move()
    {
        // Forward & backward movement
        movement_vertical.Set(0, 0, vertical);
        movement_vertical.Normalize();

        if(movement_vertical.z == 1f)
        {
            rb.MovePosition(transform.position + (transform.forward * speed * Time.deltaTime));
        }

        if(movement_vertical.z == -1f)
        {
            rb.MovePosition(transform.position + (-transform.forward * speed * Time.deltaTime));
        }

        // Rotation movement
        movement_horizontal.Set(0, horizontal * rot_speed, 0);

        Quaternion rot = Quaternion.Euler(movement_horizontal * Time.deltaTime);
        if(!camera_lock){rb.MoveRotation(rb.rotation * rot);}
    }

    void Engine_audio()
    {
        // If moving stop idle audio, plays running audio
        if(horizontal != 0 || vertical != 0)
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