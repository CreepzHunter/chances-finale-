using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicAnalyzer : MonoBehaviour
{
    public AudioClip musicClip;
    public AudioClip soundDrop;

    private AudioSource audioSource;
    private AudioSource drop;


    private int beatCount = 0;

    public float damageRatio;
    public float bpm = 200;
    public float beatInterval;
    private float lastBeatTime;

    public Transform arrowHolder;
    public GameObject leftArrowPrefab;
    public GameObject upArrowPrefab;
    public GameObject rightArrowPrefab;
    public GameObject downArrowPrefab;

    public Transform leftTransform;
    public Transform upTransform;
    public Transform rightTransform;
    public Transform downTransform;

    public Transform arrowsParent;
    public DisableRhythmHealth disableRhythmHealth;
    public HealthSystem healthSystem;
    public GameFlowManagerLust gameFlowManagerLust;

    public bool shouldStop = false;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        drop = gameObject.AddComponent<AudioSource>();
        audioSource.clip = musicClip;
        drop.clip = soundDrop;
        Play();

        beatInterval = 60f / bpm;
        lastBeatTime = -beatInterval;
    }


    public void Reset()
    {
        beatInterval = 60f / bpm;
        lastBeatTime = -beatInterval;
        beatCount = 0;
        shouldStop = false;

        foreach (Transform child in arrowHolder)
        {
            Destroy(child.gameObject);
        }

        audioSource.time = 0f;
    }

    public void Play()
    {
        audioSource.Play();
        disableRhythmHealth.EnableRhythm();
    }

    void Update()
    {
        if (shouldStop)
        {
            return;
        }

        float currentTime = audioSource.time;
        float clipLength = audioSource.clip.length;



        Debug.Log("current time: " + currentTime + " | clip length: " + clipLength);

        if (currentTime >= clipLength - 0.5f)
        {
            if (healthSystem.health > 0)
            {
                Fail();
            }

        }
        else
        {
            if (currentTime < clipLength - 6f && currentTime - lastBeatTime >= beatInterval && audioSource.isPlaying)
            {
                beatCount++;
                lastBeatTime += beatInterval;

                InstantiateArrow();
            }
        }
    }

    public void Fail()
    {
        Reset();
        disableRhythmHealth.DisableRhythm();
        audioSource.time = 0f;
        gameFlowManagerLust.LoseLevel();
        shouldStop = true;
    }

    void InstantiateArrow()
    {
        if (shouldStop)
        {
            return;
        }

        int arrowType = Random.Range(0, 4);

        GameObject arrowPrefab = null;
        Transform spawnPosition = null;
        switch (arrowType)
        {
            case 0:
                arrowPrefab = leftArrowPrefab;
                arrowPrefab.GetComponent<SpriteRenderer>().color = Color.blue;
                spawnPosition = leftTransform;
                break;
            case 1:
                arrowPrefab = upArrowPrefab;
                arrowPrefab.GetComponent<SpriteRenderer>().color = Color.red;
                spawnPosition = upTransform;
                break;
            case 2:
                arrowPrefab = rightArrowPrefab;
                arrowPrefab.GetComponent<SpriteRenderer>().color = Color.green;
                spawnPosition = rightTransform;
                break;
            case 3:
                arrowPrefab = downArrowPrefab;
                arrowPrefab.GetComponent<SpriteRenderer>().color = Color.yellow;
                spawnPosition = downTransform;
                break;
        }

        if (arrowPrefab != null && spawnPosition != null)
        {
            GameObject arrowInstance = Instantiate(arrowPrefab, spawnPosition.position, spawnPosition.rotation, arrowsParent);
        }
    }

    public void StopMusicAnalyzer()
    {

        foreach (Transform child in arrowHolder)
        {
            Renderer renderer = child.GetComponent<Renderer>();
            if (renderer != null)
            {
                StartCoroutine(FadeOutAndDestroy(renderer.gameObject, 0.3f));
            }
            else
            {
                Destroy(child.gameObject);
            }
        }
        shouldStop = true;
        audioSource.Stop();

        GameManagerRhythm.instance.stopGame = true;
    }

    IEnumerator FadeOutAndDestroy(GameObject obj, float fadeDuration)
    {
        Renderer renderer = obj.GetComponent<Renderer>();
        if (renderer == null)
        {
            yield break;
        }

        float elapsedTime = 0f;
        Color initialColor = renderer.material.color;
        Color targetColor = new Color(initialColor.r, initialColor.g, initialColor.b, 0f); // Fade to fully transparent

        while (elapsedTime < fadeDuration)
        {
            float alpha = Mathf.Lerp(initialColor.a, targetColor.a, elapsedTime / fadeDuration);
            renderer.material.color = new Color(initialColor.r, initialColor.g, initialColor.b, alpha);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        renderer.material.color = targetColor;

        Destroy(obj);
    }
}
