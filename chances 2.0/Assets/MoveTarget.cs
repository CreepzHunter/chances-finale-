using UnityEngine;

public class MoveToTarget : MonoBehaviour
{
    private Vector2 moveDirection;  // Direction to move in
    private float speed;

    // Initialize with target's position and speed
    public void Initialize(Vector2 targetPos, float moveSpeed)
    {
        // Calculate the direction toward the target's position
        moveDirection = (targetPos - (Vector2)transform.position).normalized;
        speed = moveSpeed;

        // Calculate the angle in degrees between the arrow's position and the target
        float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;

        // Rotate the arrow to face the target
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));  // Subtract 90 degrees because we want the tip of the arrow facing forward
    }

    void Update()
    {
        // Move the arrow forward in the calculated direction
        transform.Translate(moveDirection * speed * Time.deltaTime, Space.World);
    }
}
