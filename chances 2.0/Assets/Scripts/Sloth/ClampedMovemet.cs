using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClampedMovemet : MonoBehaviour
{
    private Collider2D terrainCollider;
    public GameObject terrain;
    private Rigidbody2D rb;
    public float edgeOffset = 10f; // Offset from the edges

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        terrainCollider = terrain.GetComponent<Collider2D>();
        terrainCollider.isTrigger = true; // Set the collider as a trigger to prevent physical collisions
    }
    void FixedUpdate()
    {
        Vector2 clampedPosition = ClampPositionToCollider(rb.position, terrainCollider);
        rb.position = clampedPosition;
    }

    Vector2 ClampPositionToCollider(Vector2 position, Collider2D collider)
    {
        Vector2 closestPoint = collider.ClosestPoint(position);

        // Adjust the closest point to include the offset
        closestPoint = AdjustForOffset(closestPoint, collider);

        return closestPoint;
    }

    Vector2 AdjustForOffset(Vector2 point, Collider2D collider)
    {
        Bounds bounds = collider.bounds;

        float left = bounds.min.x + edgeOffset;
        float right = bounds.max.x - edgeOffset;
        float bottom = bounds.min.y + edgeOffset;
        float top = bounds.max.y - edgeOffset;

        // Clamp the point to ensure it respects the offset
        point.x = Mathf.Clamp(point.x, left, right);
        point.y = Mathf.Clamp(point.y, bottom, top);

        return point;
    }
}
