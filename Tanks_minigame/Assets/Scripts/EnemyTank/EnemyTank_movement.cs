using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyTank_movement : MonoBehaviour
{
    [Header("Movement variables")]
    public int speed = 3;
    NavMeshAgent agent;
    float distance_from_player;
    Transform transform_player;
    Rigidbody rb;

    [Header("Player tank")]
    GameObject tank_player;

    // Start is called before the first frame update
    void Start()
    {
        tank_player = GameObject.FindWithTag("user_tank");
        agent = GetComponent<NavMeshAgent>();
        transform_player = tank_player.GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(transform_player); // Look at the player
        Where_is_tank(); 
    }

    void Movement() // Runs to player
    {
        if(tank_player == null) return;

        agent.SetDestination(tank_player.transform.position);

        agent.stoppingDistance = 10f;
    }

    void Movement_backwards() // Flee from player
    {
        if(tank_player == null) return;
        
        agent.velocity = -transform.forward * 5;
    }

    void Where_is_tank() // Check if player is close
    {   
        distance_from_player = Vector3.Distance(transform.position, transform_player.position);

        if(distance_from_player > 10){Movement();}

        if(distance_from_player < 8){Movement_backwards();}
    }
}