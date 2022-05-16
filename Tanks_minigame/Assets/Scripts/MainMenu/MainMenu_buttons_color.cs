using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainMenu_buttons_color : MonoBehaviour
{
    public TextMeshProUGUI textmeshPro;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void turnGreen()
    {
        textmeshPro.outlineColor = new Color32(51, 157, 0, 255);
        Debug.Log(textmeshPro.outlineColor);
    }

    public void turnWhite()
    {
        
    }
}