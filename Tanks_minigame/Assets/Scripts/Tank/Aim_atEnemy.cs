using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim_atEnemy : MonoBehaviour
{
    [Header("Enemylist")]
    [SerializeField]
    Enemy_manager_script Enemy_manager_script;
    List<GameObject> enemy_list;
    GameObject closest_enemy;

    [Header("LookCoroutine")]
    public bool camera_lock;
    Coroutine Look;

    void Update()
    {
        // Get player input
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        
        if(h == 0 && v == 0) // Only aim when not moving
        {
            look_at_enemy();
        }

        enemy_list = Enemy_manager_script.enemy_list;
    }

    void look_at_enemy()
    {
        if(Input.GetMouseButtonDown(1) && enemy_list.Count != 0)
        {
            float closest_distance = Mathf.Infinity;

            if(camera_lock == false) // To search only when unlocked
            {
                // Iterates in the list of current enemies to check who is the closest
                foreach (GameObject enemies in enemy_list)
                {
                    float temp_distance = Vector3.Distance(transform.position, enemies.transform.position);

                    if(temp_distance < closest_distance)
                    {
                        closest_distance = temp_distance;
                        closest_enemy = enemies;
                    }                
                }
            }
            
            // Get the health canvas component in the child of the closest enemy
            GameObject enemy_health_child = closest_enemy.transform.GetChild(2).gameObject;
            Canvas enemy_health_canvas = enemy_health_child.GetComponent<Canvas>();

            // Enable/disable the enemy health UI Canvas 
            Behaviour bhvr = (Behaviour)enemy_health_canvas;
            bhvr.enabled = bhvr.enabled ? false : true;

            // Get the lock on canvas component in the child of the closest enemy
            GameObject enemy_lockon_child = closest_enemy.transform.GetChild(1).gameObject;
            Canvas enemy_lockon_canvas = enemy_lockon_child.GetComponent<Canvas>();

            // Enable/disable the enemy LockOn UI Canvas 
            Behaviour bhvr2 = (Behaviour)enemy_lockon_canvas;
            bhvr2.enabled = bhvr2.enabled ? false : true; 
            
            // Lock - Unlock the camera
            camera_lock = camera_lock ? false : true;

            // Starts coroutine only once at a time
            if (Look != null){StopCoroutine(Look);}

            // Starts coroutine only when locking the camera, not when unlocking
            if (camera_lock == true){Look = StartCoroutine(LookCoroutine());}
        }

        if(closest_enemy == null){camera_lock = false;}
    }

    IEnumerator LookCoroutine() // Smooth out the look at target
    {   
        // This code was from youtube video "https://www.youtube.com/watch?v=2XEiHf1N_EY"
        float speed = 1f;

        Quaternion look_rotation = Quaternion.LookRotation(closest_enemy.transform.position - transform.position);

        float time = 0;

        while (time < 1)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, look_rotation, time);
            
            time += Time.deltaTime * speed;

            yield return null;
        }
    }
}