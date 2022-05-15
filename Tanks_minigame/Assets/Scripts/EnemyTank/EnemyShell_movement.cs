using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShell_movement : MonoBehaviour
{
    float shell_speed;
    // Start is called before the first frame update
    void Start()
    {
        transform.parent = null;

        shell_speed = Random.Range(5f,10f);
        GetComponent<Rigidbody>().AddForce(transform.forward * (shell_speed * 300));
    }

    void Update()
    {
        // Shell orientation follows direction
        transform.forward = GetComponent<Rigidbody>().velocity;
    }
}