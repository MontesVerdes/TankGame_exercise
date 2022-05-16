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
        if(tank_player == null)
        {
            tank_player = GameObject.FindWithTag("user_tank");
            tank_health = tank_player.GetComponent<Tank_health>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(tank_health != null)
        {
            tank_current_health = tank_health.tank_current_health;
            Debug.Log("bien!" + tank_current_health);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the collider is player
        if(other.gameObject.CompareTag("Player_tank") && tank_current_health < 5)
        {   
            tank_health.health_up();

            StartCoroutine(Destroy());

            Debug.Log("Ha entrado!");
        }
    }

    IEnumerator Destroy() // Destroy the prefab after playing the sound
    {
        GetComponent<AudioSource>().Play();
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
        yield return new WaitForSeconds(5f);
        Create(); 
    }

    public void Create()
    {
        GetComponent<MeshRenderer>().enabled = true;
        GetComponent<BoxCollider>().enabled = true;
    }
}
