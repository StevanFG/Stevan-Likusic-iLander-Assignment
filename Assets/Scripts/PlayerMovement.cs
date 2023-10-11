using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    private float horizontal;
    private float vertical;
    Vector2 lastVelocity;
    public float speedUp;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(new Vector2(horizontal * speed, vertical * speed) * Time.deltaTime * speedUp);
        //rb.velocity = new Vector2(horizontal * speed, vertical * speed); - Overriding velocity isn't good
    }

    private void FixedUpdate()
    {
        lastVelocity = rb.velocity;
    }

    public void Move(InputAction.CallbackContext callbackContext)
    {
        horizontal = callbackContext.ReadValue<Vector2>().x;
        vertical = callbackContext.ReadValue<Vector2>().y;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player1") || collision.gameObject.CompareTag("Player2"))
        {
            var speed = lastVelocity.magnitude;
            var direction = Vector2.Reflect(lastVelocity.normalized, collision.contacts[0].normal);
            rb.velocity = direction * Mathf.Max(speed, 2f);
        }
    }
}
