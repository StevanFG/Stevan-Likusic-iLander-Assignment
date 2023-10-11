using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameRestarter : MonoBehaviour
{
    public GameObject Player1;
    public GameObject Player2;
    public string Respawn;

    private bool player1Dead = false;
    private bool player2Dead = false;

    void Update()
    {
        CheckPlayerStates();
    }

    void CheckPlayerStates()
    {
        if (Player1 == null || !Player1.activeSelf)
        {
            player1Dead = true;
        }
        if (Player2 == null || !Player2.activeSelf)
        {
            player2Dead = true;
        }

        // Check if both players are dead and restart the scene
        if (player1Dead && player2Dead)
        {
            Debug.Log("Both players have died. Restarting scene.");
            SceneManager.LoadScene(Respawn);
        }
    }
}
