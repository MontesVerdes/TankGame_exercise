using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tank_shot : MonoBehaviour
{   
    [Header("Shell Cannon variables")]
    [SerializeField]
    Transform Shoot_transform;
    public GameObject Shell_prefab;
    public float shell_speed;
    float shell_max_speed = 15;
    GameObject new_shell;

    [Header("UI")]
    [SerializeField]
    Slider Shell_slider;

    [Header("Sound")]
    [SerializeField]
    AudioClip shoot_sound;

    void Update()
    {
        Shell_velocity();
        Shell_shot();
    }

    void Shell_shot()
    {
        // Instantiate a tank shell with player input
        if(Input.GetMouseButtonUp(0))
        {
            new_shell = Instantiate(Shell_prefab, Shoot_transform.position, Shoot_transform.rotation);
            new_shell.transform.parent = this.transform;

            Shell_slider.value = 0; // Slider UI
            StartCoroutine(reset_shell_speed());

            GetComponent<AudioSource>().PlayOneShot (shoot_sound, 1);
        }
    }

    // Resets the shell_speed after the shell instance got it, and detach from tank
    IEnumerator reset_shell_speed()
    {
        yield return new WaitForSeconds(0.1f);
        shell_speed = 5f;
        new_shell.transform.parent = null;
    }

    // Sets shell velocity from user input
    void Shell_velocity()
    {
        if(Input.GetMouseButton(0) && (shell_speed < shell_max_speed))
        {
            shell_speed = shell_speed + 0.2f;
            Shell_slider.value = Shell_slider.value + 0.2f; // Slider UI
        }
    }
}