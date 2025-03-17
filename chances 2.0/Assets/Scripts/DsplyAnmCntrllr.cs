using UnityEngine;

public class DsplyAnmCntrllr : MonoBehaviour
{
    [SerializeField] private GameObject prefab;

    public void DisplayFloatingText(float value, Transform spawnPoint)
    {
        if (prefab == null || spawnPoint == null)
        {
            return;
        }
        Vector3 worldPosition = spawnPoint.position;
        GameObject instance = Instantiate(prefab, worldPosition, Quaternion.identity);

        TextMesh textMesh = instance.GetComponent<TextMesh>();

        if (textMesh != null)
        {
            textMesh.text = value.ToString();
        }

    }
}
