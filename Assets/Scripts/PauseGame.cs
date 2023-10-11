using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public GameObject pauseMenuUI;

    private static bool gameIsPaused = false;

    private void Start()
    {
        pauseMenuUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Escape"); 
            if (gameIsPaused)
            {
                Debug.Log("if Resume");
                Resume();   
            }
            else
            {
                Debug.Log("if Pause");
                Pause();
            }
        }
    }

    public void Resume()
    {
        Debug.Log("Resume");
        gameIsPaused = false;
        Time.timeScale = 1f; // Unpause the game by setting time scale to 1 = sets the pace normally.
        pauseMenuUI.SetActive(false);
    }

    void Pause()
    {
        Debug.Log("Pause");
        gameIsPaused = true;
        Time.timeScale = 0f; // Pause the game by setting time scale to 0 = freezes it.
        pauseMenuUI.SetActive(true);
    }
}