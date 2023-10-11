using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class FasterBoost : MonoBehaviour
{
    public float boostedSpeed;
    public float standardSpeed;
    private PlayerMovement playerMovement;
    public GameObject player;
    private bool boosting;
    public float boostTimer;
    public float boostAmmount;

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
            boostTimer += Time.deltaTime;
            if (boostTimer > boostAmmount)
            {
                playerMovement.speed = standardSpeed;
                boosting = false;
                boostTimer = 0;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Faster"))
        {
            playerMovement.speed = boostedSpeed;
            boosting = true;
        }
    }
}
