using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("GameOver screen")]
    [SerializeField]
    GameObject gameOver_screen;
    public Canvas gameOver_canvas;

    [Header("Player tank")]
    public GameObject player_tank;
    Tank_health tank_health;
    int current_health;

    [Header("Camera")]
    [SerializeField]
    GameObject main_camera;

    // Start is called before the first frame update
    void Start()
    {
        tank_health = player_tank.GetComponent<Tank_health>();
    }

    // Update is called once per frame
    void Update()
    {
        check_player();
    }

    void check_player()
    {
        current_health = tank_health.tank_current_health;

        if(current_health <= 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        // Enable the GameOver Canvas
        Behaviour bhvr = (Behaviour)gameOver_canvas;
        bhvr.enabled = true;

        // Stop audio    
        main_camera.GetComponent<AudioListener>().enabled = false;
    }   
    
    public void Reset() // Resets Game
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Quit() // Quit Game
    {
        Application.Quit();
    }
}