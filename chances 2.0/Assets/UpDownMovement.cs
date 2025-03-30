using UnityEngine;

public class UpDownMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 5f;
    [SerializeField] private float moveDistance = 3f;
    private Vector3 startPosition;
    private float randomOffset;

    void Start()
    {
        startPosition = transform.position;
        randomOffset = Random.Range(0f, Mathf.PI * 2);
    }

    void Update()
    {
        float yMovement = Mathf.Sin(Time.time * movementSpeed + randomOffset) * moveDistance;
        transform.position = new Vector3(startPosition.x, startPosition.y + yMovement, startPosition.z);
    }
}
