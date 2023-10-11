using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnTriggerPower : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player1") || collision.CompareTag("Player2"))
        {
            gameObject.SetActive(false);
        }
    }
}
