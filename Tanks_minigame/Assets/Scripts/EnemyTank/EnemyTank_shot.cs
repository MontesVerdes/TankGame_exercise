using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTank_shot : MonoBehaviour
{
    [Header("Shell Cannon variables")]
    [SerializeField]
    Transform Shoot_transform;
    public GameObject Shell_prefab;
    GameObject new_shell;
    bool shot_fired; 

    [Header("Sound")]
    [SerializeField]
    AudioClip shoot_sound;

    [Header("Player")]
    [SerializeField]
    GameObject player_tank;
    public Transform transform_player;
    float distance_from_player;
    bool is_close;

    // Start is called before the first frame update
    void Start()
    {
        Shell_shot();
        shot_fired = false;
    }

    // Update is called once per frame
    void Update()
    {
        Where_is_tank();
        if(shot_fired == false){StartCoroutine(Shell_shot());}
    }

    void Where_is_tank() // Check if this tank is far from players tank or close
    {   
        distance_from_player = Vector3.Distance(transform.position, transform_player.position);

        if(distance_from_player > 15){is_close = false;}

        if(distance_from_player < 15){is_close = true;}
    }

    IEnumerator Shell_shot()
    {
        shot_fired = true;
        yield return new WaitForSeconds(4f);
        shot_fired = false;
        // Instantiate a tank shell with player input
        if(is_close == true)
        {
            new_shell = Instantiate(Shell_prefab, Shoot_transform.position, Shoot_transform.rotation);
            new_shell.transform.parent = this.transform;

            GetComponent<AudioSource>().PlayOneShot (shoot_sound, 1);
        }
    }
}
