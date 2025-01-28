using UnityEngine;

public class UpDownMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 5f; // Speed of up and down movement
    [SerializeField] private float moveDistance = 3f; // How far up and down the object will move
    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position; // Store the starting position
    }

    void Update()
    {
        // Move the object up and down
        float yMovement = Mathf.Sin(Time.time * movementSpeed) * moveDistance;
        transform.position = new Vector3(startPosition.x, startPosition.y + yMovement, startPosition.z);
    }
}
