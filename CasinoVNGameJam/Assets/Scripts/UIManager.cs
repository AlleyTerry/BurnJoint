using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    public static UIManager instance;
    private void Awake()
    {
        // Ensure only one instance of UIManager exists
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Keep this object across scene loads
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate instances
        }
        
        //find the pause menu in the scene
        pauseMenu = GameObject.Find("PauseMenu");
        // Ensure the pause menu is inactive at the start
        if (pauseMenu != null)
        {
            pauseMenu.SetActive(false);
        }
    }

    public void Update()
    {
        // Check for the escape key to toggle the pause menu
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePauseMenu();
        }
    }

    public void TogglePauseMenu()
    {
        /*if (pauseMenu == null)
        {
            pauseMenu = GameObject.Find("pauseMenu");
        }*/
        //toggle the pause menu
        if (pauseMenu.activeSelf)
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1f; // Resume the game
        }
        else
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f; // Pause the game
        }
    }
    public void ShowPauseMenu()
    {
        pauseMenu.SetActive(true);
    }
}
