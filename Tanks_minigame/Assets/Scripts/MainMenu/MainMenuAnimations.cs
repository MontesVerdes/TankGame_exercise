using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuAnimations : MonoBehaviour
{
    [Header("Animations")]
    [SerializeField]
    Animation animation1;
    [SerializeField]
    Animation animation2;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(play_anim1());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    IEnumerator play_anim1()
    {
        animation1.Play("Main Menu animation1");
        yield return new WaitForSeconds(6f);
        StartCoroutine(play_anim2());
    }

    IEnumerator play_anim2()
    {
        animation2.Play("Main Menu animation2");
        yield return new WaitForSeconds(6f);
        StartCoroutine(play_anim1());
    }
}
