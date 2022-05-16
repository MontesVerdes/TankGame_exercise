using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("GameOver screen")]
    [SerializeField]
    GameObject gameOver_screen;
    public Canvas gameOver_canvas;
    public TextMeshProUGUI tanks_defeated_text;
    public TextMeshProUGUI tanks_defeated_text2;

    [Header("Player tank")]
    public GameObject player_tank;
    Tank_health tank_health;
    int current_health;

    [Header("Camera")]
    [SerializeField]
    GameObject main_camera;

    [Header("Enemy_count")]
    public int enemy_count;
    public TextMeshProUGUI tanks_destroyed_ui, tanks_destroyed_ui2;

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

    void  GameOver()
    {
        // Enable the GameOver Canvas
        Behaviour bhvr = (Behaviour)gameOver_canvas;
        bhvr.enabled = true;
        
        StopAudio();

        tanks_defeated_text.text = ("You've defeated " + enemy_count.ToString() + " tanks");
        tanks_defeated_text2.text = ("You've defeated " + enemy_count.ToString() + " tanks");
    }

    void StopAudio()
    {
        // Stop audio
        AudioListener.volume = 0;
        
    }
    
    public void Reset() // Resets Game
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu() // Goes to main menu
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Quit() // Quit Game
    {
        Application.Quit();

    }

    public void enemy_kill_count()
    {
        ++enemy_count;
        tanks_destroyed_ui.text = ("Tanks destroyed " + enemy_count.ToString());
        tanks_destroyed_ui2.text = ("Tanks destroyed " + enemy_count.ToString());
    }
}