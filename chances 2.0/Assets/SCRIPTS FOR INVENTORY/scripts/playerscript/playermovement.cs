using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of the player
    private Rigidbody2D rb;      // Reference to the Rigidbody2D component
    private Vector2 movement;    // To store movement input

    void Start()
    {
        // Get the Rigidbody2D component attached to the player
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Get input for horizontal and vertical movement (WASD or arrow keys)
        movement.x = Input.GetAxisRaw("Horizontal"); // Left (-1) or right (1)
        movement.y = Input.GetAxisRaw("Vertical");   // Down (-1) or up (1)
    }

    void FixedUpdate()
    {
        // Move the player using Rigidbody2D (for physics-based movement)
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
