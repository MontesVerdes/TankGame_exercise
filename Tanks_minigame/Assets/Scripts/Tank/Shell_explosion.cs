using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell_explosion : MonoBehaviour
{
    [Header("Particles")]
    [SerializeField]
    ParticleSystem explosion_particles;

    bool is_explosion_over = true;

    void OnTriggerEnter(Collider other)
    {
        //Unparent the particles from the shell and plays the particles
        explosion_particles.transform.parent = null;
        explosion_particles.Play();

        // Once the particles have finished, destroy the gameobject they are on.
        ParticleSystem.MainModule mainModule = explosion_particles.main;
        Destroy (explosion_particles.gameObject, mainModule.duration);
        if(is_explosion_over == true) {StartCoroutine(destroy_after_sound());}
    }

    // Destroys the particles after the sound explosion is played
    IEnumerator destroy_after_sound()
    {
        is_explosion_over = false;
        GetComponent<AudioSource>().Play();
        GetComponent<MeshRenderer>().enabled = false;
        yield return new WaitForSeconds(1.5f);
        is_explosion_over = true;
        Destroy(gameObject);
    }
}