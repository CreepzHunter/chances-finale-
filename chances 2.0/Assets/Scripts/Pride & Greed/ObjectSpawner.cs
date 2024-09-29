using UnityEngine;
using System.Collections;

public class ObjectSpawner2D : MonoBehaviour
{
    public GameObject objectToSpawn;
    public BoxCollider2D boxCollider;
    public GameObject target;
    public bool canSpawn = true;
    public float speed = 5f;
    public Transform parentTransform;

    void Start()
    {
    }

    public void SpawnRoutineCour()
    {
        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        // Wait for 3 seconds before starting the spawn loop
        yield return new WaitForSeconds(3f);

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

        GameObject spawnedObject = Instantiate(objectToSpawn, spawnPosition, Quaternion.identity, parentTransform);

        Vector3 parentPosition = parentTransform.position;
        spawnedObject.transform.position = new Vector3(spawnedObject.transform.position.x, spawnedObject.transform.position.y, parentPosition.z);

        Vector2 targetPos = target.transform.position;

        spawnedObject.AddComponent<MoveToTarget>().Initialize(targetPos, speed);

        Destroy(spawnedObject, 8f);
    }

}
