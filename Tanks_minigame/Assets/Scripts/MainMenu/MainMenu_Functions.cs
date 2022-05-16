using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu_Functions : MonoBehaviour
{
    [Header("Controls Canvas")]
    [SerializeField]
    Canvas Controls_Canvas;
    
    public void play()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void controls()
    {
        Controls_Canvas.enabled = true;
    }

    public void hide_controls()
    {
        Controls_Canvas.enabled = false;
    }

    public void quit()
    {
        Application.Quit();
    }
}
