using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    public static SceneManager instance;
    [SerializeField] private GameObject pauseMenu;
    private void Awake()
    {
        // Ensure only one instance of SceneManager exists
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Keep this object across scene loads
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate instances
        }
        
    }
    //change scene to game scene
    public void ChangeToGameScene()
    {
        //load the game scene
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }

    
}
