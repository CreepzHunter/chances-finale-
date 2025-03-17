using System.Collections;
using UnityEngine;

public class DmgAnimation : MonoBehaviour
{
    public float fadeDuration = 4f;


    void Start()
    {
        StartCoroutine(FadeAndDestroy());
    }

    IEnumerator FadeAndDestroy()
    {
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        if (meshRenderer == null)
        {
            yield break;
        }

        Material material = meshRenderer.material;
        Color startColor = material.color;
        float timer = 0f;

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            float alpha = Mathf.Lerp(2, 0, timer / fadeDuration);
            material.color = new Color(startColor.r, startColor.g, startColor.b, alpha);
            yield return null;
        }

        Destroy(gameObject);
    }
}
