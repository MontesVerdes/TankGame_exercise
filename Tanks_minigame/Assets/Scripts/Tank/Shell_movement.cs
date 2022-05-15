using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell_movement : MonoBehaviour
{   
    Tank_shot Tank_shot;
    float shell_speed;
    
    // For screen shake
    Cinemachine.CinemachineImpulseSource source;

    // Gets shell velocity from parent at the start
    void Start()
    {
        // Adds velocity to the shell
        Tank_shot = transform.parent.GetComponent<Tank_shot>();
        shell_speed = Tank_shot.shell_speed;
        GetComponent<Rigidbody>().AddForce(transform.forward * (shell_speed * 300));

        // Screen shake when shooting
        source = GetComponent<Cinemachine.CinemachineImpulseSource>();
        source.GenerateImpulse(Camera.main.transform.forward);
    }

    void Update()
    {
        // Shell orientation follows direction
        transform.forward = GetComponent<Rigidbody>().velocity;
    }
}