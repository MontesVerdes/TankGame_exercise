using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank_health : MonoBehaviour
{
    [Header("TankStats")]
    [SerializeField]
    float tank_max_health;
    public float tank_current_health;

    void Start()
    {
        tank_max_health = 50;
        tank_current_health = tank_max_health;
    }

    void Update()
    {
        
    }

    void Tank_health_ui()
    {

    }

    void Tank_hit()
    {
        
    }
}
