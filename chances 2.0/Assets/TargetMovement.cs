using UnityEngine;

public class TargetMovement : MonoBehaviour
{
    public float moveSpeed = 3f;         // Normal movement speed
    public float dashSpeed = 5f;         // Speed during dash
    public float dashDuration = 0.2f;    // Duration of the dash
    public float dashCooldown = 1f;      // Time before dash can be used again

    private Rigidbody2D rb;
    private float currentSpeed;          // The current speed (normal or dash)
    private bool isDashing = false;      // To track if player is dashing
    private float dashTime;              // Tracks dash time
    private float dashCooldownTime;      // Tracks dash cooldown

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentSpeed = moveSpeed;        // Start with normal speed
    }

    void Update()
    {
        HandleMovement();
        HandleDash();
    }

    void HandleMovement()
    {
        // Get input from WASD or Arrow keys
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        // Apply movement based on the current speed (normal or dash)
        rb.velocity = new Vector2(moveX, moveY) * currentSpeed;
    }

    void HandleDash()
    {
        // Check if Shift is pressed and dash is not cooling down
        if (Input.GetKeyDown(KeyCode.LeftShift) && !isDashing && Time.time >= dashCooldownTime)
        {
            isDashing = true;
            currentSpeed = dashSpeed;   // Temporarily increase speed
            dashTime = Time.time + dashDuration;  // Set dash time limit
        }

        // If dashing and dash duration is over
        if (isDashing && Time.time >= dashTime)
        {
            isDashing = false;
            currentSpeed = moveSpeed;   // Reset to normal speed
            dashCooldownTime = Time.time + dashCooldown;  // Start cooldown
        }
    }
}
