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
    [SerializeField]
    Animation tank_animation;

    [Header("Sound")]
    [SerializeField]
    AudioClip explosion, bullets_hit;

    [Header("Enemylist")]
    [SerializeField]
    GameObject Enemy_manager;
    Enemy_manager_script Enemy_manager_script;
    List<GameObject> enemy_list;

    [Header("Bullets")]
    int bullet_count = 0;

    [Header("GameManager")]
    [SerializeField]
    GameManager GameManager;

    // Start is called before the first frame update
    void Start()
    {
        tank_max_health = 2;
        enemy_tank_current_health = tank_max_health;

        Enemy_manager = GameObject.FindWithTag("Enemy_manager");

        Enemy_manager_script = Enemy_manager.GetComponent<Enemy_manager_script>();

        enemy_list = Enemy_manager_script.enemy_list;

        GameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
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
            enemy_list.Remove(this.gameObject);
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

        // Check if the collider is the bullets
        if(other.gameObject.CompareTag("Bullets") && enemy_tank_current_health > 0)
        {
            ++bullet_count;
            GetComponent<AudioSource>().PlayOneShot (bullets_hit, 1);
            if(bullet_count >= 3)
            {
                Tank_hit();
                bullet_count = 0;
            }
        }
    }

    IEnumerator Tank_destroy() // Destroy enemy tank
    {
        GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().PlayOneShot(explosion, 1f);
        tank_animation.Play("tank_ui");
        GameManager.enemy_kill_count();
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}