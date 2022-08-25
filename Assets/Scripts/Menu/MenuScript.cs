using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    public Canvas menuCanvas;
    public bool menuOpen;
    
    void Start()
    {
        menuOpen = false;
        CloseMenu();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleMenu();
        }
    }

    void ToggleMenu()
    {
        if (IsMenuOpen())
        {
            CloseMenu();
        }
        else
        {
            OpenMenu();
        }
        menuOpen = !menuOpen;
    }

    bool IsMenuOpen()
    {
        return menuOpen;
    }

    void CloseMenu()
    {
        menuCanvas.gameObject.SetActive(false);
    }

    void OpenMenu()
    {
        menuCanvas.gameObject.SetActive(true);
    }
}
