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
    bool reloading = false;

    [Header("UI")]
    [SerializeField]
    Slider Shell_slider;
    [SerializeField]
    Animation shell_animation;

    [Header("Sound")]
    [SerializeField]
    AudioClip shoot_sound, reload_sound;

    [Header("Pause")]
    [SerializeField]
    PauseMenu PauseMenu;
    bool game_is_paused;

    void Update()
    {
        Shell_velocity();
        Shell_shot();
    }

    void Shell_shot()
    {
        game_is_paused = PauseMenu.game_is_paused;

        // Instantiate a tank shell with player input
        if(Input.GetMouseButtonUp(0) && !reloading && !game_is_paused)
        {
            new_shell = Instantiate(Shell_prefab, Shoot_transform.position, Shoot_transform.rotation);
            new_shell.transform.parent = this.transform;

            Shell_slider.value = 0; // Slider UI
            StartCoroutine(reset_shell_speed());
            StartCoroutine (cannon_reload());

            GetComponent<AudioSource>().PlayOneShot (shoot_sound, 1);
        }
    }

    IEnumerator cannon_reload()
    {
        reloading = true;
        yield return new WaitForSeconds(1f);
        shell_animation.Play("Shell_animation");
        GetComponent<AudioSource>().PlayOneShot (reload_sound, 1);
        yield return new WaitForSeconds(1f);
        reloading = false;
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
        if(Input.GetMouseButton(0) && (shell_speed < shell_max_speed) && !reloading && !game_is_paused)
        {
            shell_speed = shell_speed + 0.1f;
            Shell_slider.value = Shell_slider.value + 0.1f; // Slider UI
        }
    }
}