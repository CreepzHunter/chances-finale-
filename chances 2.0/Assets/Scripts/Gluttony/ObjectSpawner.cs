using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ObjectSpawner : MonoBehaviour
{
    [Header("Fruits & Bombs Prefabs")]
    public GameObject prefab;

    [Header("Gameplay")]
    [SerializeField] private float minInterval = 1f; // Minimum spawn interval
    [SerializeField] private float maxInterval = 3f; // Maximum spawn interval
    [SerializeField] private float minX;
    [SerializeField] private float maxX;
    [SerializeField] private float y;
    private float spawnDuration = 10f; // Time limit for spawning

    [Header("Visuals")]
    [SerializeField] private Sprite[] sprites;

    private bool isSpawning = true;
    private AttackGluttony attackGluttony; // Find this component dynamically

    void OnEnable()
    {
        isSpawning = true;

        // Find AttackGluttony in the hierarchy
        attackGluttony = Resources.FindObjectsOfTypeAll<AttackGluttony>()
              .FirstOrDefault(obj => obj.gameObject.scene.isLoaded); // Ensure it's part of the active scene

        StartCoroutine(SpawnRoutine());
        StartCoroutine(StopSpawningAfterDuration());
    }

    private IEnumerator SpawnRoutine()
    {
        while (isSpawning)
        {
            Spawn();
            float randomInterval = Random.Range(minInterval, maxInterval);
            yield return new WaitForSeconds(randomInterval);
        }
    }

    private IEnumerator StopSpawningAfterDuration()
    {
        yield return new WaitForSeconds(spawnDuration);
        isSpawning = false;

        // gameObject.SetActive(false);

        // Pass the status to AttackGluttony

        Invoke(nameof(HandleSpawningStatusWrapper), 2.5f);
    }
    private void HandleSpawningStatusWrapper()
    {
        attackGluttony.HandleSpawningStatus(isSpawning);
    }
    public void Spawn()
    {
        if (!isSpawning) return;

        // Instantiate prefab
        GameObject instance = Instantiate(prefab);
        instance.transform.position = new Vector2(
            Random.Range(minX, maxX),
            y
        );

        // Assign a random sprite
        int randomIndex = Random.Range(0, sprites.Length);
        Sprite randomSprite = sprites[randomIndex];
        instance.GetComponent<SpriteRenderer>().sprite = randomSprite;

        // Assign fruit type if applicable
        FruitCuttable fruitCuttable = instance.GetComponent<FruitCuttable>();
        if (fruitCuttable != null)
        {
            fruitCuttable.SetFruitType(randomIndex);
        }
    }
}
