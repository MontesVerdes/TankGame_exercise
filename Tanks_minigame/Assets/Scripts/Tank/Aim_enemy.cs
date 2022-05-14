using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Aim_enemy : MonoBehaviour
{
    [Header("Enemy tank")]
    [SerializeField]
    GameObject enemy_tank;
    EnemyTank_health enemy_health;
    int enemy_hp;
    Transform enemy_transform;

    [Header("Enemy UI canvas")]
    [SerializeField]
    Canvas enemy_UI_canvas;

    [Header("LockOn UI")]
    [SerializeField]
    Canvas LockOn_canvas;
    public bool camera_lock;

    [Header("LockOn movement")]
    [SerializeField]
    float speed = 1f;
    Coroutine Look;

    void Start()
    {
        enemy_transform = enemy_tank.GetComponent<Transform>();

        enemy_health = enemy_tank.GetComponent<EnemyTank_health>();
    }

    void Update()
    {
        look_at_enemy();

        enemy_hp = enemy_health.enemy_tank_current_health;
    }

    void look_at_enemy()
    {
        if(Input.GetMouseButtonDown(1) && enemy_hp > 0)
        {
            // Enable/disable the enemy UI Canvas 
            Behaviour bhvr = (Behaviour)enemy_UI_canvas;
            bhvr.enabled = bhvr.enabled ? false : true;

            // Enable/disable the lock on UI
            Behaviour bhvr_lock = (Behaviour)LockOn_canvas;
            bhvr_lock.enabled = bhvr_lock.enabled ? false : true;

            // Lock-unlock camera
            camera_lock = camera_lock ? false : true;

            // Starts coroutine only once at a time
            if (Look != null){StopCoroutine(Look);}

            // Starts coroutine only when locking the camera, not when unlocking
            if (camera_lock == true){Look = StartCoroutine(LookCoroutine());}
        }

        if(enemy_hp == 0) // Deactivate canvas and lockon
        {
            Behaviour bhvr = (Behaviour)enemy_UI_canvas;
            bhvr.enabled = false;
            
            camera_lock = false;
        }
    }

    IEnumerator LookCoroutine() // Smooth out the look at target
    {
        // This code was from youtube video "https://www.youtube.com/watch?v=2XEiHf1N_EY"
        Quaternion look_rotation = Quaternion.LookRotation(enemy_transform.position - transform.position);

        float time = 0;

        while (time < 1)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, look_rotation, time);
            
            time += Time.deltaTime * speed;

            yield return null;
        }
    }
}