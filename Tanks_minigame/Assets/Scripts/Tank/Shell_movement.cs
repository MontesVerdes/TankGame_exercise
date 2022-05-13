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
        Tank_shot = transform.parent.GetComponent<Tank_shot>();
        shell_speed = Tank_shot.shell_speed;

        // Screen shake when shooting
        source = GetComponent<Cinemachine.CinemachineImpulseSource>();
        source.GenerateImpulse(Camera.main.transform.forward);
    }

    // Moves the shell
    void Update()
    {
        transform.Translate(shell_speed * Vector3.forward * Time.deltaTime);   
    }
}