using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell_explosion : MonoBehaviour
{
    [Header("Particles")]
    [SerializeField]
    ParticleSystem explosion_particles;

    void OnCollisionEnter(Collision other)
    {
        //Unparent the particles from the shell and plays the particles
        explosion_particles.transform.parent = null;
        explosion_particles.Play();

        // Once the particles have finished, destroy the gameobject they are on.
        ParticleSystem.MainModule mainModule = explosion_particles.main;
        Destroy (explosion_particles.gameObject, mainModule.duration);

        GetComponent<AudioSource>().Play();
        StartCoroutine(destroy_after_sound());
    }

    IEnumerator destroy_after_sound()
    {
        GetComponent<MeshRenderer>().enabled = false;
        yield return new WaitForSeconds(1.2f);
        Destroy (gameObject);
    }
}