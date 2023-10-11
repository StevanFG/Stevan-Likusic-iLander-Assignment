using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class SlowerBoost : MonoBehaviour
{
    public float slowedSpeed;
    public float standardSpeed;
    private PlayerMovement playerMovement;
    public GameObject player;
    private bool boosting;
    public float slowedTimer;
    public float slowedAmmount;

    private void Awake()
    {
        playerMovement = player.GetComponent<PlayerMovement>();
    }

    // Start is called before the first frame update
    void Start()
    {
        boosting = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (boosting)
        {
            // Adding the duration of the boost
            slowedTimer += Time.deltaTime;
            if (slowedTimer > slowedAmmount)
            {
                playerMovement.speed = standardSpeed;
                boosting = false;
                slowedTimer = 0;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Slower"))
        {
            playerMovement.speed = slowedSpeed;
            boosting = true;
        }
    }
}
