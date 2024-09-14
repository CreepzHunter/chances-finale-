using UnityEngine;
using System.Collections;

public class ObjectSpawner2D : MonoBehaviour
{
    public GameObject objectToSpawn;  // Prefab to spawn
    public BoxCollider2D boxCollider; // Reference to the 2D box collider
    public GameObject target;  // The target object
    public bool canSpawn = true;
    public float speed = 5f;  // Speed at which the object moves towards the target
    public Transform parentTransform; // The parent where the object should be instantiated (optional)

    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            if (canSpawn)
            {
                SpawnObjectAtEdge();
            }
            yield return new WaitForSeconds(1f);
        }
    }

    void SpawnObjectAtEdge()
    {
        Bounds bounds = boxCollider.bounds;

        bool isVerticalEdge = Random.value > 0.5f;
        Vector2 spawnPosition;

        if (isVerticalEdge)
        {
            float xPos = Random.value > 0.5f ? bounds.min.x : bounds.max.x;
            float yPos = Random.Range(bounds.min.y, bounds.max.y);
            spawnPosition = new Vector2(xPos, yPos);
        }
        else
        {
            float yPos = Random.value > 0.5f ? bounds.min.y : bounds.max.y;
            float xPos = Random.Range(bounds.min.x, bounds.max.x);
            spawnPosition = new Vector2(xPos, yPos);
        }

        // Instantiate the object at the calculated position, with an optional parent
        GameObject spawnedObject = Instantiate(objectToSpawn, spawnPosition, Quaternion.identity, parentTransform);

        // Align the instantiated object's z-position with the parent's z-position
        Vector3 parentPosition = parentTransform.position;
        spawnedObject.transform.position = new Vector3(spawnedObject.transform.position.x, spawnedObject.transform.position.y, parentPosition.z);

        // Capture the target's current position at the moment of spawning
        Vector2 targetPos = target.transform.position;

        // Start the movement towards the captured target position
        spawnedObject.AddComponent<MoveToTarget>().Initialize(targetPos, speed);

        Destroy(spawnedObject, 8f);
    }

}
