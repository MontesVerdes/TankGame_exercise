using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_manager_script : MonoBehaviour
{
    [Header("EnemyList")]
    public List<GameObject> enemy_list;
    GameObject target;

    [Header("EnemyPrefab")]
    [SerializeField]
    GameObject tank_prefab;

    [Header("EnemyLocations")]
    [SerializeField]
    GameObject[] Spawners_array;
    bool spawn_finish = true;
    
    void Update()
    {
        if(spawn_finish == true){StartCoroutine(Instantiate_enemy_tanks());}
    }

    IEnumerator Instantiate_enemy_tanks() // Instantiate new enemies and add them to list
    {
        spawn_finish = false;

        int rand = Random.Range(0,3);
        
        Transform new_position = Spawners_array[rand].transform;
        Vector3 temp_position = new Vector3(0f,0f,0f);

        // Adds more range to the posible enemy spawn positions
        if(rand == 0 || rand == 1)
        {
            float random_x = Random.Range(-30f, 25f);
            Vector3 random_x_vector = new Vector3(random_x,0f,0f);
            temp_position = new_position.position + random_x_vector;
        }

        if(rand == 2 || rand == 3)
        {
            float random_z = Random.Range(-25f, 35f);
            Vector3 random_z_vector = new Vector3(0f,0f,random_z);
            temp_position = new_position.position + random_z_vector;
        }

        target = Instantiate(tank_prefab, temp_position, new_position.rotation);

        Add_to_enemy_list(target);

        yield return new WaitForSeconds(7f);
        
        spawn_finish = true;
    }

    void Add_to_enemy_list(GameObject target)
    {
        enemy_list.Add(target);
    }
}