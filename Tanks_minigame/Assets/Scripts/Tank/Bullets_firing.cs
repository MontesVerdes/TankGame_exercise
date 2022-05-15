using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets_firing : MonoBehaviour
{
    [Header("Gun bullets variables")]
    [SerializeField]
    Transform gun_transform;
    public GameObject bullets_prefab;
    GameObject new_bullets;

    bool delay = false;

    [Header("Sound")]
    [SerializeField]
    AudioClip burst_sound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        shot_bullets();
    }

    void shot_bullets()
    {
        if(Input.GetKeyDown("space") && delay == false)
        {
            StartCoroutine(shot_delay());
        }
    }

    IEnumerator shot_delay()
    {
        delay = true;

        new_bullets = Instantiate(bullets_prefab, gun_transform.position, gun_transform.rotation);

        GetComponent<AudioSource>().PlayOneShot (burst_sound, 1);

        yield return new WaitForSeconds(0.6f);

        delay = false;
    }
}
