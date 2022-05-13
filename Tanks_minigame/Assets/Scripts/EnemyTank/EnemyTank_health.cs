using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyTank_health : MonoBehaviour
{
    // Tank Stats    
    int tank_max_health;
    public int enemy_tank_current_health;

    [Header("UI")]
    [SerializeField]
    GameObject enemy_health_bar;
    public Image[] enemy_health_array;

    [Header("Sound")]
    [SerializeField]
    AudioClip explosion;

    // Start is called before the first frame update
    void Start()
    {
        tank_max_health = 2;
        enemy_tank_current_health = tank_max_health;
    }

    // Update is called once per frame
    void Update()
    {
        Tank_destroy();
    }

    void Tank_health_ui() // Update the UI life bar
    {
        Behaviour bhvr = (Behaviour)enemy_health_array[enemy_tank_current_health];
        bhvr.enabled = false;
    }

    void Tank_hit() // Remove a life point and calls the ui
    {
        enemy_tank_current_health = enemy_tank_current_health - 1;
        Tank_health_ui();

        if(enemy_tank_current_health <= 0)
        {
            StartCoroutine(Tank_destroy());
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the collider is the enemy shell
        if(other.gameObject.CompareTag("Player_shell") && enemy_tank_current_health > 0)
        {
            Tank_hit();
        }
    }

    IEnumerator Tank_destroy() // Destroy enemy tank
    {
        GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().PlayOneShot(explosion, 1f);
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }

}
