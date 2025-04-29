using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ObjectSpawner : MonoBehaviour
{
    [Header("Fruits & Bombs Prefabs")]
    public GameObject prefab;

    [Header("Gameplay")]
    [SerializeField] private float minInterval = 1f;
    [SerializeField] private float maxInterval = 3f;
    [SerializeField] private float minX;
    [SerializeField] private float maxX;
    [SerializeField] private float y;
    [SerializeField] private TimerGame timerGame;
    [SerializeField] private float spawnDuration;
    [Header("Visuals")]
    [SerializeField] private Sprite[] sprites;


    private bool isSpawning = true;
    private AttackGluttony attackGluttony;

    void OnEnable()
    {
        spawnDuration = timerGame.spawnTimer;
        isSpawning = true;

        attackGluttony = Resources.FindObjectsOfTypeAll<AttackGluttony>()
              .FirstOrDefault(obj => obj.gameObject.scene.isLoaded);

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
