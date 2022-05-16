using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [Header("Pause")]
    public bool game_is_paused = false;

    [Header("Canvas")]
    [SerializeField]
    Canvas pause_canvas;

    [Header("Audio")]
    [SerializeField]
    AudioListener AudioListener;

    // Start is called before the first frame update
    void Start()
    {
        AudioListener.volume = 1;
    }

    // Update is called once per frame
    void Update()
    {
        Pause();
    }

    void Pause()
    {
        if(Input.GetKeyDown("escape"))
        {
            Time.timeScale = 0f;
            game_is_paused = true;
            pause_canvas.enabled = true;
            AudioListener.volume = 0;
        }
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        game_is_paused = false;
        pause_canvas.enabled = false;
        AudioListener.volume = 1;
    }
}
