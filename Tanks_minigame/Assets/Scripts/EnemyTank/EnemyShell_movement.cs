using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShell_movement : MonoBehaviour
{
    float shell_speed;
    // Start is called before the first frame update
    void Start()
    {
        Shell_velocity();
        transform.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(shell_speed * Vector3.forward * Time.deltaTime);
    }

    void Shell_velocity()
    {
        shell_speed = Random.Range(8f,13f);
    }
}
