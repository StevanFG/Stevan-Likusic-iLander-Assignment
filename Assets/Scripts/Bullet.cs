using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bullet : MonoBehaviour
{
    public float speed;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacles"))
        {
            gameObject.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        // Calcuating the bullet vector
        Vector3 test = new Vector3();
        test.x += speed * Time.deltaTime;
        transform.position += test;
    }
}
