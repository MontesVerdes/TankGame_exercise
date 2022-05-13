using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tank_health : MonoBehaviour
{
    [Header("TankStats")]
    [SerializeField]
    int tank_max_health;
    public int tank_current_health;

    [Header("UI")]
    [SerializeField]
    GameObject health_bar;
    public Image[] health_array;

    // For screen shake
    Cinemachine.CinemachineImpulseSource source;

    void Start()
    {
        tank_max_health = 5;
        tank_current_health = tank_max_health;
    }

    void Tank_health_ui() // Update the UI life bar
    {
        Behaviour bhvr = (Behaviour)health_array[tank_current_health];
        bhvr.enabled = false;
    }

    void Tank_hit() // Remove a life point and calls the ui
    {
        tank_current_health = tank_current_health - 1;
        Tank_health_ui();
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the collider is the enemy shell
        if(other.gameObject.CompareTag("Enemy_shell") && tank_current_health > 0)
        {
            Tank_hit();
            // Screen shake when being hit by enemy
            source = GetComponent<Cinemachine.CinemachineImpulseSource>();
            source.GenerateImpulse(Camera.main.transform.forward);
        }
    }
}
