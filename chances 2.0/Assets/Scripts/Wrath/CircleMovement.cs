using UnityEngine;

public class CircleMovement : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 100f;
    [SerializeField] private float movementSpeed = 5f;
    [SerializeField] private Transform spawnPoint; // The spawn point to reset position
    private bool isRotating = false; // Determines if the circle should rotate
    private bool isClockwise = false; // Initial direction is counterclockwise

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left-click to start rotating and toggle direction
        {
            if (!isRotating)
            {
                isRotating = true; // Start rotating after the first click
            }
            else
            {
                isClockwise = !isClockwise; // Toggle direction on subsequent clicks
            }
        }

        if (isRotating)
        {
            RotateCircle();
            MoveCircle();
        }
    }

    private void RotateCircle()
    {
        float direction = isClockwise ? 1f : -1f; // Set direction based on clockwise or counterclockwise
        transform.Rotate(0f, 0f, rotationSpeed * direction * Time.deltaTime);
    }

    private void MoveCircle()
    {
        // Moves the circle in the direction it is facing (upward in this case)
        transform.Translate(Vector3.up * movementSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            // Reset the position to the spawn point upon collision with an obstacle
            transform.position = spawnPoint.position;
        }
    }
}
