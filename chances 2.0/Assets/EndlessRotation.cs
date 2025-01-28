using UnityEngine;

public class EndlessRotation : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 100f;
    [SerializeField] private bool isClockwise = true; // You can customize this in the Inspector

    void Update()
    {
        RotateObject();
    }

    private void RotateObject()
    {
        float direction = isClockwise ? 1f : -1f; // Clockwise or counterclockwise based on 'isClockwise'
        transform.Rotate(0f, 0f, rotationSpeed * direction * Time.deltaTime);
    }
}
