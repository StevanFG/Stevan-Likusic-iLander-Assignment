using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string sceneName;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ChangeScene();
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
