using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTank_movement : MonoBehaviour
{
    [Header("Movement variables")]
    public int speed;
    bool is_ground;

    public bool is_far;
    public bool is_close;

    [Header("Player tank")]
    GameObject tank_player;
    Transform transform_player;
    float distance_from_player;

    // Components
    Rigidbody rb;
    Ray ray;

    // Start is called before the first frame update
    void Start()
    {
        tank_player = GameObject.FindWithTag("Player_tank");

        transform_player = tank_player.GetComponent<Transform>();

        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(transform_player); // Look at the player
        Where_is_tank(); 
    }

    void Enemy_movement_forward() // Move enemy tank forward
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime * 1);
    }

    void Enemy_movement_backwards() // Move enemy tank backwards
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime * -1);
    }

    void Where_is_tank() // Check if this tank is far from players tank or close
    {   
        distance_from_player = Vector3.Distance(transform.position, transform_player.position);

        if(distance_from_player > 10){Enemy_movement_forward();}

        if(distance_from_player < 8){Enemy_movement_backwards();}
    }
}