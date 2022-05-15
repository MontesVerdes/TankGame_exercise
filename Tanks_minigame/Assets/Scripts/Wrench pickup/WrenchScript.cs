using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrenchScript : MonoBehaviour
{
    [Header("Player tank")]
    GameObject tank_player;
    Tank_health tank_health;
    int tank_current_health;

    // Start is called before the first frame update
    void Start()
    {
        tank_player = GameObject.FindWithTag("Player_tank");
        tank_health = tank_player.GetComponent<Tank_health>();
    }

    // Update is called once per frame
    void Update()
    {
        tank_current_health = tank_health.tank_current_health;
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the collider is player
        if(other.gameObject.CompareTag("Player_tank") && tank_current_health < 5)
        {   
            tank_health.health_up();
            StartCoroutine(Destroy());
        }
    }

    IEnumerator Destroy() // Destroy the prefab after playing the sound
    {
        GetComponent<AudioSource>().Play();
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
        yield return new WaitForSeconds(0.837f);  
        Destroy(this.gameObject);
    }
}
